using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 怪物数据
/// </summary>
public class MonsterData
{
    /// <summary>
    /// 怪物id
    /// </summary>
    public int id = -1;

    /// <summary>
    /// Spine Asset 文件路径
    /// </summary>
    public string spineFilePath = string.Empty;

    /// <summary>
    /// 技能名称
    /// </summary>
    public string skillName = string.Empty;

    /// <summary>
    /// 技能ID
    /// </summary>
    public int skillId = -1;

    /// <summary>
    /// 生命值
    /// </summary>
    //public int hp = 100;

    /// <summary>
    /// 回合数
    /// </summary>
    public int roundNum = 1;
}

/// <summary>
/// 怪物数据表
/// </summary>
public class MonsterDataList
{
    public List<MonsterData> dataList = null;
}