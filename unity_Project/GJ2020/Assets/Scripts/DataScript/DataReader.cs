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
        this.readMonsterData();
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
        this.readMonsterData();
        this.readLevelData();
    }

    /// <summary>
    /// 加载所有怪物数据
    /// </summary>
    public void readMonsterData()
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
    /// 加载关卡数据
    /// </summary>
    public void readLevelData()
    {
        StreamReader streamreader = new StreamReader(Application.dataPath + "/StreamingAsset/LevelData.json");//读取数据，转换成数据流
        string jsonStr = streamreader.ReadToEnd();
        LevelData data = JsonConvert.DeserializeObject<LevelData>(jsonStr);
    }
}
