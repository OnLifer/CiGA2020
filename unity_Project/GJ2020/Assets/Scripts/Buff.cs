using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void BuffHandler(Actor _actor);
public class Buff
{ 
    /// <summary>
    /// 状态ID
    /// </summary>
    public int id = -1;
    /// <summary>
    /// 状态名
    /// </summary>
    public string name = string.Empty;
    /// <summary>
    /// 回合数
    /// </summary>
    public int roundNum = 1;

    public enum BuffType
    {
        Buff, DeBuff
    }
    /// <summary>
    /// buff类型
    /// </summary>
    public BuffType type = BuffType.Buff;

    /// <summary>
    /// Spine Asset 文件名
    /// </summary>
    public string spineFileName = string.Empty;

    public event BuffHandler createdEvent;
    public event BuffHandler roundStartEvent;
    public event BuffHandler roundEndEvent;
    public event BuffHandler removeEvent;
    public event BuffHandler expiredEvent;

    public Buff()
    {

        this.createdEvent += this._onCreated;
        this.roundStartEvent += this._onRoundStart;
        this.roundEndEvent += this._onRoundEnd;
        this.removeEvent += this._onRemove;
        this.expiredEvent += this._onExpired;
    }


    public void onCreated(Actor _actor)
    {
        this.createdEvent(_actor);
    }
    private void _onCreated(Actor _actor)
    {
        Debug.Log("[Buff] onCreated" + this.id);
    }

    /// <summary>
    /// 回合开始时被执行
    /// </summary>
    public void onRoundStart(Actor _actor)
    {
        this.roundStartEvent(_actor);
    }
    private void _onRoundStart(Actor _actor)
    {
        Debug.Log("[Buff] onRoundStart" + this.id);
    }

    /// <summary>
    /// 回合结束时被执行
    /// </summary>
    public void onRoundEnd(Actor _actor)
    {
        this.roundEndEvent(_actor);
    }
    private void _onRoundEnd(Actor _actor)
    {
        Debug.Log("[Buff] onRoundEnd" + this.id);
        this.roundNum--;
        if (this.roundNum <= 0)
        {
            //this.onExpired(_actor);
            this.expiredEvent(_actor);

            //_actor.buffList.Remove(this);
            _actor.ReadyToRemoveBuff(this);
        }
    }

    /// <summary>
    /// 被移除时执行
    /// </summary>
    public void onRemove(Actor _actor)
    {
        this.removeEvent(_actor);
    }
    private void _onRemove(Actor _actor)
    {
        Debug.Log("[Buff] onRemove" + this.id);
    }

    /// <summary>
    /// 在过期时执行
    /// </summary>
    public void onExpired(Actor _actor)
    {
        this.expiredEvent(_actor);
    }
    private void _onExpired(Actor _actor)
    {
        Debug.Log("[Buff] onExpired" + this.id);
    }

    /// <summary>
    /// 检查回合计数
    /// </summary>
    /// <param name="_actor">Actor 实例</param>
    public void checkRoundNum(Actor _actor)
    {
        
    }
}
