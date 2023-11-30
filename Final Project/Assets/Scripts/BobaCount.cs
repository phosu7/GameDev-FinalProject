using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BobaCount : MonoBehaviour
{
    Text bobaCount;
    public ProjectileThrower boba;

    int levelIndex;

    // Start is called before the first frame update
    void Start()
    {
        levelIndex = DayTracker.Instance.levelIndex;

        bobaCount = GetComponent<Text>();
        UpdateBobaCount();

    }

    // Update is called once per frame
    void Update()
    {
        UpdateBobaCount();
    }

    public void UpdateBobaCount()
    {
        if (levelIndex == 1)
        {
            bobaCount.text = $"Boba: {boba.currentBoba}";
        }
        else if (levelIndex == 2)
        {
            bobaCount.text = $"Boba: {boba.currentBoba} \nSnow Boba: 0";
        }

    }
}
