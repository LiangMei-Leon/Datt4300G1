using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeManager : MonoBehaviour
{
    public GameObject note;
    public GameObject countdown;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        NoteDone();
    }

    void NoteDone()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            note.SetActive(false);
            PlayCountDown();
        }
    }

    void PlayCountDown()
    {
        countdown.SetActive(true);
    }
}
