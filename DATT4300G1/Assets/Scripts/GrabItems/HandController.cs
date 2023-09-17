using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;

    public static int item;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
        ItemSelector();
    }

    void Inputs()
    {
        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector3(hInput * speed, vInput * speed, 0);
    }

    void ItemSelector()
    {
        switch(item)
        {
            case 1:
            //Play scenario based off bus card
                Debug.Log("Bus Card Picked Up");
                break;
            
            case 2:
            //Play scenario based off phone
                Debug.Log("Phone Picked Up");
                break;
            
            
            case 3:
            //Play scenario based off ring
                Debug.Log("Ring Picked Up");
                break;
        }
    }
}
