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
    [SerializeField]
    public ActorType type = ActorType.None;

    public SkeletonAnimation skeletonAnimation = null;
    public List<Buff> buffList = new List<Buff>();
    private List<Buff> removeBuffList = new List<Buff>();

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
    /// 添加Buff 并自动调用buff.onCreated()
    /// </summary>
    /// <param name="_buff">buff实例</param>
    public void AddBuff(Buff _buff)
    {
        int index = this.buffList.FindIndex(t => t.id == _buff.id);
        if(index >= 0)
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


    #region 事件方法
    /// <summary>
    /// 回合开始时调用
    /// </summary>
    public void OnRoundStart()
    {

        foreach (Buff item in this.buffList)
        {
            item.onRoundStart(this);
        }
    }

    /// <summary>
    /// 回合结束时调用
    /// </summary>
    public void OnRoundEnd()
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
    }

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
