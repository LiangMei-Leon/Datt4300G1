using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSquence : MonoBehaviour
{
    public int numOfScenes;
    private int currentSceneIndex = 0;
    private List<GameObject> SceneList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        Transform[] childArray = this.GetComponentsInChildren<Transform>(true);
        foreach (Transform child in childArray)
        {
            if (child != this.transform)
            {
                if (child.parent == this.transform)
                {
                    Debug.Log("child.name");
                    SceneList.Add(child.gameObject);
                }
            }
        }

        // foreach (GameObject child in SceneList)
        // {
        //     Debug.Log(child.name);
        // }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            if (currentSceneIndex != 0)
                CloseScene(currentSceneIndex - 1);

            PlayScene(currentSceneIndex);
            currentSceneIndex++;
        }
    }

    public void NextScene()
    {
        if (currentSceneIndex != 0)
            CloseScene(currentSceneIndex - 1);

        PlayScene(currentSceneIndex);
        currentSceneIndex++;
    }
    public void PlayScene(int index)
    {
        SceneControl sceneControl = SceneList[index].GetComponent<SceneControl>();
        sceneControl.StartScene();
    }

    public void CloseScene(int index)
    {
        SceneControl sceneControl = SceneList[index].GetComponent<SceneControl>();
        sceneControl.EndScene();
    }
}
