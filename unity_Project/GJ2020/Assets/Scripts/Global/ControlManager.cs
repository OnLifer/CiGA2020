using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager :MonoSingleton<ControlManager>
{
    /// <summary>当前回合数</summary>
    public int roundCount = 0;

    /// <summary>当前怪物序号</summary>
    public int nowMonsterIndex = 0;

    /// <summary>玩家演员</summary>
    public PlayerActor playerActor = null;
    /// <summary>怪物演员</summary>
    public MonsterActor monsterActor = null;

    /// <summary>手牌列表</summary>
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

    public void CreateNewMonster()
    {
        this.nowMonsterIndex++;
        //LevelData.monsterList
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
