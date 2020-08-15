using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void BuffHandler(Actor _actor);
public delegate void BuffValueChangeHandler(Actor _actor, ref int _value);

public class Buff
{ 
    /// <summary> 状态ID </summary>
    public int id = -1;
    /// <summary> 状态名 </summary>
    public string name = string.Empty;
    /// <summary>回合数 </summary>
    public int roundNum = 1;
    /// <summary>依附的ACT</summary>
    public Actor owner;

    public enum BuffType
    {
        Buff, DeBuff
    }
    /// <summary> buff类型</summary>
    public BuffType type = BuffType.Buff;

    /// <summary>
    /// 执行状态枚举
    /// </summary>
    public enum PerformBuffName
    {
        none, stop_Round, effect_Halved, doubling_Effect
    }
    /// <summary>
    /// 执行状态
    /// </summary>
    public PerformBuffName performBuff = PerformBuffName.none;

    /// <summary> buff效果</summary>
    //public BuffHandler buffEffect;
    //public string buffEffectStr;

    /// <summary> Spine Asset 文件名 </summary>
    public string spineFileName = string.Empty;

    /// <summary>
    /// Event 被添加时
    /// </summary>
    public event BuffHandler createdEvent;
    /// <summary>
    /// Event 回合开始时
    /// </summary>
    public event BuffHandler roundStartEvent;
    /// <summary>
    /// Event 回合结束时
    /// </summary>
    public event BuffHandler roundEndEvent;
    /// <summary>
    /// Event 被移除时
    /// </summary>
    public event BuffHandler removeEvent;
    /// <summary>
    /// Event 自然消除时
    /// </summary>
    public event BuffHandler expiredEvent;

    /// <summary>
    /// Event 体力变化时
    /// </summary>
    public event BuffValueChangeHandler staminaChangeEvent;
    /// <summary>
    /// Event san值变化时
    /// </summary>
    public event BuffValueChangeHandler sanChangeEvent;


    public Buff()
    {

        this.SelfEventBind();
    }

    public Buff(BuffData _buffData)
    {
        this.SettingUseBuffData(_buffData);
        this.SelfEventBind();
    }

    public void SettingUseBuffData(BuffData _buffData)
    {
        this.id = _buffData.id;
        this.name = _buffData.name;
        this.type = _buffData.type;
        this.roundNum = _buffData.roundNum;
        this.performBuff = _buffData.performBuffName;
        this.spineFileName = _buffData.spineFileName;
    }


    /// <summary>
    /// 绑定所有自主事件的小方法
    /// </summary>
    private void SelfEventBind()
    {
        this.createdEvent += this._onCreated;
        this.roundStartEvent += this._onRoundStart;
        this.roundEndEvent += this._onRoundEnd;
        this.removeEvent += this._onRemove;
        this.expiredEvent += this._onExpired;
        this.staminaChangeEvent += this._onStaminaChange;
        this.sanChangeEvent += this._onSanChange;
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
        //体力恢复  手牌刷新  状态效果
        GlobalManager.fatigueValues = 5;//也可能不是5
                                        //手牌刷新 还没写
        //回合开始时 调用状态


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
    /// San值变动时执行
    /// </summary>
    /// <param name="_actor">Actor 实例</param>
    /// <param name="_value">需要处理的数值</param>
    public void OnSanChange(Actor _actor, ref int _value)
    {
        this.sanChangeEvent(_actor, ref _value);
    }
    private void _onSanChange(Actor _actor, ref int _value)
    {
        Debug.Log("[Buff] onSanChange: " + _value);
    }

    /// <summary>
    /// 体力变动时执行
    /// </summary>
    /// <param name="_actor">Actor 实例</param>
    /// <param name="_value">需要处理的数值</param>
    public void OnStaminaChange(Actor _actor, ref int _value)
    {
        this.staminaChangeEvent(_actor, ref _value);
    }
    private void _onStaminaChange(Actor _actor, ref int _value)
    {
        Debug.Log("[Buff] onStaminaChange: " + _value);
    }

    /// <summary>
    /// 检查回合计数
    /// </summary>
    /// <param name="_actor">Actor 实例</param>
    public void checkRoundNum(Actor _actor)
    {
        
    }
}
