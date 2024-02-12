using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // Ein Array, das die verschiedenen Frucht-GameObjects enth�lt, die gespawnt werden k�nnen.
    public GameObject[] Fruits;
    // Der Punkt, an dem die Fr�chte gespawnt werden sollen.
    public Transform SpawnPoint;
    // Die Zeit, die zwischen den einzelnen Spawns vergeht. 
    //Startspeed
    public float IntervalBetweenSpawn = 2;
    public float actInterval;

    //je kleiner ist diese Variable, desto kleiner IntervalBetweenSpawn ist -> spawn automatisch schneller
    public float spawnSpeedMultiplier = 0.98f;
    // Die verbleibende Zeit bis zum n�chsten Spawn.
    //hab public gemacht, damit ich diese Variable track
    public float spawnBetweenTime;

    private float bombRate = 0.4f;

    public Transform bombPrefab;
    // Öffentliche Referenz, dadurch kann ObjectSpawner auf die öffentlichen Eigenschaften und Methoden von CalibrationTimer zugreifen.
    public CalibrationTimer calibrationTimer;

    public Transform[] SpawnPoints;

    public PlayerUIController myUIController;



    // FixedUpdate wird aufgerufen, um eine bessere Leistung zu gew�hrleisten.
    void FixedUpdate()// f�r bessere Performance
    {
        float objectReactingToBass = AudioManager.instance.getFrequenciesDiapason(1, 7, 10);
        float highFrequency = AudioManager.instance.getFrequenciesDiapason(30, 32, 1000);


        // Überprüft, ob eine gültige Referenz auf CalibrationTimer vorhanden ist und ob die Bedingung für das Spawnen erfüllt ist.
        if (calibrationTimer != null && myUIController.isOnGame &&isActiveAndEnabled)
        {
//            Debug.Log("highFrequency: " + highFrequency);

            if (objectReactingToBass > 1.2f)
            {

                    if (Random.Range(0f, 3f) < bombRate)
                    {
                        SpawnBomb(SpawnPoints[0]);
                    }
                    else
                    {
                        SpawnFruit(SpawnPoints[0]);
                    }
            }
            if (highFrequency > 2.9f)
            {
//                Debug.Log("high:"+highFrequency);

                if (Random.Range(0f, 3f) < bombRate)
                {
                    SpawnBomb(SpawnPoints[1]);
                }
                else
                {
                    SpawnFruit(SpawnPoints[1]);
                }
            }
        }
    }

    void SpawnBomb(Transform spawnPoint)
    {
        Instantiate(bombPrefab, new Vector3(spawnPoint.position.x, spawnPoint.position.y + 1f, spawnPoint.position.z), Quaternion.identity);
    }

    void SpawnFruit(Transform spawnPoint)
    {

        int rand = Random.Range(0, Fruits.Length);
        Instantiate(Fruits[rand], new Vector3(spawnPoint.position.x, spawnPoint.position.y + 1f, spawnPoint.position.z), Quaternion.identity);
    }
}
