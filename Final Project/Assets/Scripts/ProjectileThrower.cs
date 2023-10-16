using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class ProjectileThrower : MonoBehaviour
{
    [SerializeField] float pSpeed = 5f;
    public GameObject projectilePrefab;
    public void Throw(Vector3 targetPosition)
    {
        Rigidbody2D projectileRB = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
        targetPosition.z = 0;
        Vector3 direction = (targetPosition - transform.position).normalized;

        projectileRB.velocity = direction * pSpeed;

        // Destroy(p, 3f);



    }
}
