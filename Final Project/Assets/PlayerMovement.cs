/*using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    Rigidbody2D rb;

    //Dash
    public bool canDash = true;
    public bool isDashing;
    private float dashingPower = 23f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    [SerializeField] private TrailRenderer tr;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MovementRB(Vector3 vel)
    {
        //transform.position += vel * speed * Time.deltaTime;
        rb.velocity = vel * speed;

    }

    void Update()
    {
        

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
            rb.velocity = new Vector2(transform.localScale.x * dashingPower, transform.localScale.y * dashingPower);
            yield return new WaitForSeconds(dashingTime);
            tr.emitting = false;
            isDashing = false;
            yield return new WaitForSeconds(dashingCooldown);
            canDash = true;


        }
    }

}
*/