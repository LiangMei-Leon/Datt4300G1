using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetActiveFalse()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
