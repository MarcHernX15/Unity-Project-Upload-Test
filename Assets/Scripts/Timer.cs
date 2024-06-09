using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    float time;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("timerUI").GetComponent<TextMeshProUGUI>().text = "";
        GameObject.Find("userMessageUI").GetComponent<TextMeshProUGUI>().text = "";
        time = 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        //print("Time:" + time);
        int seconds = (int)(time % 60);
        //print("Time: " + seconds);
        int minutes = (int)(time / 60);
        GameObject.Find("timerUI").GetComponent<TextMeshProUGUI>().text = minutes + ":" + seconds;
        if(time>118)
        {
            GameObject.Find("userMessageUI").GetComponent<TextMeshProUGUI>().text = "Time is Almost Up.";
        }
        if (time > 120)
        {
            //print("TIME UP");
            SceneManager.LoadScene("First Scene");
        }
    }
}
