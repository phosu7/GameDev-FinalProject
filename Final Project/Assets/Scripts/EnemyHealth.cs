using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    [SerializeField] GameObject plank;

    public static int count = 0;


    //public static event Action OnVictory;

    [SerializeField] FloatingHealthBar floatingHB;

    void Awake()
    {
        floatingHB = GetComponentInChildren<FloatingHealthBar>();


    }

    void Start()
    {
        currentHealth = maxHealth;

        floatingHB.UpdateHealthBar(currentHealth, maxHealth);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            //TakeDamage(1);
            //player.karenDeaths += 1;

        }
    }

    void FixedUpdate()
    {

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        floatingHB.UpdateHealthBar(currentHealth, maxHealth);



        if (currentHealth <= 0)
        {
            count++;
            Debug.Log(count);
            if (count == 11)
            {
                Debug.Log("PLANK");
                Destroy(plank);

            }
            Destroy(gameObject);


        }




    }

}
