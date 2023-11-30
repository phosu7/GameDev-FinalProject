using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.WSA;

public class ProjectileThrower : MonoBehaviour
{
    [SerializeField] float pSpeed = 10f;
    public GameObject projectilePrefab;
    public Transform firePoint;

    //ammo
    public static int currentBlackBoba = 0;
    public static int currentBlueBoba = 0;
    public static int currentRedBoba = 0;

    public int totalBoba = 0;

    public int ammoSize = 5;

    void Update()
    {
        totalBoba = currentBlackBoba + currentBlueBoba + currentRedBoba;
    }

    public void SetPrefab(GameObject newPrefab)
    {
        projectilePrefab = newPrefab;


    }

    public void Throw(Vector3 targetPosition, int damage)
    {

        if (totalBoba > 0)
        {
            GameObject boba = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

            if (currentBlackBoba > 0)
            {
                if (boba.CompareTag("Boba"))
                {
                    Rigidbody2D projectileRB = boba.GetComponent<Rigidbody2D>();
                    targetPosition.z = 0;
                    Vector3 direction = (targetPosition - transform.position).normalized;

                    projectileRB.velocity = direction * pSpeed;
                    GetComponent<AudioSource>().Play();
                    currentBlackBoba--;
                    totalBoba--;
                }
            }

            if (currentBlueBoba > 0)
            {
                if (boba.CompareTag("BlueBoba"))
                {
                    Rigidbody2D projectileRB = boba.GetComponent<Rigidbody2D>();
                    targetPosition.z = 0;
                    Vector3 direction = (targetPosition - transform.position).normalized;

                    projectileRB.velocity = direction * 6;
                    GetComponent<AudioSource>().Play();
                    currentBlueBoba--;
                    totalBoba--;
                }
            }
            if (currentRedBoba > 0)
            {
                if (boba.CompareTag("RedBoba"))
                {
                    Rigidbody2D projectileRB = boba.GetComponent<Rigidbody2D>();
                    targetPosition.z = 0;
                    Vector3 direction = (targetPosition - transform.position).normalized;

                    projectileRB.velocity = direction * pSpeed;
                    GetComponent<AudioSource>().Play();
                    currentRedBoba--;
                    totalBoba--;
                }
            }
        }



    }

    public void AddBoba(int blackBoba, int blueBoba, int redBoba)
    {
        currentBlackBoba += blackBoba;
        currentBlueBoba += blueBoba;
        currentRedBoba += redBoba;




    }
}
