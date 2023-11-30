using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryDisplay : MonoBehaviour
{
    Text victory;
    private SpriteRenderer capsuleSR;

    // Start is called before the first frame update
    void Start()
    {
        victory = GetComponent<Text>();

        GameObject capsule = GameObject.FindWithTag("Capsule");

        if (capsule != null)
        {
            capsuleSR = capsule.GetComponent<SpriteRenderer>();
        }

        if (DayTracker.dayCounter == 4)
        {
            endGame();
        }


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void endGame()
    {
        victory.text = $"Congratulations! You have completed the 4 Day Challenge and the Tale of Koby!";
    }
}
