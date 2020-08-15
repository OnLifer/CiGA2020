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


    float timer;
    float timed;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            RoundManager.self.playerActor.sanValue -= 20;
        }
    }

    bool change=false;
    public void Start()
    {
        RoundManager.self.playerActor.sanChangeEvent += ChangeSceneSpine;
        if (change)
        {
            Change();
        }
    }

    int anim=1;
    public void ChangeSceneSpine(int san,int nul)
    {
        int temp=0;
        if (RoundManager.self.playerActor.sanValue>=80)
        {
            temp = 1;
        }
        if (RoundManager.self.playerActor.sanValue >= 60&& RoundManager.self.playerActor.sanValue < 80)
        {
            temp = 2;
       
        }
        if (RoundManager.self.playerActor.sanValue >= 40 && RoundManager.self.playerActor.sanValue < 60)
        {
            temp = 3;
     
        }
        if (RoundManager.self.playerActor.sanValue >= 20 && RoundManager.self.playerActor.sanValue < 40)
        {
            temp = 4;
           
        }
        if (RoundManager.self.playerActor.sanValue >= 0 && RoundManager.self.playerActor.sanValue < 20)
        {
            temp = 5;
        }

        if (temp!=anim&&temp!=0)
        {
            change = true;
        }
        
        
    }

    private void Change()
    {
        if (timer>=timed)
        {
            timer = 0;
            ske.AnimationName = "beijing" + anim;
        }
        else
        {
            timer += Time.deltaTime;
        }
        
    }
}
