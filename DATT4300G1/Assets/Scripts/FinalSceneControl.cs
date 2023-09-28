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
    public GameObject checkmark1;
    public GameObject checkmark2;
    public GameObject checkmark3;
    public GameObject checkmark4;
    public Animator hand1;
    public Animator hand2;
    [SerializeField] private TextMeshProUGUI dialogueText;
    private AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
        audioManager.Stop("BG2");
        audioManager.Stop("BusScene");
        audioManager.Stop("TicketScene");
        audioManager.Stop("RollerCoasterScene");
        audioManager.Stop("LunchScene");
        audioManager.Stop("FireworkScene");
        audioManager.Stop("SwanBoatScene");
        StartCoroutine(SceneStart());
    }

    // Update is called once per frame
    void Update()
    {
        if (DataManager.itemChosen == "null")
        {
            dialogueText.text = "??? Nothing inside? What? It is not a good time to show off your sense of humor or magic tricks! I will give you another chance...";
            badResult = true;
            score = 1f;
        }
        else
        {
            if (DataManager.chosenSceneIndex == 0)
            {
                dialogueText.text = "Really?! Why would you choose to propose this early in the morning while both of us are sleepy?"
                                + " And in a bus station! This is a precious moment for us…You should treat it more seriously. I will give you one more chance…";
                badResult = true;
                score = 1f;

            }
            if (DataManager.chosenSceneIndex == 1)
            {
                if (DataManager.itemChosen == "Ring")
                {
                    dialogueText.text = "I like the ring but I don’t think the moment while we are waiting in the lines is appropriate and romantic for proposing… "
                                    + "I will give you one more chance…";
                    badResult = true;
                    score = 2f;
                }
                else
                {
                    dialogueText.text = "I don’t think the moment while we are waiting in the lines is appropriate and romantic for proposing… I will give you one more chance…";
                    badResult = true;
                    score = 1f;
                }
            }
            if (DataManager.chosenSceneIndex == 2)
            {
                if (DataManager.itemChosen == "Ring")
                {
                    dialogueText.text = "Oh my goodness! I can't believe you did that on a roller coaster! You're amazing! "
                                    + "You really know how to surprise me. This is a moment I'll cherish forever!";
                    goodResult = true;
                    score = 7f;
                    DataManager.a2unlocked = true;
                }
                else if (DataManager.itemChosen == "Shoe")
                {
                    dialogueText.text = "Hahaha, you pulled out my shoes? This is not serious right? "
                                    + "You really know how to keep things interesting but this item for proposals is not formal and appropriate to me.";
                    badResult = true;
                    score = 4f;
                }
                else
                {
                    dialogueText.text = "I like the idea that you were trying to propose during a roller coaster! "
                                    + "You really know how to keep things interesting but this item for proposals is not formal and appropriate to me.";
                    badResult = true;
                    score = 3f;
                }
            }
            if (DataManager.chosenSceneIndex == 3)
            {
                if (DataManager.itemChosen == "Ring")
                {
                    dialogueText.text = "The ring looks amazing! Although being surrounded by trash cans ruined this precious moment a little, overall it is not that bad.";
                    goodResult = true;
                    score = 6f;
                }
                else if (DataManager.itemChosen == "Fly")
                {
                    dialogueText.text = "EWWWWWWW!NO! Are you out of your mind? Don’t you know I hate these little creatures? "
                                    + "And you propose to me with that??? Don’t talk to me anymore this week!";
                    badResult = true;
                    score = 0f;
                    DataManager.a3unlocked = true;
                    specialResult = true;
                }
                else
                {
                    dialogueText.text = "Being surrounded by trash cans has already ruined this precious moment a little, and I don’t like the item you choose for proposal. "
                                    + "Overall it is just a bad idea… I will give you one more chance.";
                    badResult = true;
                    score = 2f;
                }
            }
            if (DataManager.chosenSceneIndex == 4)
            {
                if (DataManager.itemChosen == "Knife")
                {
                    dialogueText.text = "AHHHHHH! What is that shiny and bloody thing?!OMG A KNIFE WITH BLOOD! WHAAAA… (PASSED AWAY) ";
                    badResult = true;
                    score = 0f;
                    DataManager.a4unlocked = true;
                }
                else
                {
                    dialogueText.text = "Is this a joke to you? Propose inside a haunted house which is dark and uncomfortable! "
                                    + "I can barely see what’s inside the box! Remember this is a precious moment for us. Treat it seriously next time!";
                    badResult = true;
                    score = 1f;
                }
            }
            if (DataManager.chosenSceneIndex == 5)
            {
                if (DataManager.itemChosen == "Ring")
                {
                    dialogueText.text = "The view of the lake is amazing and I love the item you pick for me! I've dreamed of a moment like this. You've made it come true! You are so romantic! ";
                    goodResult = true;
                    score = 9f;
                }
                else if (DataManager.itemChosen == "Flower")
                {
                    dialogueText.text = "The view of the lake is amazing and I love the item you pick for me! I've dreamed of a moment like this. You've made it come true! You are so romantic! ";
                    goodResult = true;
                    score = 8f;
                }
                else
                {
                    dialogueText.text = "The view of the lake is amazing but the item you pick for me... Why would you believe it will work? "
                                    + "It ruins my mood. Please pick a better item next time!";
                    badResult = true;
                    score = 5f;
                }
            }
            if (DataManager.chosenSceneIndex == 6)
            {
                if (DataManager.itemChosen == "Ring")
                {
                    dialogueText.text = "With fireworks like these, how could I say anything but yes? I can't believe how perfect this is. You're the love of my life! ";
                    goodResult = true;
                    score = 10f;
                    DataManager.a1unlocked = true;
                }
                else if (DataManager.itemChosen == "Flower")
                {
                    dialogueText.text = "With fireworks like these, how could I say anything but yes? I love flowers but if it is something I can carry forever with you, it would be perfect! ";
                    goodResult = true;
                    score = 9f;
                }
                else if (DataManager.itemChosen == "Bear")
                {
                    dialogueText.text = "With fireworks like these, how could I say anything but yes? I love this toy but if it is something to carry forever with you, it would be perfect! ";
                    goodResult = true;
                    score = 7f;
                }
                else
                {
                    dialogueText.text = "The firework is amazing but what most important is your attitude. The item you pick doesn't tell me that you are serious enough... I will give you another chance!";
                    badResult = true;
                    score = 5f;
                }
            }
        }

        slider.value = score;

        if (DataManager.a1unlocked)
        {
            checkmark1.SetActive(true);
        }
        if (DataManager.a2unlocked)
        {
            checkmark2.SetActive(true);
        }
        if (DataManager.a3unlocked)
        {
            checkmark3.SetActive(true);
        }
        if (DataManager.a4unlocked)
        {
            checkmark4.SetActive(true);
        }
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
            if(DataManager.chosenSceneIndex == 4 && DataManager.itemChosen == "Knife")
            {
                audioManager.Play("Scream");
            }
            hand1.SetTrigger("reject");
            happyface.SetActive(false);
            madface.SetActive(true);
            audioManager.Play("Badresult");
            brokenheart.Play();
        }
        yield return new WaitForSeconds(3f);
        if (specialResult)
        {
            hand2.SetTrigger("angry");
            specialResult = false;
        }
        yield return new WaitForSeconds(interval2 - 3f);
        scoreboard.SetActive(true);

        yield return null;
    }
}
