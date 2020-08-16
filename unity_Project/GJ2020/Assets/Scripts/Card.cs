using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerClickHandler
{
    #region Inspector
    public Image image = null;
    public Text text = null;

    #endregion

    void OnValidate() {
        if (this.image == null) this.image = GetComponent<Image>();
    }

    //[Header("由创建器创建的属性 回头可能private掉")]
    [HideInInspector]
    /// <summary>id</summary>
    public int listId = -1;

    [HideInInspector]
    /// <summary>id</summary>
    public int id = -1;

    [HideInInspector]
    /// <summary>卡牌名字</summary>
    public string cardName = string.Empty;
    [HideInInspector]
    /// <summary>卡牌描述</summary>
    public string describe = string.Empty;

    [HideInInspector]
    /// <summary>丧值</summary>
    public int sanValue = 0;

    [HideInInspector]
    /// <summary>消耗体力值</summary>
    public int staminaValue = -1;

    [HideInInspector]
    /// <summary>状态id</summary>
    public int buffId = -1;

    [HideInInspector]
    /// <summary>施加对像</summary>
    public Enum.SubjectToEnum subjectTo = Enum.SubjectToEnum.player;

    [HideInInspector]
    /// <summary>变牌触发敌人ID</summary>
    public int changeMonsterId = -1;
    [HideInInspector]
    /// <summary>所变牌ID</summary>
    public int changeCardId = -1;

    [HideInInspector]
    /// <summary>卡图文件名</summary>
    public string imageFileName = string.Empty;

    /// <summary>使用卡的事件</summary>
    public event NormalHandler useCardEvent;

    /// <summary>卡片变化事件</summary>
    public event ValueToHandler changeCardEvent;

    //public Card() { }
    //public Card(
    //    int _id,
    //    string _name,
    //    int _staminaValue,
    //    int _sanValue,
    //    int _buffId,
    //    Enum.SubjectToEnum _subjectTo,
    //    int _changeMonsterId,
    //    int _changeCardId,
    //    string _imageFileName
    //) {
    //    this.id = _id;
    //    this.cardName = _name;
    //    this.staminaValue = _staminaValue;
    //    this.sanValue = _sanValue;
    //    this.buffId = _buffId;
    //    this.subjectTo = _subjectTo;
    //    this.changeMonsterId = _changeMonsterId;
    //    this.changeCardId = _changeCardId;
    //    this.imageFileName = _imageFileName;

    //    this.listId = ControlManager.instance.cardList.Count();
    //    ControlManager.instance.cardList.Add(this);
    //}

    /// <summary>
    /// 写入值
    /// </summary>
    /// <param name="_id"></param>
    /// <param name="_name"></param>
    /// <param name="_staminaValue"></param>
    /// <param name="_sanValue"></param>
    /// <param name="_buffId"></param>
    /// <param name="_subjectTo"></param>
    /// <param name="_changeMonsterId"></param>
    /// <param name="_changeCardId"></param>
    /// <param name="_imageFileName"></param>
    public void SettingData(
        int _id,
        string _name,
        int _staminaValue,
        int _sanValue,
        int _buffId,
        Enum.SubjectToEnum _subjectTo,
        int _changeMonsterId,
        int _changeCardId,
        string _imageFileName
    )
    {
        this.id = _id;
        this.cardName = _name;
        this.staminaValue = _staminaValue;
        this.sanValue = _sanValue;
        this.buffId = _buffId;
        this.subjectTo = _subjectTo;
        this.changeMonsterId = _changeMonsterId;
        this.changeCardId = _changeCardId;
        this.imageFileName = _imageFileName;

        if (this.text != null) this.text.text = this.cardName;

        this.listId = ControlManager.instance.cardList.Count();
        ControlManager.instance.cardList.Add(this);
    }


    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        this.OnCardClick();

        //throw new System.NotImplementedException();
    }

    /// <summary>
    /// 卡牌点击事件
    /// </summary>
    public void OnCardClick()
    {
        this.UseCard();
    }

    /// <summary>
    /// 检查玩家的体力是否足够 综合Buff效果
    /// </summary>
    /// <returns>体力是否足够消耗</returns>
    public bool CheckPlayerStamina()
    {
        bool canChange = ControlManager.instance.playerActor.CheckStaminaChange(-this.staminaValue, out int outValue);
        // 判断是否足够变化 可以的话将值修改为新值
        if (canChange)
        {
            Debug.Log("[UserCard Stamina]" + ControlManager.instance.playerActor.staminaValue + " : " + outValue + " : " + this.staminaValue);
            //ControlManager.instance.playerActor.staminaValue = outValue;
            ControlManager.instance.playerActor.StaminaChange(-this.staminaValue);
        }
        return canChange;
    }

    /// <summary>
    /// 使用卡牌
    /// </summary>
    /// <param name="_actor">Actor 实例</param>
    public void UseCard()
    {
        // 判断体力是否足够
        if (!this.CheckPlayerStamina())
        {
            // todo 提示无法使用的相关动作
            return;
        }



        // 调用事件
        if(this.useCardEvent != null) this.useCardEvent();

        Actor target = this.subjectTo == Enum.SubjectToEnum.enemy ? ControlManager.instance.monsterActor as Actor : ControlManager.instance.playerActor as Actor;

        // 向目标施加buff
        if (this.buffId > -1) BuffCreater.AddBuffToActor(target, this.buffId);

        // 对玩家进行San值变更
        ControlManager.instance.playerActor.SanChange(this.sanValue);

        if(target.id > -1 && this.changeMonsterId == target.id)
        {
            this.ChangeCard(this.changeCardId);
        }

        // 移除卡牌 如果必要的话
        this.RemoveCard();
    }

    /// <summary>
    /// 卡牌变换
    /// </summary>
    /// <param name="_cardId">目标卡牌id</param>
    public void ChangeCard(int _cardId)
    {
        int index = ControlManager.instance.cardList.FindIndex(t => t.id == this.id);

        CardsData cardsData = CardsData.dataList.Find(t => t.card_ID == _cardId);
        //Card newCard = cardsData.CreateMe();
        Card newCard = ControlManager.instance.CreateCard(cardsData);

        ControlManager.instance.cardList[index] = newCard;
        //ControlManager.instance.cardList[index] = 
        //ControlManager.instance.cardList.Remove(this);
        // 调用事件

        if(this.changeCardEvent != null) this.changeCardEvent(_cardId);
    }

    /// <summary>
    /// 移除卡牌
    /// </summary>
    public void RemoveCard()
    {
        //ControlManager.instance.cardList.FindIndex(this);
        ControlManager.instance.cardList[this.listId] = null;
        // 现在是直接销毁对像
        Destroy(this.gameObject);
    }

    
}
