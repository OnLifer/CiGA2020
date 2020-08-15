using System.Collections;
using System.Collections.Generic;
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
        foreach (var item in buffList)
        {
            item.OnSanChange(this, ref _value);
            //PerformBuff.ValueEffectHalf(item.buffEffectStr, value);
        }

        this.sanValue += _value;
        if (this.sanValue <= 0) this.Death();
    }

    /// <summary>
    /// 体力变动
    /// </summary>
    /// <param name="_value">变动的数值</param>
    public void StaminaChange(int _value)
    {
        foreach (var item in buffList)
        {
            item.OnStaminaChange(this, ref _value);
            //PerformBuff.ValueEffectHalf(item.buffEffectStr, value);
        }

        this.staminaValue += _value;
    }

    public new void Death()
    {
        Debug.Log("啊 我屎了");
    }
}
