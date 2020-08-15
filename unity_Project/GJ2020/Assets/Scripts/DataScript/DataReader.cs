using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class DataReader : MonoBehaviour
{
    //public string monsterDataFileName = string.Empty;

    // Start is called before the first frame update
    void Start()
    {
        this.ReadMonsterData();
        this.ReadBackGrounpData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 一次加载所有数据
    /// </summary>
    public void GetAllData()
    {
        this.ReadBuffData();

        this.ReadCardsData();

        this.ReadLevelData();

        this.ReadBackGrounpData();

        this.ReadMonsterData();
        this.ReadMonsterSkillData();
    }

    /// <summary>
    /// 加载所有怪物数据
    /// </summary>
    public void ReadMonsterData()
    {
        StreamReader streamreader = new StreamReader(Application.dataPath + "/StreamingAsset/MonsterData.json");//读取数据，转换成数据流
        string jsonStr = streamreader.ReadToEnd();
        List<MonsterData> data = JsonConvert.DeserializeObject<List<MonsterData>>(jsonStr);

        foreach (MonsterData item in data)
        {
            Debug.Log(item.toString());
        }
    }

    /// <summary>
    /// 加载怪物技能数据
    /// </summary>
    public void ReadMonsterSkillData()
    {

    }

    /// <summary>
    /// 加载关卡数据
    /// </summary>
    public void ReadLevelData()
    {
        StreamReader streamreader = new StreamReader(Application.dataPath + "/StreamingAsset/LevelData.json");//读取数据，转换成数据流
        string jsonStr = streamreader.ReadToEnd();
        //LevelData data = JsonConvert.DeserializeObject<LevelData>(jsonStr);
        List<int> data = JsonConvert.DeserializeObject<List<int>>(jsonStr);
        LevelData.monsterList = data;
    }

    /// <summary>
    /// 加载Buff数据
    /// </summary>
    public void ReadBuffData()
    {
        StreamReader streamreader = new StreamReader(Application.dataPath + "/StreamingAsset/LevelData.json");//读取数据，转换成数据流
        string jsonStr = streamreader.ReadToEnd();
        BuffData data = JsonConvert.DeserializeObject<BuffData>(jsonStr);
    }

    /// <summary>
    /// 加载Card数据
    /// </summary>
    public void ReadCardsData()
    {

    }

    /// <summary>
    /// 加载背景数据
    /// </summary>
    public void ReadBackGrounpData()
    {
        StreamReader streamreader = new StreamReader(Application.dataPath + "/StreamingAsset/JsonConfig/background_Library.json");//读取数据，转换成数据流
        string jsonStr = streamreader.ReadToEnd();
        List<BackgroundData> data = JsonConvert.DeserializeObject<List<BackgroundData>>(jsonStr);

        foreach (BackgroundData item in data)
        {
            Debug.Log(item.ShowString());
        }
    }
}
