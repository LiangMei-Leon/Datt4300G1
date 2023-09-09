using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Slider slider;
    private float time = 0f;
    
    public float startingTime = 10f;

//==============================================================
   
    void Start()
    {
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
            //Time UP Condition
            Debug.Log("Time is Up");
        }
    }
}
