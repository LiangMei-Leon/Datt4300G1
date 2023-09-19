using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int numOfScenes;
    public float freezeTimeBetweenScenes = 2f;
    public int currentSceneIndex = 0;
    private List<GameObject> SceneList = new List<GameObject>();
    private Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.FindWithTag("Timer").GetComponent<Timer>();

        Transform[] childArray = this.GetComponentsInChildren<Transform>(true);
        foreach (Transform child in childArray)
        {
            if (child != this.transform)
            {
                if (child.parent == this.transform)
                {
                    SceneList.Add(child.gameObject);
                }
            }
        }
        numOfScenes = SceneList.Count;
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
            timer.skipSlider(1f);
        }
    }

    public IEnumerator NextScene()
    {
        if (currentSceneIndex < numOfScenes)
        {
            if (currentSceneIndex != 0)
            {
                CloseScene(currentSceneIndex - 1);
                yield return new WaitForSeconds(freezeTimeBetweenScenes);
            }

            timer.freeze = false;
            timer.duration = getDurationOfScene(currentSceneIndex);
            timer.setSlider(timer.duration);
            PlayScene(currentSceneIndex);
            currentSceneIndex++;
        }else{
            Debug.Log("No more regular scene left...");
            yield return null;
        }

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

    private float getDurationOfScene(int index){
        SceneControl sceneControl = SceneList[index].GetComponent<SceneControl>();
        return sceneControl.myDuration;
    }
}
