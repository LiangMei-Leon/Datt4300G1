using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTime : MonoBehaviour
{
    public GameObject noteSystem;
    public GameObject countdownSystem;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        NoteDone();
    }

    void NoteDone()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            noteSystem.SetActive(false);
            PlayCountDown();
            //Time.timeScale = 1;
        }
    }

    void PlayCountDown()
    {
        countdownSystem.SetActive(true);
    }

}
