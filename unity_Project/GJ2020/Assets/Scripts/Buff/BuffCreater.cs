using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffCreater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static Buff Create(int _buffId)
    {
        foreach (BuffData item in BuffData.dataList)
        {
            if(item.condition_ID == _buffId)
            {
                Buff buff = item.CreateMe();
                //Buff buff = new Buff(item);
                return buff;
            }
        }

        Debug.LogError("Can't find the Buff in [BuffDataList]");
        return null;
    }

    /// <summary>
    /// 增加新buff到演员
    /// </summary>
    /// <param name="_actor">Actor 实例</param>
    /// <param name="_buffId">Buff Id</param>
    public static void AddBuffToActor(Actor _actor, int _buffId)
    {
        Buff theBuff = BuffCreater.Create(_buffId);

        if (theBuff == null) return;
        _actor.AddBuff(theBuff);
    }
}
