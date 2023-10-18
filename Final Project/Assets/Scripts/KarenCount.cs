using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KarenCount : MonoBehaviour
{
    Text karenCount;
    //public EnemyHealth enemyHealth;


    void Start()
    {
        karenCount = GetComponent<Text>();
        UpdateKarenDeaths();

    }

    void Update()
    {
        UpdateKarenDeaths();

    }

    public void UpdateKarenDeaths()
    {
        karenCount.text = $"Karens: {EnemyHealth.count} ";
    }
}
