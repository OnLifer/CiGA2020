using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager :MonoSingleton<ControlManager>
{
    public int roundCount = 0;
    public PlayerActor playerActor = null;
    public MonsterActor monsterActor = null;

    public List<Card> cardList = new List<Card>();

    /// <summary>
    /// 下一回合
    /// </summary>
    public void NextRound()
    {
        if (this.playerActor.roundRun)
        {
            this.playerActor.Action();
            return;
        }

        if (this.monsterActor.roundRun)
        {
            this.monsterActor.Action();
            return;
        }

        this.roundCount++;
        Debug.Log("[Next Round] " + this.roundCount);

        this.playerActor.roundRun = true;
        this.monsterActor.roundRun = true;
    }



    public void OnCardClick()
    {
        //播放状态动画？

        //敌人受击动画？

        //发生实际效果

        //敌人行动

        //回合结束
    }
}
