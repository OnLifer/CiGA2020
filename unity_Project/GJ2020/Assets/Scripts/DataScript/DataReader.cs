﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class DataReader : MonoSingleton<DataReader>
{
    //public string monsterDataFileName = string.Empty;

    private void Awake()
    {
        this.GetAllData();
    }

    // Start is called before the first frame update

    // Update is called once per frame

    /// <summary>
    /// 一次加载所有数据
    /// </summary>
    public void GetAllData()
    {
        this.ReadBuffData();

        this.ReadCardsData();

        //this.ReadLevelData();

        this.ReadBackGrounpData();

        this.ReadMonsterSkillData();
        this.ReadMonsterData();
    }

    /// <summary>
    /// 加载所有怪物数据
    /// </summary>
    public void ReadMonsterData()
    {
        StreamReader streamreader = new StreamReader(Application.dataPath + "/StreamingAssets/JsonConfig/monster_Library.json");//读取数据，转换成数据流
        string jsonStr = streamreader.ReadToEnd();
        List<MonsterData> data = JsonConvert.DeserializeObject<List<MonsterData>>(jsonStr);

        foreach (MonsterData item in data)
        {
            LevelData.monsterList.Add(item.start_Order, item.monster_ID);
            Debug.Log(item.ShowString());
        }
        Debug.Log(JsonConvert.SerializeObject(LevelData.monsterList));
    }

    /// <summary>
    /// 加载怪物技能数据
    /// </summary>
    public void ReadMonsterSkillData()
    {
        StreamReader streamreader = new StreamReader(Application.dataPath + "/StreamingAssets/JsonConfig/monsterskill_Library.json");//读取数据，转换成数据流
        string jsonStr = streamreader.ReadToEnd();
        List<MonsterSkillsData> data = JsonConvert.DeserializeObject<List<MonsterSkillsData>>(jsonStr);

        foreach (MonsterSkillsData item in data)
        {
            Debug.Log(item.ShowString());
        }
    }

    /// <summary>
    /// 加载关卡数据
    /// </summary>
    //public void ReadLevelData()
    //{
    //    StreamReader streamreader = new StreamReader(Application.dataPath + "/StreamingAssets/LevelData.json");//读取数据，转换成数据流
    //    string jsonStr = streamreader.ReadToEnd();
    //    //LevelData data = JsonConvert.DeserializeObject<LevelData>(jsonStr);
    //    List<int> data = JsonConvert.DeserializeObject<List<int>>(jsonStr);
    //    LevelData.monsterList = data;
    //}

    /// <summary>
    /// 加载Buff数据
    /// </summary>
    public void ReadBuffData()
    {
        StreamReader streamreader = new StreamReader(Application.dataPath + "/StreamingAssets/JsonConfig/condition_Library.json");//读取数据，转换成数据流
        string jsonStr = streamreader.ReadToEnd();
        List<BuffData> data = JsonConvert.DeserializeObject<List<BuffData>>(jsonStr);

        foreach (BuffData item in data)
        {
            Debug.Log(item.ShowString());
        }
    }

    /// <summary>
    /// 加载Card数据
    /// </summary>
    public void ReadCardsData()
    {
        StreamReader streamreader = new StreamReader(Application.dataPath + "/StreamingAssets/JsonConfig/card_Library.json");//读取数据，转换成数据流
        string jsonStr = streamreader.ReadToEnd();
        List<CardsData> data = JsonConvert.DeserializeObject<List<CardsData>>(jsonStr);

        foreach (CardsData item in data)
        {
            Debug.Log(item.ShowString());
        }
    }

    /// <summary>
    /// 加载背景数据
    /// </summary>
    public void ReadBackGrounpData()
    {
        StreamReader streamreader = new StreamReader(Application.dataPath + "/StreamingAssets/JsonConfig/background_Library.json");//读取数据，转换成数据流
        string jsonStr = streamreader.ReadToEnd();
        List<BackgroundData> data = JsonConvert.DeserializeObject<List<BackgroundData>>(jsonStr);

        foreach (BackgroundData item in data)
        {
            Debug.Log(item.ShowString());
        }
    }
}
