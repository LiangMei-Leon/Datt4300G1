using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private SceneSquence sceneManager;
    private Slider slider;
    private float time = 0f;
    public float startingTime = 10f;

//==============================================================
   
    void Start()
    {
        sceneManager = GameObject.FindWithTag("SceneManager").GetComponent<SceneSquence>();

        slider = GetComponent<Slider>();
        slider.maxValue = startingTime;
        time = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        TimeDown();
    }

//==============================================================


    void TimeDown()
    {
        if(time > 0)
        {
            time -= Time.deltaTime;
            slider.value = time;
        }
        else if(time <= 0)
        {
            time = startingTime;
            slider.value = time;
            sceneManager.NextScene();
        }
    }
}
