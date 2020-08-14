using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class NewScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string str = JsonConvert.SerializeObject(new { code = "1", message = "123" });
       // var a=JsonConvert.DeserializeObject<string[]>(str);
        var b=JsonConvert.DeserializeObject<Dictionary<string, object>>(str);

        JsonConvert.DeserializeObject<object>(str);
       // print(a[0]);
       // print(a[1]);
        print(b.Keys.Count);

        foreach (var item in b)
        {
            print(item.Value);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
