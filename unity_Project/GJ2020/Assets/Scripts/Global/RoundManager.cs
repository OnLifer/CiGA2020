﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public static int roundCount = 0;
    public static RoundManager self = null;

    public Actor playerActor = null;
    public Actor monsterActor = null;


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
        if(this.playerActor != null)
        {
            this.playerActor.OnRoundEnd();
        }

        if(this.monsterActor != null)
        {
            this.playerActor.OnRoundEnd();
        }

        this.NewRound();
    }

    public void NewRound()
    {
        RoundManager.roundCount++;
        Debug.Log("[New Round] " + RoundManager.roundCount);

        if (this.playerActor != null)
        {
            this.playerActor.OnRoundStart();
        }

        if (this.monsterActor != null)
        {
            this.playerActor.OnRoundStart();
        }
    }
}