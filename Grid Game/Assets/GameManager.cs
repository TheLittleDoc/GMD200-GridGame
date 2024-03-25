using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //singleton
    public static GameManager instance;
    public static bool isGameOver = false;
    public GameObject[] listOfGreebles;
    public GameObject[] listOfWugs;
    private bool _isPopulated = false;
    private static GameObject _ui;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        //make singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
        GetComponent<AudioSource>().Play();
        isGameOver = false;
        _ui = GameObject.FindGameObjectWithTag("ui");

    }

    private void OnEnable()
    {
        //check scene
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(isGameOver);

        if (SceneManager.GetActiveScene().name == "Integration" && isGameOver == false)
        {
            //if scene is game scene
            //populate board
            StartGame();
        }
        listOfGreebles = GameObject.FindGameObjectsWithTag("Greeble");
        listOfWugs = GameObject.FindGameObjectsWithTag("Wug");
        if(isGameOver == true)
        {
            Debug.Log("Game over!");
            //end game, stop music
            GetComponent<AudioSource>().Stop();
            //lock out input
            //find by tag ui
            transform.GetChild(0).gameObject.SetActive(true);
            Debug.Log("Game over!");
            
        }
        
        
        // count of tag greebles not dead
        // if count is 0, game over
        
        for(int i = 0; i < listOfGreebles.Length; i++)
        {
            Debug.Log(listOfGreebles[i]);
            if (listOfGreebles[i].GetComponent<GamePiece>().thisWeeble.IsDead() == false)
            {
                //remove dead greebles from list
                listOfGreebles[i] = null;
                
            }
        }
        for(int i = 0; i < listOfWugs.Length; i++)
        {
            if (listOfWugs[i].GetComponent<GamePiece>().thisWeeble.IsDead() == false)
            {
                //remove dead wugs from list
                listOfWugs[i] = null;
            }
        }
        
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (listOfGreebles.Length == 0)
            {
                Debug.Log("Wugs win!");
                isGameOver = true;
            } else if(listOfWugs.Length == 0)
            {
                Debug.Log("Greebles win!");
                isGameOver = true;
            }
        }
        
        
        
        Debug.Log("Greebles: " + listOfGreebles.Length + " Wugs: " + listOfWugs.Length);
    }

    void StartGame()
    {
        isGameOver = false;
        listOfGreebles = GameObject.FindGameObjectsWithTag("Greeble");
        listOfWugs = GameObject.FindGameObjectsWithTag("Wug");
        GetComponent<AudioSource>().Play();
    }

    public static void GameOver()
    {
        isGameOver = true;
        _ui.SetActive(true);
        
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        //set active scene
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(0));
        SceneManager.UnloadSceneAsync(1);

    }
}
