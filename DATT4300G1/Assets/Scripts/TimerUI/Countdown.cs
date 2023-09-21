using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    private LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        if(GameObject.FindWithTag("LevelManager") != null)
        {
            levelManager = GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetActiveFalse()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        levelManager.StartCoroutine(levelManager.NextScene());
    }
}
