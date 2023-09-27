using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControl : MonoBehaviour
{
    public float myDuration = 30f;
    private List<GameObject> translationObjectsList = new List<GameObject>();
    private List<GameObject> rotationObjectsList = new List<GameObject>();
    public string myMusic = "null";
    private AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();

        Transform translationSource = this.transform.GetChild(0).GetChild(0);
        Transform[] translationchildArray = translationSource.GetComponentsInChildren<Transform>();
        Transform rotationSource = this.transform.GetChild(1).GetChild(0);
        Transform[] rotationchildArray = rotationSource.GetComponentsInChildren<Transform>();

        foreach (Transform child in translationchildArray)
        {
            if (child != translationSource)
                translationObjectsList.Add(child.gameObject);
        }

        foreach (Transform child in rotationchildArray)
        {
            if (child != rotationSource)
                rotationObjectsList.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown("q"))
        // {
        //     StartScene();
        // }

        // if (Input.GetKeyDown("e"))
        // {
        //     EndScene();
        // }
    }

    public void StartScene()
    {
        if(myMusic != "null")
        {
            audioManager.Play(myMusic);
        }
        
        if (translationObjectsList.Count != 0)
        {
            foreach (GameObject child in translationObjectsList)
            {
                SceneElements childBehaviour = child.GetComponent<SceneElements>();
                childBehaviour.MoveIn = true;
            }
        }

        if (rotationObjectsList.Count != 0)
        {
            foreach (GameObject child in rotationObjectsList)
            {
                SceneElements childBehaviour = child.GetComponent<SceneElements>();
                childBehaviour.RotateIn = true;
            }
        }
    }

    public void EndScene()
    {
        if(myMusic != "null")
        {
            audioManager.Stop(myMusic);
        }

        foreach (GameObject child in translationObjectsList)
        {
            SceneElements childBehaviour = child.GetComponent<SceneElements>();
            childBehaviour.MoveOut = true;
        }
        foreach (GameObject child in rotationObjectsList)
        {
            SceneElements childBehaviour = child.GetComponent<SceneElements>();
            childBehaviour.RotateOut = true;
        }
    }

    public void ForceStopMoveIn()
    {
        foreach (GameObject child in translationObjectsList)
        {
            SceneElements childBehaviour = child.GetComponent<SceneElements>();
            childBehaviour.isMovingIn = false;
            childBehaviour.MoveIn = false;
        }
    }
}
