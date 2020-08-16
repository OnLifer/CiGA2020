using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;
using System.Threading;

public class ActorSpine : MonoBehaviour
{
    public SkeletonAnimation ske;

    public string skeName;

    public PlayerActor theActor;

    private void Start()
    {
        ske= GetComponent<SkeletonAnimation>();
        theActor = GetComponent<PlayerActor>();
        StartSpine();
    }


    public void StartSpine()
    {
        ControlManager.instance.playerActor.sanChangeEvent += HurtSpine;
        ske.state.AddAnimation(0, "pose2", false,0);
        ske.state.AddAnimation(0, "pose3", true,0);
    }

    float timer;
    float timed=0.5f;
    bool ishurt;
    public void Update()
    {
        if (ishurt)
        {
            if (timer>timed)
            {
                timer = 0;
                ChangeSke(theActor.sanValue);
                ishurt = false;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }
    public void ChangeSke(int san)
    {
        if (san>=75)
        {
            skeName ="pose3";
            ske.AnimationState.SetAnimation(0, "pose3", true);
        }
        else if (san < 75&&san>=50)
        {
            skeName = "pose4";
            ske.AnimationState.SetAnimation(0, "pose4", true);
        }
        else if (san < 50 && san >= 25)
        {
            skeName = "pose5";
            ske.AnimationState.SetAnimation(0, "pose5", true);
        }
        else if (san < 25 && san>0)
        {
            skeName = "pose6";
            ske.AnimationState.SetAnimation(0, "pose6", true);
        }
        else if (san <=0)
        {
            skeName = "pose7";
            ske.AnimationState.SetAnimation(0, "pose7", true);
        }
    }


    public void HurtSpine(int a=0,int b=0)
    {
        ske.AnimationState.SetAnimation(0, "hurt", false);
        ishurt = true;

    }
}
