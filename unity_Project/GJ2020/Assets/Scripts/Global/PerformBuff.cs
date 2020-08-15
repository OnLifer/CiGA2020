using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PerformBuff 
{
   public static void ReturnBuffEffect(string str,Buff buff)
    {
        if (str== "stop_Round")
        {
            StopRound(buff);
        }
    }
    private static void StopRound(Buff buff)
    {
        if (buff.owner.name == "Player")
        {
            //跳回合
        }
        else
        {
            // buff.owner.GetComponent<Monster>().round - 1;
        }
    }

    public static int ValueEffectHalf(string str, int value)
    {
        if (str== "effect_Halved")
        {
            return value / 2;
        }
        else if (str == "doubling_Effect")
        {
            return value * 2;
        }
        return value;
    }

}
