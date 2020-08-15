using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    #region Inspector
    public Image image = null;

    #endregion

    void OnValidate() {
        if (this.image == null) this.image = GetComponent<Image>();
    }

    //[Header("由创建器创建的属性 回头可能private掉")]
    [HideInInspector]
    /// <summary>id</summary>
    public int id = -1;

    [HideInInspector]
    /// <summary>卡牌名字</summary>
    public string cardName = string.Empty;
    [HideInInspector]
    /// <summary>卡牌描述</summary>
    public string describe = string.Empty;

    [HideInInspector]
    /// <summary>丧值</summary>
    public int sanValue = 0;

    [HideInInspector]
    /// <summary>消耗体力值</summary>
    public int staminaValue = -1;

    [HideInInspector]
    /// <summary>状态id</summary>
    public int buffId = -1;

    [HideInInspector]
    /// <summary>施加对像</summary>
    public Enum.SubjectToEnum subjectTo = Enum.SubjectToEnum.player;

    [HideInInspector]
    /// <summary>变牌触发敌人ID</summary>
    public int changeMonsterId = -1;
    [HideInInspector]
    /// <summary>所变牌ID</summary>
    public int changeCardId = -1;

    [HideInInspector]
    /// <summary>卡图文件名</summary>
    public string imageFileName = string.Empty;

    /// <summary>
    /// 卡牌点击事件
    /// </summary>
    public void OnCardClick()
    {
        this.UseCard();
    }

    /// <summary>
    /// 检查玩家的体力是否足够 综合Buff效果
    /// </summary>
    /// <returns>体力是否足够消耗</returns>
    public bool CheckPlayerStamina()
    {
        bool canChange = ControlManager.instance.playerActor.CheckStaminaChange(this.staminaValue, out int outValue);
        // 判断是否足够变化 可以的话将值修改为新值
        if(canChange) ControlManager.instance.playerActor.staminaValue = outValue;
        return canChange;
    }

    /// <summary>
    /// 使用卡牌
    /// </summary>
    /// <param name="_actor">Actor 实例</param>
    public void UseCard()
    {
        // 判断体力是否足够
        if (!this.CheckPlayerStamina())
        {
            // todo 提示无法使用的相关动作
            return;
        }

        Actor target = this.subjectTo == Enum.SubjectToEnum.enemy ? ControlManager.instance.monsterActor as Actor : ControlManager.instance.playerActor as Actor;

        // 向目标施加buff
        if (this.buffId > -1) BuffCreater.AddBuffToActor(target, this.buffId);

        // 对玩家进行San值变更
        ControlManager.instance.playerActor.SanChange(this.sanValue);

        // 移除卡牌 如果必要的话
        this.RemoveCard();
    }

    //public void 

    /// <summary>
    /// 移除卡牌
    /// </summary>
    public void RemoveCard()
    {
        // 现在是直接销毁对像
        Destroy(this.gameObject);
    }
}
