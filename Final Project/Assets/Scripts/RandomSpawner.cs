using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public EnemyHealth enemyHealth;
    [SerializeField] GameObject floorBobaPrefab;
    [SerializeField] GameObject karenPrefab;

    // private int karenCount = 11;
    private int spawnGoal = EnemyHealth.goal;

    void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>();

    }

    void Start()
    {
        SpawnBoba();
        SpawnKaren();

    }

    void SpawnBoba()
    {
        StartCoroutine(SpawnBobaRoutine());

        IEnumerator SpawnBobaRoutine()
        {

            while (true)
            {
                yield return new WaitForSeconds(2f);
                GameObject newBoba = Instantiate(floorBobaPrefab, new Vector3(Random.Range(-8, 6), Random.Range(-4, 3), 0), Quaternion.identity);

            }
            yield return null;
        }

    }

    void SpawnKaren()
    {
        StartCoroutine(SpawnKarenRoutine());

        IEnumerator SpawnKarenRoutine()
        {

            while ((spawnGoal - 4) >= 0)
            {
                yield return new WaitForSeconds(5f);
                GameObject newKaren = Instantiate(karenPrefab, new Vector3(Random.Range(-9, 6), Random.Range(-4, 3), 0), Quaternion.identity);
                --spawnGoal;
            }




            yield return null;

        }
    }

}
