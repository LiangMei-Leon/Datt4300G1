using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    private int numOfScenes;
    public float freezeTimeBetweenScenes = 2f;
    public int currentSceneIndex = 0;
    private List<GameObject> sceneList = new List<GameObject>();
    private Timer timer;
    public GameObject backgrounds;
    private List<GameObject> backgroundList = new List<GameObject>();
    public DialogueSystem dialogues;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject dialogueUI;
    public float dialogueLastTime = 3f;
    private bool skipDialogue = false;
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
                    sceneList.Add(child.gameObject);
                }
            }
        }
        numOfScenes = sceneList.Count;

        Transform[] bgArray = backgrounds.GetComponentsInChildren<Transform>(true);
        foreach (Transform child in bgArray)
        {
            if (child != backgrounds.transform)
            {
                backgroundList.Add(child.gameObject);
            }
        }
        numOfScenes = sceneList.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            timer.skipSlider(1f);
            /*  
                this is for forcing translation object to stop continue moving in
                because when we cut the time, it is possible that there are objects are still moving in
                as in the original function, they will only stop after they reach the destination
                without forcing it to stop, the moveout function would be execuated while the object is still moving in
                result into object freezing there. This will force them to stop whenever the player press F.

                Side Notes: the reason why rotating ones don't have this problem is that they share the rotating variable,
                and each of them (here we look at rotateOut) will only being called if (!rotating) is true. Since the object is rotating,
                the rotateOut will not be started until the rotateIn finish and set rotating to false.

                is it possible to fix moving bugs with this way too? No for now because their code rely on Update() so it can't be fixed that way without rewriting their function
            */
            if (currentSceneIndex != 0)
            {
                SceneControl sceneControl = sceneList[currentSceneIndex - 1].GetComponent<SceneControl>();
                sceneControl.ForceStopMoveIn();
            }

            //this is for preventing wired behaviour of the UI, see more in IEnumerator PlayDialogue(...)
            skipDialogue = true;
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
                backgroundList[currentSceneIndex - 1].SetActive(false);
            }

            timer.freeze = false;
            timer.duration = getDurationOfScene(currentSceneIndex);
            timer.setSlider(timer.duration);
            backgroundList[currentSceneIndex].SetActive(true);
            PlayScene(currentSceneIndex);
            currentSceneIndex++;
            //start dialogue of this scene
            dialogueUI.SetActive(true);
            StartCoroutine(PlayDialogue(dialogues.sections[currentSceneIndex - 1]));
        }
        else
        {
            Debug.Log("No more regular scene left...");
            yield return null;
        }
    }
    public void PlayScene(int index)
    {
        SceneControl sceneControl = sceneList[index].GetComponent<SceneControl>();
        sceneControl.StartScene();
    }

    public void CloseScene(int index)
    {
        SceneControl sceneControl = sceneList[index].GetComponent<SceneControl>();
        sceneControl.EndScene();
    }

    private float getDurationOfScene(int index)
    {
        SceneControl sceneControl = sceneList[index].GetComponent<SceneControl>();
        return sceneControl.myDuration;
    }

    public IEnumerator PlayDialogue(DialogueSystem.DialogueSection section)
    {
        foreach (string text in section.dialogue)
        {
            dialogueText.text = text;
            yield return new WaitForSeconds(dialogueLastTime);
        }
        //if the player press F then prevent the dialogueUI being closed
        //since although the new PlayDialogue starts, the previous PlayDialogue is still running and it will eventually
        //call the setactive(false) if we didn't prevent it
        if (!skipDialogue)
            dialogueUI.SetActive(false);
        //reset the bool back here after the old one is finished without closing the UI
        //so that if the player don't skip the new one (current one), the UI will close automatically after finishing all the dialogues.
        skipDialogue = false;
        yield return null;
    }
}
