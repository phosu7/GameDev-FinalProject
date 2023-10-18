using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] GameObject floorBobaPrefab;
    [SerializeField] GameObject karenPrefab;

    private int karenCount = 8;



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

            while (karenCount >= 0)
            {
                yield return new WaitForSeconds(5f);
                GameObject newKaren = Instantiate(karenPrefab, new Vector3(Random.Range(-9, 6), Random.Range(-4, 3), 0), Quaternion.identity);
                --karenCount;
            }




            yield return null;

        }
    }

}
