using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISSLevelSelect : MonoBehaviour
{
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
                    SceneList.Add(child.gameObject);
                }
            }
        }
        
        SceneList[DataManager.chosenSceneIndex].SetActive(true);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
