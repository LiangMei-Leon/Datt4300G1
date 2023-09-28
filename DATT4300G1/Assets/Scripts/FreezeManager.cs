using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeManager : MonoBehaviour
{
    public GameObject note;
    public GameObject countdown;

    private LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        if(GameObject.FindWithTag("LevelManager") != null)
        {
            levelManager = GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        NoteDone();
    }

    void NoteDone()
    {
        if(Input.GetKeyDown(KeyCode.G))
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
