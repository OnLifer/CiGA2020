using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlManager : MonoSingleton<ControlManager>
{
    #region Inspector
    /// <summary>玩家演员</summary>
    public PlayerActor playerActor = null;

    [Space()]
    public GameObject cardPrefab = null;
    public GameObject monsterPrefab = null;

    [Header("UI")]
    public Text sanText = null;
    public Text staText = null;
    public Text roundText = null;
    #endregion

    [HideInInspector]
    /// <summary>当前回合数</summary>
    public int roundCount = 0;

    [HideInInspector]
    /// <summary>当前怪物序号</summary>
    public int nowMonsterIndex = 0;

    [HideInInspector]
    /// <summary>怪物演员</summary>
    public MonsterActor monsterActor = null;

    [HideInInspector]
    /// <summary>手牌列表</summary>
    public List<Card> cardList = new List<Card>();

    public Transform cardListTransform;
    private void Start()
    {
        cardListTransform = GameObject.Find("CardList").transform;
        this.monsterActor = null;
        NextRound();
        this.UIBindToEvent();
    }

    #region 图方便的UI绑定
    private void UIBindToEvent()
    {
        if(this.sanText != null)
        {
            this.sanText.text = "San: " + this.playerActor.sanValue;
            this.playerActor.sanChangeEvent += this.SanTextChange;
        }
        if (this.staText!= null)
        {
            this.staText.text = "Sta: " + this.playerActor.staminaValue;
            this.playerActor.staminaChangeEvent += this.StaTextChange;
        }

        if (this.roundText) this.roundText.text = "Round: " + (this.roundCount + 1);
    }

    private void SanTextChange(int _value, int _oldValue)
    {
        this.sanText.text = "San: " + _value;
    }
    private void StaTextChange(int _value, int _oldValue)
    {
        this.staText.text = "Sta: " + _value;
    }
    private void RoundTextChange(int _value)
    {
        if(this.roundText) this.roundText.text = "Round: " + (_value+1);
    }
    #endregion
    /// <summary>
    /// 下一回合
    /// </summary>
    public void NextRound()
    {
        Debug.LogWarning("[NextRound]");

        

        if (this.playerActor != null && this.playerActor.roundRun)
        {
            //this.playerActor.staminaValue = GlobalManager.fatigueValues;
            this.playerActor.staminaValue = 5;
            this.playerActor.Action();
            return;
        }

        if (this.monsterActor != null && this.monsterActor.roundRun)
        {
            this.monsterActor.Action();
            return;
        }

        this.roundCount++;
        this.RoundTextChange(this.roundCount);
        Debug.Log("[Next Round] " + this.roundCount);

        if (this.monsterActor == null) this.CreateNewMonster();

        this.playerActor.roundRun = true;
        this.monsterActor.roundRun = true;

    }

    /// <summary>
    /// 用户手动下一回合
    /// </summary>
    public void UserNextRound()
    {
        this.playerActor.roundRun = false;
        this.NextRound();
    }

    /// <summary>
    /// 创建新的怪物 若当前 nowMonsterIndex 索引以大于总数量，则游戏结束
    /// </summary>
    public void CreateNewMonster()
    {
        if (this.monsterPrefab == null) return;


        MonsterData monsterData = null;
        MonsterActor monster = null;
        while(monsterData == null)
        {
            this.nowMonsterIndex++;
            if(this.nowMonsterIndex > LevelData.monsterList.Count)
            {
                this.GameOver();
                return;
            }

            //monsterData = LevelData.CreateMonsterActor(this.nowMonsterIndex);
            monsterData = LevelData.FindMonsterDataByIndex(this.nowMonsterIndex);
        }


        GameObject monsterObject = Instantiate(this.monsterPrefab);

        MonsterActor actor = monsterObject.GetComponent<MonsterActor>();
        monsterData.SettingData(actor);

        this.monsterActor = actor;

        Debug.Log("[New Monster]" + actor.monsterName);

        // 创建怪物预制体并添加 MonsterActor
        // todo...
    }

    /// <summary>
    /// 结束游戏
    /// </summary>
    public void GameOver()
    {
        if(this.playerActor.sanValue > 0)
        {
            SceneManager.LoadScene("EndScene");
            // 游戏胜利 Good End
        }
        else
        {
            SceneManager.LoadScene("EndScene");
            // 游戏失败 Bad End
        }
    }
    /// <summary>
    /// 生成牌组
    /// </summary>
    public void CreateCardList()
    {
        if (this.cardPrefab == null) return;

        // 手牌总数不足则补充
        while (this.cardList.Count < GlobalManager.cardCount)
        {
            //Card card = CardsData.CreateRandomCard();
            CardsData data = CardsData.GetRandomData();
            if(data == null)
            {
                Debug.LogError("没有更多得牌库");
                return;
            }

            GameObject cardObject = Instantiate(this.cardPrefab);
            cardObject.transform.SetParent(cardListTransform);

            Card card = cardObject.GetComponent<Card>();
            //Card card = cardObject.AddComponent<Card>();
            data.SettingData(card);
            //this.cardList.Add(card);
        }

        for (int i = 0; i < this.cardList.Count; i++)
        {
            if (this.cardList[i] == null)
            {
                CardsData data = CardsData.GetRandomData();
                if (data == null)
                {
                    Debug.LogError("没有更多得牌库");
                    return;
                }

                GameObject cardObject = Instantiate(this.cardPrefab);
                cardObject.transform.SetParent(cardListTransform);

                Card card = cardObject.GetComponent<Card>();
                //Card card = cardObject.AddComponent<Card>();
                data.SettingData(card);
                this.cardList[i] = card;
            }
        }

    }

    /// <summary>
    /// 创建卡牌
    /// </summary>
    /// <param name="_data"></param>
    /// <returns></returns>
    public Card CreateCard(CardsData _data)
    {
        if (this.cardPrefab == null) return null;
        GameObject cardObject = Instantiate(this.cardPrefab);
        cardObject.transform.SetParent(cardListTransform);

        Card card = cardObject.GetComponent<Card>();
        //Card card = cardObject.AddComponent<Card>();
        _data.SettingData(card);

        return card;
        //this.cardList[i] = card;
    }

    public void OnCardClick()
    {
        //播放状态动画？

        //敌人受击动画？

        //发生实际效果

        //敌人行动

        //回合结束
    }
}
