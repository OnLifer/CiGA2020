using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlManager : MonoSingleton<ControlManager>
{
    #region Inspector
    /// <summary>玩家演员</summary>
    public PlayerActor playerActor = null;

    [Space()]
    public GameObject cardPrefab = null;

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
        NextRound();
    }

    /// <summary>
    /// 下一回合
    /// </summary>
    public void NextRound()
    {
       // if (this.monsterActor == null) this.CreateNewMonster();

        if (this.playerActor != null && this.playerActor.roundRun)
        {
            this.playerActor.Action();
            return;
        }

        if (this.monsterActor != null && this.monsterActor.roundRun)
        {
            this.monsterActor.Action();
            return;
        }

        this.roundCount++;
        Debug.Log("[Next Round] " + this.roundCount);

        this.playerActor.roundRun = true;
        this.monsterActor.roundRun = true;
    }

    /// <summary>
    /// 创建新的怪物 若当前 nowMonsterIndex 索引以大于总数量，则游戏结束
    /// </summary>
    public void CreateNewMonster()
    {

        MonsterActor monster = null;
        while(monster == null)
        {
            this.nowMonsterIndex++;
            if(this.nowMonsterIndex > LevelData.monsterList.Count)
            {
                this.GameOver();
                return;
            }

            monster = LevelData.CreateMonsterActor(this.nowMonsterIndex);
        }

        this.monsterActor = monster;

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
        while (this.cardList.Count < GlobalManager.cardCount - 1)
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
            this.cardList.Add(card);
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

    public void OnCardClick()
    {
        //播放状态动画？

        //敌人受击动画？

        //发生实际效果

        //敌人行动

        //回合结束
    }
}
