using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // Ein Array, das die verschiedenen Frucht-GameObjects enthält, die gespawnt werden können.
    public GameObject[] Fruits;
    // Der Punkt, an dem die Früchte gespawnt werden sollen.
    public Transform SpawnPoint;
    // Die Zeit, die zwischen den einzelnen Spawns vergeht.
    public float IntervalBetweenSpawn;
    // Die verbleibende Zeit bis zum nächsten Spawn.
    private float spawnBetweenTime;

    // FixedUpdate wird aufgerufen, um eine bessere Leistung zu gewährleisten.
    void FixedUpdate()// für bessere Performance
    {
        // Überprüfe, ob die Zeit bis zum nächsten Spawn abgelaufen ist.
        if (spawnBetweenTime <= 0)
        {
            // Wähle eine zufällige Frucht aus dem Array aus.
            int rand = Random.Range(0, Fruits.Length);
            // Erzeuge die ausgewählte Frucht an der Spawn-Position.
            Instantiate(Fruits[rand], new Vector3(SpawnPoint.position.x, SpawnPoint.position.y + 1f, SpawnPoint.position.z), Quaternion.identity);
            // Setze die Zeit für den nächsten Spawn auf das festgelegte Intervall zurück.
            spawnBetweenTime = IntervalBetweenSpawn;
        }
        else {
            // Verringere die verbleibende Zeit bis zum nächsten Spawn.
            spawnBetweenTime -= Time.deltaTime;
        }
    }
}
