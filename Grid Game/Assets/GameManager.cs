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
    [SerializeField] private GameObject _ui;
    
    
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
        
    }

    private void OnEnable()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        listOfGreebles = GameObject.FindGameObjectsWithTag("Greeble");
        listOfWugs = GameObject.FindGameObjectsWithTag("Wug");
        
        
        
        // count of tag greebles not dead
        // if count is 0, game over
        if (isGameOver)
        {
            //end game, stop music
            GetComponent<AudioSource>().Stop();
            //lock out input
            //find by tag ui
            _ui.SetActive(true);
            
            return;
        }
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
        if (listOfGreebles.Length == 0)
        {
            Debug.Log("Wugs win!");
            isGameOver = true;
        } else if(listOfWugs.Length == 0)
        {
            Debug.Log("Greebles win!");
            isGameOver = true;
        }
        
        Debug.Log("Greebles: " + listOfGreebles.Length + " Wugs: " + listOfWugs.Length);
    }

    void StartGame()
    {
        isGameOver = false;
        listOfGreebles = GameObject.FindGameObjectsWithTag("Greeble");
        listOfWugs = GameObject.FindGameObjectsWithTag("Wug");
    }

    void GameOver()
    {
        isGameOver = true;
        
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        //set active scene
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(0));
        
    }
}
