using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerDeath;

    public int maxHealth = 5;
    public int currentHealth;



    [SerializeField] HealthBar healthbar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    void Awake()
    {
        healthbar = GetComponent<HealthBar>();

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.F))
        {
            TakeDamage(1);
        }*/
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);

            //Display GameOver


        }
    }
}
