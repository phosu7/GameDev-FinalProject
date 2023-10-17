using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capsule : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        //Destroy(this.gameObject);
        GetComponent<SpriteRenderer>().color = Color.black;
    }
}
