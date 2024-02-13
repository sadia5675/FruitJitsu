using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // Ein Array, das die verschiedenen Frucht-GameObjects enth�lt, die gespawnt werden k�nnen.
    public GameObject[] fruits;

    public GameObject[] food;

    // Der Punkt, an dem die Fr�chte gespawnt werden sollen.
    public Transform spawnPoint;
    // Die Zeit, die zwischen den einzelnen Spawns vergeht. 
    //Startspeed
    public float intervalBetweenSpawn = 2;
    public float actInterval;

    //je kleiner ist diese Variable, desto kleiner IntervalBetweenSpawn ist -> spawn automatisch schneller
    public float spawnSpeedMultiplier = 0.98f;
    // Die verbleibende Zeit bis zum n�chsten Spawn.
    //hab public gemacht, damit ich diese Variable track
    public float spawnBetweenTime;

    private float bombRate = 0.4f;

    private float foodRate = 2.6f;

    public Transform bombPrefab;
    // Öffentliche Referenz, dadurch kann ObjectSpawner auf die öffentlichen Eigenschaften und Methoden von CalibrationTimer zugreifen.
    public CalibrationTimer calibrationTimer;

    public Transform[] spawnPoints;

     public CharacterSwitcher myCharacterSwitcher;



    // FixedUpdate wird aufgerufen, um eine bessere Leistung zu gew�hrleisten.
    void FixedUpdate()// f�r bessere Performance
    {
        float objectReactingToBass = AudioManager.instance.getFrequenciesDiapason(1, 7, 10);
        float highFrequency = AudioManager.instance.getFrequenciesDiapason(30, 32, 1000);


        // Überprüft, ob eine gültige Referenz auf CalibrationTimer vorhanden ist und ob die Bedingung für das Spawnen erfüllt ist.
        if (calibrationTimer != null && myCharacterSwitcher.isOnGame &&isActiveAndEnabled)
        {

            if (objectReactingToBass > 1.2f)
            {

                    if (Random.Range(0f, 3f) < bombRate)
                    {
                        SpawnBomb(spawnPoints[0]);
                    }
                    if (Random.Range(0f, 3f) > foodRate)
                    {
                        SpawnFood(spawnPoints[0]);
                    }
                    else
                        {
                            SpawnFruit(spawnPoints[0]);
                        }
            }
            if (highFrequency > 2.9f)
            {
//                Debug.Log("high:"+highFrequency);

                if (Random.Range(0f, 3f) < bombRate)
                {
                    SpawnBomb(spawnPoints[1]);
                }
                if (Random.Range(0f, 3f) > foodRate)
                {
                     Debug.Log("spawn food");
                    SpawnFood(spawnPoints[1]);
                }
                else
                {
                    SpawnFruit(spawnPoints[1]);
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

        int rand = Random.Range(0, fruits.Length);
        Instantiate(fruits[rand], new Vector3(spawnPoint.position.x, spawnPoint.position.y + 1f, spawnPoint.position.z), Quaternion.identity);
    }

    void SpawnFood(Transform spawnPoint)
    {
        Debug.Log("spawn food methode");
        int rand = Random.Range(0, food.Length);
        Instantiate(food[rand], new Vector3(spawnPoint.position.x, spawnPoint.position.y + 1f, spawnPoint.position.z), Quaternion.identity);
    }
}
