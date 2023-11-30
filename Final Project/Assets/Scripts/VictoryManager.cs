using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{
    public GameObject victoryMenu;


    //Vicotry Screen
    private void OnEnable()
    {
        capsule.OnVictory += EnableVictoryMenu;
    }

    private void OnDisable()
    {
        capsule.OnVictory -= EnableVictoryMenu;
    }

    public void EnableVictoryMenu()
    {
        victoryMenu.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Day2", LoadSceneMode.Single);
        DayTracker.Instance.ResetData();
    }
}
