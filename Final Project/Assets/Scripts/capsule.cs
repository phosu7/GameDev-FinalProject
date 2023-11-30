using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class capsule : MonoBehaviour
{
    public static event Action OnVictory;

    void OnTriggerEnter2D(Collider2D other)
    {
        //Destroy(this.gameObject);
        //GetComponent<SpriteRenderer>().color = Color.black;
        //Display Victory
        if (other.tag == "Player")
        {
            EnemyHealth.count = 0;
            OnVictory?.Invoke();
        }
    }

}
