using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BobaCount : MonoBehaviour
{
    Text bobaCount;
    //public ProjectileThrower boba;

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
        if (DayTracker.dayCounter == 1)
        {
            bobaCount.text = $"Boba: {ProjectileThrower.currentBlackBoba}";
        }
        else if (DayTracker.dayCounter == 2)
        {
            bobaCount.text = $"Boba: {ProjectileThrower.currentBlackBoba} \nSnow Boba: {ProjectileThrower.currentBlueBoba}";
        }
        else if (DayTracker.dayCounter == 3)
        {
            bobaCount.text = $"Boba: {ProjectileThrower.currentBlackBoba} \nFire Boba: {ProjectileThrower.currentRedBoba}";
        }
        else if (DayTracker.dayCounter == 4)
        {
            bobaCount.text = $"Boba: {ProjectileThrower.currentBlackBoba} \nSnow Boba: {ProjectileThrower.currentBlueBoba} \nFire Boba: {ProjectileThrower.currentRedBoba}";
        }

    }
}
