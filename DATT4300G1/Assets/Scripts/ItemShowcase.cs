using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShowcase : MonoBehaviour
{
    private List<GameObject> itemList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        Transform[] childArray = this.GetComponentsInChildren<Transform>(true);
        foreach (Transform child in childArray)
        {
            if (child != this.transform)
            {
                itemList.Add(child.gameObject);
            }
        }

        foreach (GameObject item in itemList)
        {
            Debug.Log(item.name);
            Debug.Log(DataManager.itemChosen);
            if (DataManager.itemChosen != "null")
            {
                if (DataManager.itemChosen == item.name)
                {
                    item.SetActive(true);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
