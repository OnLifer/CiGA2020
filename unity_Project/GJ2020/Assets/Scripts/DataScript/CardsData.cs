using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsData
{
    public static List<CardsData> dataList = new List<CardsData>();

    /// <summary>
    /// id
    /// </summary>
    public int id;

    /// <summary>
    /// 卡牌名字
    /// </summary>
    public string name;

    /// <summary>描述</summary>
    public string describe;

    /// <summary>丧值</summary>
    public int sanValue;

    /// <summary>
    /// 消耗体力值
    /// </summary>
    public int staminaValue = 1;

    /// <summary>
    /// 状态id
    /// </summary>
    public int buffId = -1;

    /// <summary>
    /// 施加对像
    /// </summary>
    public Enum.SubjectToEnum subjectTo = Enum.SubjectToEnum.player;

    public CardsData()
    {
        CardsData.dataList.Add(this);
    }


}
