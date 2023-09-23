using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalSceneControl : MonoBehaviour
{
    public GameObject scoreboard;
    public float interval1 = 1f;
    public float interval2 = 3f;
    [SerializeField] private TextMeshProUGUI dialogueText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SceneStart());
    }

    // Update is called once per frame
    void Update()
    {
        if(DataManager.chosenSceneIndex == 0 && DataManager.itemChosen == "Ring")
        {
            dialogueText.text = "changed";
        }
            
    }

    private IEnumerator SceneStart()
    {
        yield return new WaitForSeconds(interval1);
        //play vfx
        yield return new WaitForSeconds(interval2);
        scoreboard.SetActive(true);
        
        yield return null;
    }
}
