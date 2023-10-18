using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] GameObject floorBobaPrefab;


    void Start()
    {
        SpawnBoba();

    }

    void SpawnBoba()
    {
        StartCoroutine(SpawnBobaRoutine());

        IEnumerator SpawnBobaRoutine()
        {

            while (true)
            {
                yield return new WaitForSeconds(2f);
                GameObject newBoba = Instantiate(floorBobaPrefab, new Vector3(Random.Range(-9, 6), Random.Range(-4, 3), 0), Quaternion.identity);

            }
            yield return null;
        }

    }

}
