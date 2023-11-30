using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public EnemyHealth enemyHealth;
    [SerializeField] GameObject floorBobaPrefab1;
    [SerializeField] GameObject floorBobaPrefab2;
    [SerializeField] GameObject floorBobaPrefab3;
    [SerializeField] GameObject karenPrefab1;
    [SerializeField] GameObject karenPrefab2;
    [SerializeField] GameObject karenPrefab3;

    // private int karenCount = 11;
    private int spawnGoal = EnemyHealth.goal;
    int levelIndex;

    void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>();

    }

    void Start()
    {

        levelIndex = DayTracker.Instance.levelIndex;
        Debug.Log("level index: " + levelIndex);

        SpawnBoba();
        SpawnKaren();

    }

    void SpawnBoba()
    {
        StartCoroutine(SpawnBobaRoutine());

        IEnumerator SpawnBobaRoutine()
        {
            if (DayTracker.dayCounter == 1)
            {
                while (true)
                {
                    yield return new WaitForSeconds(2f);
                    GameObject newBoba = Instantiate(floorBobaPrefab1, new Vector3(Random.Range(-8, 6), Random.Range(-4, 3), 0), Quaternion.identity);

                }
            }
            else if (DayTracker.dayCounter == 2)
            {
                while (true)
                {
                    yield return new WaitForSeconds(2f);
                    GameObject newBoba = Instantiate(floorBobaPrefab2, new Vector3(Random.Range(-8, 6), Random.Range(-4, 3), 0), Quaternion.identity);
                }
            }
            yield return null;
        }

    }

    void SpawnKaren()
    {
        StartCoroutine(SpawnKarenRoutine());

        IEnumerator SpawnKarenRoutine()
        {

            if (DayTracker.dayCounter == 1)
            {
                while ((spawnGoal - 4) >= 0)
                {
                    yield return new WaitForSeconds(5f);
                    GameObject newKaren = Instantiate(karenPrefab1, new Vector3(Random.Range(-9, 6), Random.Range(-4, 3), 0), Quaternion.identity);
                    --spawnGoal;
                }
            }
            else if (DayTracker.dayCounter == 2)
            {
                while ((spawnGoal - 4) >= 0)
                {
                    yield return new WaitForSeconds(5f);
                    GameObject newKaren = Instantiate(karenPrefab2, new Vector3(Random.Range(-9, 6), Random.Range(-4, 3), 0), Quaternion.identity);
                    --spawnGoal;
                }
            }




            yield return null;

        }
    }



}
