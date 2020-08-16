using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 关卡数据
/// </summary>
public class LevelData
{
    /// <summary>
    /// 怪物队列
    /// </summary>
    public static Dictionary<int, int> monsterList = new Dictionary<int, int>();
    //public static List<int> monsterList = null;

    /// <summary>
    /// 根据索引创建MonsterActor
    /// </summary>
    /// <param name="_index">索引</param>
    /// <returns>创建好的MonsterActor 或者null</returns>
    public static MonsterActor CreateMonsterActor(int _index)
    {
        if (LevelData.monsterList.ContainsKey(_index))
        {
            int monsterId = LevelData.monsterList[_index];
            MonsterData data = MonsterData.dataList.Find(t => t.monster_ID == monsterId);
            return data.CreateMe();
        }

        return null;
    }
}
