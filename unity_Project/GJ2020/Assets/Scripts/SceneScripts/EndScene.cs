using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    // Start is called before the first frame update
    float timer;
    float timed=3;

    private void Update()
    {
        if (timer>=timed)
        {
            timer = 0;
            SceneManager.LoadScene("StartScene");
        }
    }
}
