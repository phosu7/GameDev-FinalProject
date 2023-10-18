using UnityEngine;

public class ProjectileThrower : MonoBehaviour
{
    [SerializeField] float pSpeed = 10f;
    public GameObject projectilePrefab;
    public Transform firePoint;

    //ammo
    public int currentBoba;
    public int ammoSize = 1;


    public void Throw(Vector3 targetPosition)
    {
        if (currentBoba > 0)
        {

            Rigidbody2D projectileRB = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation).GetComponent<Rigidbody2D>();
            targetPosition.z = 0;
            Vector3 direction = (targetPosition - transform.position).normalized;

            projectileRB.velocity = direction * pSpeed;

            currentBoba -= 1;

        }
    }

    public void AddBoba(int bobaAmount)
    {
        currentBoba += bobaAmount;

    }
}
