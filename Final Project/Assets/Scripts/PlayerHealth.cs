using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Rendering;
using Unity.VisualScripting;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerDeath;

    public int maxHealth = 10;
    public float currentHealth;


    [SerializeField] HealthBar healthbar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        Debug.Log("StartHealth");
    }

    void Awake()
    {
        //healthbar = GetComponent<HealthBar>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
        Debug.Log("Damage");
        if (currentHealth <= 0)
        {

            Destroy(this.gameObject);

            //Display GameOver
            OnPlayerDeath?.Invoke();
            EnemyHealth.count = 0;


        }
    }
}
