using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalSceneControl : MonoBehaviour
{
    public GameObject scoreboard;
    public ParticleSystem heart;
    public ParticleSystem brokenheart;
    public float interval1 = 1f;
    public float interval2 = 3f;
    public bool goodResult = false;
    public bool badResult = false;
    public bool specialResult = false;
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
            goodResult = true;
        }
            
    }

    private IEnumerator SceneStart()
    {
        yield return new WaitForSeconds(interval1);
        if(goodResult)
        {
            heart.Play();
        }else if(badResult)
        {
            brokenheart.Play();
        }
        if(specialResult)
        {

        }
        yield return new WaitForSeconds(interval2);
        scoreboard.SetActive(true);
        
        yield return null;
    }
}
