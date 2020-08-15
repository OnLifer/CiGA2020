using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerActor : Actor
{
    /// <summary>
    /// San值
    /// </summary>
    public int sanValue = 1;
    /// <summary>
    /// 体力值
    /// </summary>
    public int staminaValue = 5;

    public event ValueChangeHandler sanChangeEvent;
    public event ValueChangeHandler staminaChangeEvent;

    // Start is called before the first frame update
    void Start()
    {
        this.type = ActorType.Player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 受到攻击
    /// </summary>
    /// <param name="_value">攻击的伤害值</param>
    public new void BeHit(int _value)
    {
        this.SanChange(_value);
    }

    /// <summary>
    /// San值变动
    /// </summary>
    /// <param name="_value">变动的数值</param>
    public void SanChange(int _value)
    {
        int oldSanValue = this.sanValue;

        foreach (var item in buffList)
        {
            item.OnSanChange(this, ref _value);
            //PerformBuff.ValueEffectHalf(item.buffEffectStr, value);
        }

        this.sanValue += _value;

        this.sanChangeEvent(sanValue, oldSanValue);
        if (this.sanValue <= 0) this.Death();
    }

    /// <summary>
    /// 体力变动
    /// </summary>
    /// <param name="_value">变动的数值</param>
    public void StaminaChange(int _value)
    {
        int oldStaminaValue = this.staminaValue;

        int newStamina;
        if(this.CheckStaminaChange(_value, out newStamina))
        {
            this.staminaValue = newStamina;
        }
        else
        {
            this.staminaValue = 0;
        }

        this.staminaChangeEvent(this.staminaValue, oldStaminaValue);
    }

    /// <summary>
    /// 对即将进行的体力值变动进行测试 （综合Buff的情况）
    /// </summary>
    /// <param name="_value">变动的数值</param>
    /// <param name="_outStamina">out 计算后的新 stamina</param>
    /// <returns>当前体力是否足够消耗</returns>
    public bool CheckStaminaChange(int _value, out int _outStamina)
    {
        foreach (var item in buffList)
        {
            item.OnStaminaChange(this, ref _value);
            //PerformBuff.ValueEffectHalf(item.buffEffectStr, value);
        }

        _outStamina = this.staminaValue + _value;

        if (_outStamina < 0)
        {
            return false;
        }

        return true;
    }

    public new void Death()
    {
        Debug.Log("啊 我屎了");
    }
}
