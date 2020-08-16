using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterActor : Actor
{
    /// <summary>
    /// 存在回合数
    /// </summary>
    public int roundNum = 1;

    /// <summary>怪物名</summary>
    public string monsterName = string.Empty;

    /// <summary>技能队列</summary>
    public List<MonsterSkill> skillList = new List<MonsterSkill>();

    /// <summary>Spine 动画名</summary>
    public string spineFileName = string.Empty;


    // Start is called before the first frame update
    void Start()
    {
        this.type = ActorType.Monster;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public MonsterActor() { }
    public MonsterActor(
        int _id,
        string _name,
        List<int> _skillList,
        string _spineFileName
    ) {
        this.id = _id;
        this.monsterName = _name;
        this.spineFileName = _spineFileName;

        foreach (int item in _skillList)
        {
            MonsterSkillsData nowSkillData = MonsterSkillsData.dataList.Find(t => t.monsterSkill_Id == item);

            this.skillList.Add(nowSkillData.CreateMe());
        }
    }

    public new void EndMyRound()
    {
        this.roundNum--;
        if(this.roundNum <= 0)
        {
            Destroy(this);
            ControlManager.instance.monsterActor = null;
            return;
        }
        this.OnRoundEnd();
    }

    public new void ActionTodo()
    {
        if(this.skillList.Count > 0)
        {
            int skillIndex = Random.Range(0, this.skillList.Count);
            this.skillList[skillIndex].UseSkill(ControlManager.instance.playerActor, ControlManager.instance.monsterActor);
        }
    }
}
