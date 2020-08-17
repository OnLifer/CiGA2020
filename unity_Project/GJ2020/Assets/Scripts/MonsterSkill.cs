using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSkill
{
    public int id = -1;
    public string name = string.Empty;
    /// <summary>施加的buff的id</summary>
    public int buffId = -1;

    public Enum.SubjectToEnum subjectTo = Enum.SubjectToEnum.player;

    public int staminaValue = 0;
    public int sanValue = 0;

    public string spineFileName = string.Empty;

    public MonsterSkill() { }
    public MonsterSkill(
        int _id, 
        string _name, 
        int _buffId, 
        Enum.SubjectToEnum _subjectTo,
        int _staminaValue,
        int _sanValue,
        string _spineFileName
    )
    {
        this.id = _id;
        this.name = _name;
        this.buffId = _buffId;
        this.subjectTo = _subjectTo;
        this.staminaValue = _staminaValue;
        this.sanValue = _sanValue;
        this.spineFileName = _spineFileName;
    }



    /// <summary>
    /// 使用技能
    /// </summary>
    /// <param name="_playerActor">PlayerActor 实例</param>
    /// <param name="_myActor">MonsterActor 实例</param>
    public void UseSkill(PlayerActor _playerActor, MonsterActor _myActor)
    {
        Actor target = _playerActor;
        switch (this.subjectTo)
        {
            case Enum.SubjectToEnum.player:
                target = _playerActor;
                _playerActor.SanChange(this.sanValue);
                _playerActor.StaminaChange(this.staminaValue);
                break;
            case Enum.SubjectToEnum.enemy:
                target = _myActor;

                break;
            default:
                break;
        }

        if (this.buffId > -1)
        {
            BuffCreater.AddBuffToActor(target, this.buffId);
        }

        Debug.Log("[Monster Attck]");
    }
}
