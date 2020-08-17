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
        BuffData data = BuffData.dataList.Find(t => t.condition_ID == _buffId);
        if(data != null)
        {
            Buff buff = data.CreateMe();
            return buff;
        }

        Debug.LogWarning("Can't find the Buff in [BuffDataList]");
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
