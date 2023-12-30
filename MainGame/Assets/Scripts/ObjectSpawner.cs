using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    public GameObject[] Fruits;
    public Transform SpawnPoint;
    public float IntervalBetweenSpawn;

    private float spawnBetweenTime;
    // Update is called once per frame
    void FixedUpdate()// für bessere Performance
    {
        if (spawnBetweenTime <= 0)
        {
            int rand = Random.Range(0, Fruits.Length);
            Instantiate(Fruits[rand], new Vector3(SpawnPoint.position.x, SpawnPoint.position.y + 2f, SpawnPoint.position.z), Quaternion.identity);
            spawnBetweenTime = IntervalBetweenSpawn;
        }
        else {
            spawnBetweenTime -= Time.deltaTime;
        }
    }
}
