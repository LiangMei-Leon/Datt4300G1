using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public static DataManager gameData { get; private set; }

    public static int chosenSceneIndex = 0;
    public static string itemChosen = "null";
    public static bool a1unlocked = false;
    public static bool a2unlocked = false;
    public static bool a3unlocked = false;
    public static bool a4unlocked = false;
    //private LevelManager levelManager;
    // Start is called before the first frame update
    private void Awake()
    {
        if (gameData == null)
        {
            gameData = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // if(GameObject.FindWithTag("LevelManager") != null)
        // {
        //     levelManager = GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>();
        // }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && SceneManager.GetActiveScene().name == "GameScene" && !GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>().skipUsed)
        {
            GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>().skipUsed = true;
            chosenSceneIndex = GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>().currentSceneIndex - 1;
            SceneManager.LoadScene("ItemSelectScene");
        }

        // if(itemChosen != null)
        // {
        //     Debug.Log(itemChosen.name);
        // }
    }
}
