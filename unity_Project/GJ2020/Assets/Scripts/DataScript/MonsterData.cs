using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 怪物数据
/// </summary>
public class MonsterData
{
    public static List<MonsterData> dataList = new List<MonsterData>();

    /// <summary>
    /// 怪物id
    /// </summary>
    public int id = -1;

    /// <summary>
    /// Spine Asset 文件路径
    /// </summary>
    public string spineFileName = string.Empty;

    /// <summary>
    /// 技能名称
    /// </summary>
    public string skillName = string.Empty;

    /// <summary>
    /// 技能ID
    /// </summary>
    public List<int> skillId = null;

    /// <summary>
    /// 生命值
    /// </summary>
    //public int hp = 100;

    /// <summary>
    /// 回合数
    /// </summary>
    public int roundNum = 1;

    //public MonsterData()
    //{
    //    Debug.Log("Created Me");
    //}

    public MonsterData()
    {
        MonsterData.dataList.Add(this);
    }

    public string toString()
    {
        string skillIdStr = "";
        foreach (var item in this.skillId)
        {
            skillIdStr += item + ",";
        }

        return "ID: " + this.id + " SN: " + this.skillName + " SI:" + skillIdStr + "RN:" + roundNum;
    }
}

///// <summary>
///// 怪物数据表
///// </summary>
//public class MonsterDataList
//{
//    public List<MonsterData> dataList = null;
//}