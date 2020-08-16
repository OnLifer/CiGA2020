using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffData
{
    public static List<BuffData> dataList = new List<BuffData>();

    /// <summary>
    /// id
    /// </summary>
    public int condition_ID = -1;

    /// <summary>
    /// 状态名
    /// </summary>
    public string condition_Name = string.Empty;

    /// <summary>
    /// buff枚举类型
    /// </summary>
    public Buff.BuffType condition_Sort = Buff.BuffType.buff;

    /// <summary>
    /// 存在回合数
    /// </summary>
    public int take_Rounds = 1;

    /// <summary>
    /// 是否是创建时生效
    /// </summary>
    public bool bool_Now = false;

    /// <summary>
    /// 是否是每回合生效
    /// </summary>
    public bool bool_EveryRound = false;

    /// <summary>
    /// 体力的变动值
    /// </summary>
    public int energy_ChangeVal = 0;
    /// <summary>
    /// san值得变动值
    /// </summary>
    public int san_ChangeVal = 0;

    /// <summary>
    /// 执行状态名
    /// </summary>
    public Buff.PerformBuffName execute_Condition = Buff.PerformBuffName.none;

    /// <summary>
    /// Spine文件名
    /// </summary>
    public string spine_Name = string.Empty;

    /// <summary>
    /// 图片文件名
    /// </summary>
    public string png_Name = string.Empty;


    public BuffData()
    {
        BuffData.dataList.Add(this);
    }

    public Buff CreateMe()
    {
        Buff buff = new Buff(
            this.condition_ID,
            this.condition_Name,
            this.condition_Sort,
            this.take_Rounds,
            this.bool_Now,
            this.bool_EveryRound,
            this.energy_ChangeVal,
            this.san_ChangeVal,
            this.execute_Condition,
            this.spine_Name,
            this.png_Name
        );

        return buff;
    }

    public string ShowString()
    {
        return this.condition_ID + " : " + this.condition_Name + " : " + this.condition_Sort + " : " + this.take_Rounds + " : " + this.bool_Now + " : " + this.bool_EveryRound + " : " + this.energy_ChangeVal + " : " + this.san_ChangeVal + " : " + this.execute_Condition + " : " + this.spine_Name + " : " + this.png_Name;
    }
}
