using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public EnemyHealth enemyHealth;


    void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>();



    }

    void OnTriggerEnter2D(Collider2D other)
    {
        enemyHealth.TakeDamage(1);

        if (other.tag == "Boba")
        {

            Destroy(other.gameObject);

        }

    }
}
