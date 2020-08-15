using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityScript.Steps;

public class BackgroundData
{
    public static List<BackgroundData> dataList = new List<BackgroundData>();

    public int id_Bg = -1;
    public int bg_San_Minithreshold = 0;
    public string bg_SpineAnime_Name = string.Empty;

    public BackgroundData()
    {
        BackgroundData.dataList.Add(this);
    }

    public void CreateMe()
    {

    }

    public string ShowString()
    {
        return "id: " + this.id_Bg + " san: " + this.bg_San_Minithreshold + " spine: " + this.bg_SpineAnime_Name;
    }

    //public void test()
    //{
    //    Dictionary<string , JsonData> dic =new Dictionary<string, JsonData>();
    //    JsonData model = dic["301"];
    //}

}


//public class JsonData
//{
//    public int bg_San_Minithreshold { get; set; }
//    public string bg_SpineAnime_Name { get; set; }
//}