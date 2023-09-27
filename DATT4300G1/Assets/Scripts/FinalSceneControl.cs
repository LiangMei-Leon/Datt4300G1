using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FinalSceneControl : MonoBehaviour
{
    public GameObject scoreboard;
    public Slider slider;
    public ParticleSystem heart;
    public ParticleSystem brokenheart;
    public float interval1 = 1f;
    public float interval2 = 10f;
    public bool goodResult = false;
    public bool badResult = false;
    public bool specialResult = false;
    public float score = 0f;
    public GameObject happyface;
    public GameObject madface;
    [SerializeField] private TextMeshProUGUI dialogueText;
    private AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
        audioManager.Stop("BG2");
        StartCoroutine(SceneStart());
    }

    // Update is called once per frame
    void Update()
    {
        if (DataManager.chosenSceneIndex == 0)
        {
            if (DataManager.itemChosen == "Ring")
            {
                dialogueText.text = "changed";
                badResult = true;
                score = 0f;
            }else{
                dialogueText.text = "changed2";
                badResult = true;
                score = 0f;
            }
        }
        if (DataManager.chosenSceneIndex == 1)
        {
            if (DataManager.itemChosen == "Ring")
            {
                dialogueText.text = "changed111";
                badResult = true;
                score = 2f;
            }else{
                dialogueText.text = "changed2";
                badResult = true;
                score = 1f;
            }
        }
        slider.value = score;
    }

    private IEnumerator SceneStart()
    {
        yield return new WaitForSeconds(interval1);
        if (goodResult)
        {
            madface.SetActive(false);
            happyface.SetActive(true);
            audioManager.Play("Goodresult");
            heart.Play();
        }
        else if (badResult)
        {
            happyface.SetActive(false);
            madface.SetActive(true);
            audioManager.Play("Badresult");
            brokenheart.Play();
        }
        if (specialResult)
        {

        }
        yield return new WaitForSeconds(interval2);
        scoreboard.SetActive(true);

        yield return null;
    }
}
