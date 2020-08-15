using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSkillsData
{
    public static List<MonsterSkillsData> dataList = new List<MonsterSkillsData>();

    /// <summary>
    /// 技能id
    /// </summary>
    public int id = -1;
    /// <summary>
    /// 技能名称
    /// </summary>
    public string name = string.Empty;
    /// <summary>
    /// 施加的buff的id
    /// </summary>
    public int buffId = -1;

    /// <summary>
    /// 施加对像得枚举
    /// </summary>
    
    /// <summary>
    /// 施加对像类别
    /// </summary>
    public Enum.SubjectToEnum subjectTo = Enum.SubjectToEnum.player;

    /// <summary>
    /// 体力的变动值
    /// </summary>
    public int staminaChange = 0;
    /// <summary>
    /// san值得变动值
    /// </summary>
    public int sanChange = 0;

    /// <summary>
    /// 对应的Spine得文件名
    /// </summary>
    public string spineFileName = string.Empty;

    public MonsterSkillsData()
    {
        MonsterSkillsData.dataList.Add(this);
    }
}
