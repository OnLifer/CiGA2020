using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff
{
    public bool roundRun = true;

    /// <summary> 状态ID </summary>
    public int id = -1;
    /// <summary> 状态名 </summary>
    public string name = string.Empty;
    /// <summary>回合数 </summary>
    public int roundNum = 1;

    /// <summary>丧值</summary>
    public int sanValue = 0;

    /// <summary>消耗体力值</summary>
    public int staminaValue = 0;

    /// <summary>依附的ACT</summary>
    public Actor owner;

    public enum BuffType
    {
        buff, deBuff
    }
    /// <summary> buff类型</summary>
    public BuffType type = BuffType.buff;

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

    /// <summary> 图片文件名 </summary>
    public string imageFileName = string.Empty;

    #region 事件属性
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
    #endregion

    public Buff()
    {

        this.SelfEventBind();
    }

    public Buff(BuffData _buffData)
    {
        this.SettingUseBuffData(_buffData);
        this.SelfEventBind();
    }

    public Buff(
        int _id,
        string _name,
        Buff.BuffType _type,
        int _roundNum,
        bool _bool_Now,
        bool _bool_EveryRound,
        int _energy_ChangeVal,
        int _san_ChangeVal,
        PerformBuffName _performBuff,
        string _spineFileName,
        string _imageFileName
    )
    {
        this.id = _id;
        this.name = _name;
        this.type = _type;
        this.roundNum = _roundNum;
        this.performBuff = _performBuff;
        this.spineFileName = _spineFileName;
        this.imageFileName = _imageFileName;

        this.staminaValue = _energy_ChangeVal;
        this.sanValue = _san_ChangeVal;

        if (_bool_Now) this.createdEvent += this.ChangePlayerActorValueOnce;
        if (_bool_EveryRound)
        {
            this.roundEndEvent += this.ChangePlayerActorValue;
        }
        else
        {
            this.expiredEvent += this.ChangePlayerActorValue;
        }

        switch (_performBuff)
        {
            case PerformBuffName.stop_Round:
                this.roundStartEvent += this.PerformStopRound;
                break;
            case PerformBuffName.effect_Halved:
                this.sanChangeEvent += this.PerformEffectHalved;
                this.staminaChangeEvent += this.PerformEffectHalved;
                break;
            case PerformBuffName.doubling_Effect:
                this.sanChangeEvent += this.PerformDoublingEffect;
                this.staminaChangeEvent += this.PerformDoublingEffect;
                break;
            case PerformBuffName.none:
            default:
                break;
        }
    }

    public void SettingUseBuffData(BuffData _buffData)
    {
        //this.id = _buffData.id;
        //this.name = _buffData.name;
        //this.type = _buffData.type;
        //this.roundNum = _buffData.roundNum;
        //this.performBuff = _buffData.performBuffName;
        //this.spineFileName = _buffData.spineFileName;
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


    #region 各事件的公共方法与私有方法
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
        this.roundRun = true;
        if(this.roundRun) this.roundStartEvent(_actor);
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
        if (this.roundRun) this.roundEndEvent(_actor);
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
    #endregion

    /// <summary>
    /// 检查回合计数
    /// </summary>
    /// <param name="_actor">Actor 实例</param>
    public void checkRoundNum(Actor _actor)
    {
        
    }


    /// <summary>
    /// 委托方法 更改PlayerActor的数值 并将roundRun置false
    /// </summary>
    /// <param name="_actor"></param>
    public void ChangePlayerActorValueOnce(Actor _actor)
    {
        ControlManager.instance.playerActor.SanChange(this.sanValue);
        ControlManager.instance.playerActor.StaminaChange(this.staminaValue);

        //if (typeof(PlayerActor) == _actor.GetType())
        //{
        //    PlayerActor playerActor = _actor as PlayerActor;
        //    playerActor.SanChange(this.sanValue);
        //    playerActor.StaminaChange(this.staminaValue);
        //}
        this.roundRun = false;
    }

    /// <summary>
    /// 委托方法 更改PlayerActor的数值 
    /// </summary>
    /// <param name="_actor"></param>
    public void ChangePlayerActorValue(Actor _actor)
    {
        ControlManager.instance.playerActor.SanChange(this.sanValue);
        ControlManager.instance.playerActor.StaminaChange(this.staminaValue);
    }

    public void PerformStopRound(Actor _actor)
    {
        _actor.roundRun = false;
    }

    /// <summary>
    /// 委托方法 效果减半
    /// </summary>
    /// <param name="_actor"></param>
    /// <param name="_value"></param>
    public void PerformEffectHalved(Actor _actor, ref int _value)
    {
        _value /= 2;
    }

    /// <summary>
    /// 委托方法 效果减半
    /// </summary>
    /// <param name="_actor"></param>
    /// <param name="_value"></param>
    public void PerformDoublingEffect(Actor _actor, ref int _value)
    {
        _value *= 2;
    }

}
