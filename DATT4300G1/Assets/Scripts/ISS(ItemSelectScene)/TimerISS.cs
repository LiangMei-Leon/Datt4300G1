using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerISS : MonoBehaviour
{
    private Slider slider;
    private float time = 0f;
    public float duration = 10f;

    public bool freeze = false;

//==============================================================
   
    void Start()
    {
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
        }
    }
}
