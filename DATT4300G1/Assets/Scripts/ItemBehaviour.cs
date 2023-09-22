using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    public Sprite spriteReference;
    private Sprite oldspriteReference;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        oldspriteReference = spriteRenderer.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        DataManager.itemChosen = this.gameObject.name;
        spriteRenderer.sprite = spriteReference;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        spriteRenderer.sprite = oldspriteReference;
        DataManager.itemChosen = "null";
    }
}
