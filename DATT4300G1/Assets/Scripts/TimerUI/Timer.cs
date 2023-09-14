using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private LevelManager levelManager;
    private Slider slider;
    private float time = 0f;
    public float duration = 10f;

    public bool freeze = false;

//==============================================================
   
    void Start()
    {
        if(GameObject.FindWithTag("LevelManager") != null)
        {
            levelManager = GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>();
        }
       

        slider = GetComponent<Slider>();
        slider.maxValue = duration;
        time = duration;
    }

    // Update is called once per frame
    void Update()
    {
        TimeDown();
    }

//==============================================================


    void TimeDown()
    {
        if(time > 0 && !freeze)
        {
            time -= Time.deltaTime;
            slider.value = time;
        }
        else if(time < 0)
        {
            freeze = true;
            time = 0;
            levelManager.StartCoroutine(levelManager.NextScene());
        }
    }

    public void setSlider(float t){
        time = t;
        slider.maxValue = t;
    }

    public void skipSlider(float t){
        time = t;
        slider.value = t;
    }
}
