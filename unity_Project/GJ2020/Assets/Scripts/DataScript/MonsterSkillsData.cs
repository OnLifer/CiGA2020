using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSkillsData
{
    public static List<MonsterSkillsData> dataList = new List<MonsterSkillsData>();

    /// <summary>
    /// 技能id
    /// </summary>
    public int monsterSkill_Id = -1;
    /// <summary>
    /// 技能名称
    /// </summary>
    public string monsterSkill_Name = string.Empty;
    /// <summary>
    /// 施加的buff的id
    /// </summary>
    public int forceCondition_Id = -1;

    /// <summary>
    /// 施加对像得枚举
    /// </summary>
    
    /// <summary>
    /// 施加对像类别
    /// </summary>
    public Enum.SubjectToEnum force_Object = Enum.SubjectToEnum.player;

    /// <summary>
    /// 体力的变动值
    /// </summary>
    public int energy_Change = 0;
    /// <summary>
    /// san值得变动值
    /// </summary>
    public int san_Change = 0;

    /// <summary>
    /// 对应的Spine得文件名
    /// </summary>
    public string spineAnime_Name = string.Empty;

    public MonsterSkillsData()
    {
        MonsterSkillsData.dataList.Add(this);
    }

    /// <summary>
    /// 创建对应的MonsterSkill
    /// </summary>
    /// <returns>对应的 MonsterSkill实例</returns>
    public MonsterSkill CreateMe()
    {
        MonsterSkill retMonsterSkill = new MonsterSkill(
            this.monsterSkill_Id, 
            this.monsterSkill_Name,
            this.forceCondition_Id,
            this.force_Object,
            this.energy_Change,
            this.san_Change,
            this.spineAnime_Name
        );

        //public int id = -1;
        //public string name = string.Empty;
        ///// <summary>施加的buff的id</summary>
        //public int buffId = -1;

        //public Enum.SubjectToEnum subjectTo = Enum.SubjectToEnum.player;

        //public int staminaValue = 0;
        //public int sanValue = 0;

        //public string spineFileName = string.Empty;

        return retMonsterSkill;
    }

    public string ShowString()
    {
        return this.monsterSkill_Id + " : " + this.monsterSkill_Name + " : " + this.forceCondition_Id + " : " + this.force_Object + " : " + this.energy_Change + " : " + this.san_Change + " : " + this.spineAnime_Name;
    }
}
