using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    [SerializeField] EnemyHealth enemyHealth;
    [SerializeField] PlayerHealth playerHealth;

    //Follow target
    [SerializeField] float moveSpeed = 5f;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;




    void Awake()
    {
        //enemyHealth = GetComponent<EnemyHealth>();
        rb = GetComponent<Rigidbody2D>();
        //playerHealth = GetComponent<PlayerHealth>();
    }

    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            moveDirection = direction;
        }

    }

    void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }

    }


    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.tag == "Boba")
        {
            enemyHealth.TakeDamage(1);
            Destroy(other.gameObject);

        }

        if (other.tag == "Player")
        {
            playerHealth.TakeDamage(1);
        }

    }


}
