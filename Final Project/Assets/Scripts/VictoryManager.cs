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
        EnemyHealth.count = 0;
        SceneManager.LoadScene("MainMenu");

    }

    public void NextLevelDay2()
    {
        SceneManager.LoadScene("Day2");
        DayTracker.Instance.ResetData();
    }
}
