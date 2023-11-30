using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    Text highscore;
    // Start is called before the first frame update
    void Start()
    {
        highscore = GetComponent<Text>();
        highscoreDisplay();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void highscoreDisplay()
    {
        highscore.text = $"Game Over \nYour Score was: " + EnemyHealth.score;
    }
}
