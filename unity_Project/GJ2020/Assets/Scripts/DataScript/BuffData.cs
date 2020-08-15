using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffData
{
    public static List<BuffData> dataList = new List<BuffData>();

    /// <summary>
    /// id
    /// </summary>
    public int id = -1;

    /// <summary>
    /// 状态名
    /// </summary>
    public string name = string.Empty;

    /// <summary>
    /// buff枚举类型
    /// </summary>
    public Buff.BuffType type = Buff.BuffType.Buff;

    /// <summary>
    /// 存在回合数
    /// </summary>
    public int roundNum = 1;

    /// <summary>
    /// 是否是创建时生效
    /// </summary>
    public bool createdUse = false;

    /// <summary>
    /// 是否是每回合生效
    /// </summary>
    public bool roundUse = false;

    /// <summary>
    /// 体力的变动值
    /// </summary>
    public int staminaChange = 0;
    /// <summary>
    /// san值得变动值
    /// </summary>
    public int sanChange = 0;

    /// <summary>
    /// 执行状态名
    /// </summary>
    public Buff.PerformBuffName performBuffName = Buff.PerformBuffName.none;

    /// <summary>
    /// Spine文件名
    /// </summary>
    public string spineFileName = string.Empty;


    public BuffData()
    {
        BuffData.dataList.Add(this);
    }
}
