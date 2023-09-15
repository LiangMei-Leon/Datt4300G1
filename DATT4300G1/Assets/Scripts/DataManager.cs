using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public static DataManager gameData {get; private set;}

    public static int chosenSceneIndex = 0;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            chosenSceneIndex = GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>().currentSceneIndex - 1;
            SceneManager.LoadScene("ItemSelectScene");
        }
    }
}
