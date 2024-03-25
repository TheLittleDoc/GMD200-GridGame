// Programmed by Arija

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    // Start Game
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    // Instructions
    public void QuitGame()
    {
        Debug.Log("Quit game.");
        Application.Quit();
    }

}
