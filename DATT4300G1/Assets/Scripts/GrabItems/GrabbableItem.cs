using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableItem : MonoBehaviour
{
    //Customize number to determine type of item
    public int itemNum = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("HandController"))
        {
            Debug.Log("Collided with an item");
            HandController.item = itemNum;
        }
    }
}
