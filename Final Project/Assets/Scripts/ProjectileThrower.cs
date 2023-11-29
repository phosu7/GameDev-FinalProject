using UnityEngine;

public class ProjectileThrower : MonoBehaviour
{
    [SerializeField] float pSpeed = 10f;
    public GameObject projectilePrefab;
    public Transform firePoint;

    //ammo
    public int currentBoba;
    public int ammoSize = 5;


    public void Throw(Vector3 targetPosition, int damage)
    {
        if (currentBoba > 0)
        {
            GameObject boba = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

            if (boba.CompareTag("Boba"))
            {
                Rigidbody2D projectileRB = boba.GetComponent<Rigidbody2D>();
                targetPosition.z = 0;
                Vector3 direction = (targetPosition - transform.position).normalized;

                projectileRB.velocity = direction * pSpeed;
                GetComponent<AudioSource>().Play();
                currentBoba -= damage;



            }
        }
        else
        {
            Debug.Log("NO more ammo");
        }

    }

    public void AddBoba(int bobaAmount)
    {
        currentBoba += bobaAmount;

    }
}
