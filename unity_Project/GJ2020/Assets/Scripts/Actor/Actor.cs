using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Actor : MonoBehaviour
{
    public enum ActorType
    {
        None, Player, Monster
    }

    #region Inspector
    [SerializeField]
    public ActorType type = ActorType.None;

    public SkeletonAnimation skeletonAnimation = null;
    #endregion

    //[HideInInspector]
    
    /// <summary>Buff列表</summary>
    public List<Buff> buffList = new List<Buff>();
    [HideInInspector]
    /// <summary>待移除的Buff列表</summary>
    private List<Buff> removeBuffList = new List<Buff>();

    [HideInInspector]
    /// <summary>原id</summary>
    public int id = -1;
    [HideInInspector]
    /// <summary>是否可以进行回合</summary>
    public bool roundRun = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 我的回合 执行动作
    /// </summary>
    public void Action()
    {
        this.ActionBeforeRound();
        this.OnRoundStart();
        if (this.roundRun)
        {
            this.ActionTodo();
        }
        else
        {
            this.EndMyRound();
        }


    }

    public virtual void ActionBeforeRound()
    {

    }
    /// <summary>
    /// 用于继承复写的具体行为
    /// </summary>
    public virtual void ActionTodo()
    {
        // todo...
        this.EndMyRound();
    }

    public virtual void ActionAfterRound()
    {
        this.roundRun = false;
    }

    /// <summary>
    /// 结束我的回合
    /// </summary>
    public virtual void EndMyRound()
    {
        this.roundRun = false;
        this.OnRoundEnd();
    }

    #region 事件方法
    /// <summary>
    /// 回合开始时调用
    /// </summary>
    public virtual void OnRoundStart()
    {

        foreach (Buff item in this.buffList)
        {
            item.onRoundStart(this);
        }
    }

    /// <summary>
    /// 回合结束时调用
    /// </summary>
    public virtual void OnRoundEnd()
    {
        foreach (Buff item in this.buffList)
        {
            item.onRoundEnd(this);
        }

        foreach (Buff item in this.removeBuffList)
        {
            //this.ReadyToRemoveBuff(item);
            this.buffList.Remove(item);
        }

        this.removeBuffList.Clear();

        this.ActionAfterRound();

        this.RoundEndToNextRound();
    }

    public void RoundEndToNextRound()
    {
        ControlManager.instance.NextRound();
    }

    #region Buff方法
    /// <summary>
    /// 添加Buff 并自动调用buff.onCreated()
    /// </summary>
    /// <param name="_buff">buff实例</param>
    public void AddBuff(Buff _buff)
    {
        int index = this.buffList.FindIndex(t => t.id == _buff.id);
        if (index >= 0)
        {
            this.buffList[index] = _buff;
        }
        else
        {
            this.buffList.Add(_buff);
        }
        _buff.onCreated(this);
    }

    /// <summary>
    /// 移除buff 并自动调用 buff.remove()
    /// </summary>
    /// <param name="_buff">_buff实例</param>
    public void RemoveBuff(Buff _buff)
    {
        _buff.onRemove(this);
        this.buffList.Remove(_buff);
    }

    /// <summary>
    /// 将待移除的buff放入待回收列表中
    /// </summary>
    /// <param name="_buff">Buff 实例</param>
    public void ReadyToRemoveBuff(Buff _buff)
    {
        this.removeBuffList.Add(_buff);
    }
    #endregion

    /// <summary>
    /// 出现
    /// </summary>
    public void Emerge()
    {

    }

    /// <summary>
    /// 攻击
    /// </summary>
    public void Attack()
    {

    }

    /// <summary>
    /// 被击中
    /// </summary>
    public void BeHit(int _value)
    {
        


    }

    /// <summary>
    /// 使用技能
    /// </summary>
    public void UseSkill()
    {

    }

    /// <summary>
    /// 死亡
    /// </summary>
    public void Death()
    {

    }
    #endregion
}
