using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    ProjectileThrower projectileThrower;
    Rigidbody2D rb;


    void Awake()
    {
        projectileThrower = GetComponent<ProjectileThrower>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 vel = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            vel.y = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            vel.x = -1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            vel.y = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            vel.x = 1;
        }
        MovementRB(vel);


    }

    void Update()
    {
        //Projectile
        if (Input.GetKeyDown(KeyCode.Space))
        {
            projectileThrower.Throw(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }

    }
    void MovementRB(Vector3 vel)
    {
        //transform.position += vel * speed * Time.deltaTime;
        rb.velocity = vel * speed;

    }


}
