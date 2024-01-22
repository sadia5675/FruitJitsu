using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // Ein Array, das die verschiedenen Frucht-GameObjects enthï¿½lt, die gespawnt werden kï¿½nnen.
    public GameObject[] Fruits;
    // Der Punkt, an dem die Frï¿½chte gespawnt werden sollen.
    public Transform SpawnPoint;
    // Die Zeit, die zwischen den einzelnen Spawns vergeht. 
    //Startspeed
    public float IntervalBetweenSpawn = 5;
    public float actInterval;

    //je kleiner ist diese Variable, desto kleiner IntervalBetweenSpawn ist -> spawn automatisch schneller
    public float spawnSpeedMultiplier = 0.98f;
    // Die verbleibende Zeit bis zum nï¿½chsten Spawn.
    //hab public gemacht, damit ich diese Variable track
    public float spawnBetweenTime;

    private float bombRate = 0.4f;

    public Transform bombPrefab;
    // Ã–ffentliche Referenz, dadurch kann ObjectSpawner auf die Ã¶ffentlichen Eigenschaften und Methoden von CalibrationTimer zugreifen.
    public CalibrationTimer calibrationTimer;

    void Start()
    {
        // Initialize actInterval here or perform any other necessary initialization.
        actInterval = IntervalBetweenSpawn;
    }


    // FixedUpdate wird aufgerufen, um eine bessere Leistung zu gewï¿½hrleisten.
    void FixedUpdate()// fï¿½r bessere Performance
    {
        // ÃœberprÃ¼ft, ob eine gÃ¼ltige Referenz auf CalibrationTimer vorhanden ist und ob die Bedingung fÃ¼r das Spawnen erfÃ¼llt ist.
        if (calibrationTimer != null && calibrationTimer.AllowSpawn)
        {
            Debug.Log("Spawn erlaubt!");
            // ï¿½berprï¿½fe, ob die Zeit bis zum nï¿½chsten Spawn abgelaufen ist.
            if (spawnBetweenTime <= 0)
            {
                // Fruechte oder Bombe zufaellig erstellt werden (Wahrscheinlichkeit von Freuchte ist hoeher)
                if (Random.Range(0f, 1f) < bombRate)
                {
                    SpawnBomb();

                }
                else
                {
                    SpawnFruit();
                }

                actInterval *= spawnSpeedMultiplier;
                // Setze die Zeit fï¿½r den nï¿½chsten Spawn auf das festgelegte Intervall zurï¿½ck.
                spawnBetweenTime = actInterval;
            }
            else
            {
                // Verringere die verbleibende Zeit bis zum nï¿½chsten Spawn.
                spawnBetweenTime -= Time.deltaTime;
            }
        }
        else
        {
            Debug.Log("Spawn nicht erlaubt oder CalibrationTimer nicht zugewiesen.");
        }
    }

    void SpawnBomb()
    {
        float addXPos = Random.Range(-1.6f, 1.6f);
        Vector3 spawnPos = transform.position + new Vector3(addXPos, 0, 0);
        Instantiate(bombPrefab, spawnPos, Quaternion.identity);
    }

    void SpawnFruit()
    {

        // Wï¿½hle eine zufï¿½llige Frucht aus dem Array aus.
        int rand = Random.Range(0, Fruits.Length);
        // Erzeuge die ausgewï¿½hlte Frucht an der Spawn-Position.
        Instantiate(Fruits[rand], new Vector3(SpawnPoint.position.x, SpawnPoint.position.y + 1f, SpawnPoint.position.z), Quaternion.identity);
    }
}


