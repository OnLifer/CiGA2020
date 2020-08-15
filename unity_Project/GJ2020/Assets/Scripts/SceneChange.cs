using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;

public class SceneChange :MonoBehaviour 
{
    public int ID;
    /// <summary>丧阈值 </summary>
    public int sanThreshold;

    public string imagePath;

    public string spineActionName;



    public SkeletonAnimation ske;

    [SerializeField]
     float timer;
    [SerializeField]
     float timed=0.5f;

    public void Start()
    {
        ske = GetComponent<SkeletonAnimation>();
        ControlManager.instance.playerActor.sanChangeEvent += ChangeSceneSpine;

    }

    public void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.K))
        {
            ControlManager.instance.playerActor.SanChange(-26);
            print(ControlManager.instance.playerActor.sanValue);
        }
        if (change)
        {
            Change();
        }
    }

    bool change=false;
 

    int anim=1;
    public void ChangeSceneSpine(int san,int nul)
    {
        int temp=0;
        if (san>=75)
        {
            temp = 1;
        }else 
        if (san >= 50&& san < 75)
        {
            temp = 2;
       
        }
        else
        if (san >= 25 && san < 50)
        {
            temp = 3;
     
        }
        else
        if (san > 0 && san < 25)
        {
            temp = 4;
           
        }
        else
        if (san <= 0)
        {
            temp = 5;
        }

        if (temp!=anim&&temp!=0)
        {
            change = true;
            anim = temp;
            ske.AnimationState.SetAnimation(0, "zhuanchang", true);
        }

        
    }

    private void Change()
    {
        if (timer>=timed)
        {
            timer = 0;
            //ske.AnimationName = "beijing" + anim;
            ske.AnimationState.SetAnimation(0, "beijing" + anim, true);
            change = false;
        }
        else
        {
            timer += Time.deltaTime;
        }
        
    }
}
