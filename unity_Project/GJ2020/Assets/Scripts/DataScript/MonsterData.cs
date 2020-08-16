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
    public int monster_ID = -1;

    /// <summary>怪物名</summary>
    public string monster_Name = string.Empty;

    /// <summary>
    /// 回合数
    /// </summary>
    public int init_RoundNum = 1;

    /// <summary>
    /// 技能ID
    /// </summary>
    public List<int> monsterskillid_Array = null;

    /// <summary>出厂顺序</summary>
    public int start_Order = 0;

    /// <summary>
    /// Spine Asset 文件路径
    /// </summary>
    public string spineAnime_Name = string.Empty;

    /// <summary>
    /// 技能名称
    /// </summary>
    //public string skillName = string.Empty;


    //public MonsterData()
    //{
    //    Debug.Log("Created Me");
    //}

    public MonsterData()
    {
        MonsterData.dataList.Add(this);
    }

    public void SettingData(MonsterActor _actorComponent)
    {
        _actorComponent.SettingData(
            this.monster_ID,
            this.monster_Name,
            this.monsterskillid_Array,
            this.spineAnime_Name
        );
    }

    //public MonsterActor CreateMe()
    //{
    //    MonsterActor monsterActor = new MonsterActor(
    //        this.monster_ID,
    //        this.monster_Name,
    //        this.monsterskillid_Array,
    //        this.spineAnime_Name
    //    );

    //    return monsterActor;
    //}

    public string ShowString()
    {
        string skillIdStr = "";
        foreach (var item in this.monsterskillid_Array)
        {
            skillIdStr += item + ",";
        }

        return this.monster_ID + " : " + this.monster_Name + " : " + skillIdStr + " : " + this.spineAnime_Name;
    }

    //public string toString()
    //{
    //    string skillIdStr = "";
    //    foreach (var item in this.skillId)
    //    {
    //        skillIdStr += item + ",";
    //    }

    //    return "ID: " + this.id + " SN: " + this.skillName + " SI:" + skillIdStr + "RN:" + roundNum;
    //}
}

///// <summary>
///// 怪物数据表
///// </summary>
//public class MonsterDataList
//{
//    public List<MonsterData> dataList = null;
//}