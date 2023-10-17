using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("MainGame");


    }

    public void Quitgame()
    {
        Debug.Log("Quit!!");
        Application.Quit();
    }
}
