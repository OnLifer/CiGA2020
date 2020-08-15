using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowView : MonoBehaviour
{
    float timer;

    float timeEnd=10;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (timer<=timeEnd)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            SceneManager.LoadScene("GameScene");
        }
        
    }
}
