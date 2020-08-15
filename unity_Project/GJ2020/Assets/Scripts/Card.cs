using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class Card : MonoBehaviour
{
    #region Inspector

    #endregion

    /// <summary>id</summary>
    public int id = -1;

    /// <summary>卡牌名字</summary>
    public string cardName = string.Empty;
    public string describe = string.Empty;

    /// <summary>丧值</summary>
    public int sanValue;

    /// <summary>消耗体力值</summary>
    public int staminaValue = -1;

    /// <summary>状态id</summary>
    public int buffId = -1;

    /// <summary>施加对像</summary>
    public Enum.SubjectToEnum subjectTo = Enum.SubjectToEnum.player;

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
        bool canChange = RoundManager.self.playerActor.CheckStaminaChange(this.staminaValue, out int outValue);
        // 判断是否足够变化 可以的话将值修改为新值
        if(canChange) RoundManager.self.playerActor.staminaValue = outValue;
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

        Actor target = this.subjectTo == Enum.SubjectToEnum.enemy ? RoundManager.self.monsterActor : RoundManager.self.playerActor;

        // 向目标施加buff
        if (this.buffId > -1) BuffCreater.AddBuffToActor(target, this.buffId);

        // 对玩家进行San值变更
        RoundManager.self.playerActor.SanChange(this.sanValue);

        // 移除卡牌 如果必要的话
        this.RemoveCard();
    }

    /// <summary>
    /// 移除卡牌
    /// </summary>
    public void RemoveCard()
    {
        // 现在是直接销毁对像
        Destroy(this.gameObject);
    }
}
