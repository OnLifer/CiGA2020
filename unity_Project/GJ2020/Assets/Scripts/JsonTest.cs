using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class JsonTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetJsonInfo();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetJsonInfo()//这个方法给按钮注册
    {
        StreamReader streamreader = new StreamReader(Application.dataPath + "/Json/Test.json");//读取数据，转换成数据流
        string jsonStr = streamreader.ReadToEnd();
        Dictionary<string, object> data= JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonStr);
        Debug.Log(data.ToString());
    }
}
