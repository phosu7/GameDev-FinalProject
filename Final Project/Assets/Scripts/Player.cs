using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    ProjectileThrower projectileThrower;
    //[SerializeField] PlayerMovement playerMovement;
    Vector2 moveDirection;
    [SerializeField] float speed = 5f;
    Rigidbody2D rb;

    //Dash
    public bool canDash = true;
    public bool isDashing;
    private float dashingPower = 23f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 0.5f;
    [SerializeField] private TrailRenderer tr;

    void Awake()
    {
        projectileThrower = GetComponent<ProjectileThrower>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

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
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        //So player doesn't move while dashing
        if (isDashing)
        {
            return;
        }

        //Projectile
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            projectileThrower.Throw(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }

        //Dash
        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            Dash();

        }

        moveDirection = new Vector2(moveX, moveY).normalized;


    }

    public void MovementRB(Vector3 vel)
    {
        //transform.position += vel * speed * Time.deltaTime;
        rb.velocity = vel * speed;

    }

    //Dash method
    public void Dash()
    {
        StartCoroutine(DashRoutine());

        IEnumerator DashRoutine()
        {
            canDash = false;
            isDashing = true;
            //float originalGravity = rb.gravityScale;
            //rb.gravityScale = 0f;
            rb.velocity = new Vector2(moveDirection.x * dashingPower, moveDirection.y * dashingPower);
            yield return new WaitForSeconds(dashingTime);
            tr.emitting = false;
            isDashing = false;
            yield return new WaitForSeconds(dashingCooldown);
            canDash = true;


        }
    }

}
