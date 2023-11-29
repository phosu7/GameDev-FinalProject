using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{

    ProjectileThrower projectileThrower;
    //[SerializeField] PlayerMovement playerMovement;
    Vector2 moveDirection;
    Vector2 mousePosition;
    [SerializeField] float speed = 5f;
    Rigidbody2D rb;


    //Dash
    public bool canDash = true;
    public bool isDashing;
    private float dashingPower = 23f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 0.5f;
    [SerializeField] private TrailRenderer tr;



    public int karenDeaths;



    void Awake()
    {
        projectileThrower = GetComponent<ProjectileThrower>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        karenDeaths = 0;
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

        //Player moving with mouse
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;

    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        //Player mouse movement
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //So player doesn't move while dashing
        if (isDashing)
        {
            return;
        }

        //Projectile
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            projectileThrower.Throw(Camera.main.ScreenToWorldPoint(Input.mousePosition), 1);
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

    public void karenCounter(int karen)
    {
        karenDeaths += karen;

        if (karenDeaths >= 5)
        {
            Debug.Log("Vicotry");

        }

    }


}
