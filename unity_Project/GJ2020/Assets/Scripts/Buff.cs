using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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



    /// <summary>
    /// 被创建时执行
    /// </summary>
    public void onCreated()
    {

    }

    /// <summary>
    /// 回合开始时被执行
    /// </summary>
    public void onRoundStart()
    {

    }

    /// <summary>
    /// 回合结束时被执行
    /// </summary>
    public void onRoundEnd()
    {

    }

    /// <summary>
    /// 被移除时执行
    /// </summary>
    public void onRemove()
    {

    }

    /// <summary>
    /// 在过期时执行
    /// </summary>
    public void onExpired()
    {

    }
}
