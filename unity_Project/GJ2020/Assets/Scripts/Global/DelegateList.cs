using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Buff事件委托
/// </summary>
/// <param name="_actor">目标 Actor 实例</param>
public delegate void BuffHandler(Actor _actor);

/// <summary>
/// Buff 演员值变动委托
/// </summary>
/// <param name="_actor">目标 Actor 实例</param>
/// <param name="_value">变动的值</param>
public delegate void BuffValueChangeHandler(Actor _actor, ref int _value);

/// <summary>
/// 数值变动委托
/// </summary>
/// <param name="_now">当前的值</param>
/// <param name="_old">变动前的值</param>
public delegate void ValueChange(int _now, int _old);