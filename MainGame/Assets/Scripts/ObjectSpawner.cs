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
    public float IntervalBetweenSpawn;
    // Die verbleibende Zeit bis zum n�chsten Spawn.
    private float spawnBetweenTime;

    // FixedUpdate wird aufgerufen, um eine bessere Leistung zu gew�hrleisten.
    void FixedUpdate()// f�r bessere Performance
    {
        // �berpr�fe, ob die Zeit bis zum n�chsten Spawn abgelaufen ist.
        if (spawnBetweenTime <= 0)
        {
            // W�hle eine zuf�llige Frucht aus dem Array aus.
            int rand = Random.Range(0, Fruits.Length);
            // Erzeuge die ausgew�hlte Frucht an der Spawn-Position.
            Instantiate(Fruits[rand], new Vector3(SpawnPoint.position.x, SpawnPoint.position.y + 1f, SpawnPoint.position.z), Quaternion.identity);
            // Setze die Zeit f�r den n�chsten Spawn auf das festgelegte Intervall zur�ck.
            spawnBetweenTime = IntervalBetweenSpawn;
        }
        else {
            // Verringere die verbleibende Zeit bis zum n�chsten Spawn.
            spawnBetweenTime -= Time.deltaTime;
        }
    }
}
