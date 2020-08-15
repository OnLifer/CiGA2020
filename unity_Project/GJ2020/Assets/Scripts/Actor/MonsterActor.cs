using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterActor : Actor
{
    /// <summary>
    /// 存在回合数
    /// </summary>
    public int roundNum = 1;
    public List<MonsterSkill> skillList = new List<MonsterSkill>();


    // Start is called before the first frame update
    void Start()
    {
        this.type = ActorType.Monster;
    }

    // Update is called once per frame
    void Update()
    {
        
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
