using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoSingleton<RoundManager>
{
    public static int roundCount = 0;
    public static RoundManager self = null;

    public PlayerActor playerActor = null;
    public MonsterActor monsterActor = null;


    //void OnValidate() {
    //    findobject
    //}

    private void Awake()
    {
        RoundManager.self = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(playerActor != null)
        {
            Buff newBuff = new Buff();
            newBuff.roundNum = 3;
            newBuff.roundStartEvent += this.testBuffEvent;
            playerActor.AddBuff(newBuff);
        }
    }

    public void testBuffEvent(Actor _actor)
    {
        Debug.Log("[Buff Round]");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextRound()
    {
        ControlManager.instance.NextRound();

        //if (playerActor.roundRun)
        //{
        //    playerActor.Action();
        //    return;
        //}

        //if (monsterActor.roundRun)
        //{
        //    monsterActor.Action();
        //    return;
        //}

        //RoundManager.roundCount++;
        //Debug.Log("[Next Round] " + RoundManager.roundCount);

        //playerActor.roundRun = true;
        //monsterActor.roundRun = true;
    }

    //public void NextRound()
    //{
    //    RoundManager.roundCount++;
    //    Debug.Log("[Next Round] " + RoundManager.roundCount);

    //    if (this.playerActor != null)
    //    {
    //        this.playerActor.OnRoundEnd();
    //        this.playerActor.OnRoundStart();
    //    }

    //    if(this.monsterActor != null)
    //    {
    //        this.playerActor.OnRoundEnd();
    //        this.playerActor.OnRoundStart();
    //    }

    //    this.NewRound();
    //}

    

    //public void NewRound()
    //{
    //    if (this.playerActor != null)
    //    {
    //        this.playerActor.OnRoundStart();
    //    }

    //    if (this.monsterActor != null)
    //    {
    //        this.playerActor.OnRoundStart();
    //    }
    //}
}
