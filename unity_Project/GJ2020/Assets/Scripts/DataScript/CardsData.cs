using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsData
{
    public static List<CardsData> dataList = new List<CardsData>();
    /// <summary>
    /// id
    /// </summary>
    public int card_ID;

    /// <summary>
    /// 卡牌名字
    /// </summary>
    public string card_Name;

    /// <summary>描述</summary>
    public string card_Desc;

    /// <summary>丧值</summary>
    public int san_Change;

    /// <summary>
    /// 消耗体力值
    /// </summary>
    public int energy_Take = 1;

    /// <summary>
    /// 状态id
    /// </summary>
    public int forceCondition_Id = -1;

    /// <summary>
    /// 施加对像
    /// </summary>
    public Enum.SubjectToEnum force_Object = Enum.SubjectToEnum.player;

    /// <summary>变牌触发敌人ID</summary>
    public int monster_Id = -1;
    /// <summary>所变牌ID</summary>
    public int exCard_ID = -1;

    /// <summary>卡图文件名</summary>
    public string png_Name = string.Empty;

    public CardsData()
    {
        CardsData.dataList.Add(this);
    }

    public void SettingData(Card _cardComponent)
    {
        _cardComponent.SettingData(
            this.card_ID,
            this.card_Name,
            this.energy_Take,
            this.san_Change,
            this.forceCondition_Id,
            this.force_Object,
            this.monster_Id,
            this.exCard_ID,
            this.png_Name
        );
    }

    public Card CreateMe()
    {
        Card newCard = new Card(
            this.card_ID,
            this.card_Name,
            this.energy_Take,
            this.san_Change,
            this.forceCondition_Id,
            this.force_Object,
            this.monster_Id,
            this.exCard_ID,
            this.png_Name
        );

        return newCard;
    }

    public static CardsData GetRandomData()
    {
        if (CardsData.dataList.Count > 0)
        {
            int index = Random.Range(0, CardsData.dataList.Count);
            return CardsData.dataList[index];
        }

        return null;
    }

    public static Card CreateRandomCard()
    {
        if (CardsData.dataList.Count > 0)
        {
            int index = Random.Range(0, CardsData.dataList.Count);
            return CardsData.dataList[index].CreateMe();
        }

        return null;
    }

    public string ShowString()
    {
        return this.card_ID + " : " + this.card_Name + " : " + this.energy_Take + " : " + this.san_Change + " : " + this.forceCondition_Id + " : " + this.force_Object + " : " + this.monster_Id + " : " + this.exCard_ID + " : " + this.png_Name;
    }
}
