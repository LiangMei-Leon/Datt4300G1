using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControl : MonoBehaviour
{
    private List<GameObject> translationObjectsList = new List<GameObject>();
    private List<GameObject> rotationObjectsList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
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
        if(Input.GetKeyDown("q")){
            StartScene();
        }

        if(Input.GetKeyDown("e")){
            EndScene();
        }
    }

    public void StartScene()
    {
        foreach (GameObject child in translationObjectsList)
        {
            SceneElements childBehaviour = child.GetComponent<SceneElements>();
            childBehaviour.MoveIn = true;
        }
        foreach (GameObject child in rotationObjectsList)
        {
            SceneElements childBehaviour = child.GetComponent<SceneElements>();
            childBehaviour.RotateIn = true;
        }
    }

    public void EndScene()
    {
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
}
