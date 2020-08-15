using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterActor : Actor
{
    /// <summary>
    /// 存在回合数
    /// </summary>
    public int roundNum = 1;
    


    // Start is called before the first frame update
    void Start()
    {
        this.type = ActorType.Monster;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
