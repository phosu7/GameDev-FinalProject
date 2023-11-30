using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    [SerializeField] EnemyHealth enemyHealth;
    // [SerializeField] PlayerHealth playerHealth;
    //public PlayerHealth playerHealth;

    //Follow target
    [SerializeField] float moveSpeed = 2f;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;


    void Awake()
    {
        //enemyHealth = GetComponent<EnemyHealth>();
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        PlayerHealth playerHealth = GetComponent<PlayerHealth>();
        if (this.tag == "BlueKaren")
        {
            moveSpeed = 4f;
            enemyHealth.maxHealth = 6;
        }

        if (this.tag == "RedKaren")
        {
            moveSpeed = 0.75f;
            enemyHealth.maxHealth = 16;
        }

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
            angle = Mathf.Clamp(angle, -0f, 0f);
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

        PlayerHealth playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();


        if (other.tag == "Boba")
        {
            enemyHealth.TakeDamage(1f);
            Destroy(other.gameObject);

        }
        else if (other.tag == "BlueBoba")
        {
            enemyHealth.TakeDamage(0.5f);
            moveSpeed = 1;
            Destroy(other.gameObject);
        }
        else if (other.tag == "RedBoba")
        {
            enemyHealth.TakeDamage(4f);
            Destroy(other.gameObject);
        }

        if (other.tag == "Player" && this.tag == "Enemy")
        {
            playerHealth.TakeDamage(1f);
        }
        else if (other.tag == "Player" && this.tag == "BlueKaren")
        {
            playerHealth.TakeDamage(0.5f);
        }
        else if (other.tag == "Player" && this.tag == "RedKaren")
        {
            playerHealth.TakeDamage(2f);
        }




    }


}
