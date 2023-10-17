using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

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
            TakeDamage(1);

        }

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        floatingHB.UpdateHealthBar(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
