using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.Rendering;

public class capsule : MonoBehaviour
{
    public static event Action OnVictory;



    void Start()
    {


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Destroy(this.gameObject);
        //GetComponent<SpriteRenderer>().color = Color.black;
        //Display Victory
        if (other.tag == "Player")
        {

            OnVictory?.Invoke();
            EnemyHealth.count = 0;
        }
    }



}
