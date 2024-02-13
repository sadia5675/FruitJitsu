using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObject : MonoBehaviour
{
    public float speed;
    // Diese Methode wird in jedem Frame aufgerufen.
    void FixedUpdate()
    {
        // Überprüfe, ob das GameObject das Tag "Fruit" hat
        if (gameObject.CompareTag("Fruit"))
        {
            // Rotiere das Objekt um 15 Grad pro Sekunde um die X-Achse, 30 Grad um die Y-Achse und 45 Grad um die Z-Achse gedreht.
            transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        }
        // Überprüfe, ob das GameObject das Tag "Food" hat
        if (gameObject.CompareTag("Food"))
        {
            Debug.Log("Food moveable");
            // Rotiere das Objekt um 15 Grad pro Sekunde um die X-Achse, 30 Grad um die Y-Achse und 45 Grad um die Z-Achse gedreht.
            transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        }
        // Bewege das GameObject in die "forward"-Richtung (in Weltkoordinaten) basierend auf der Geschwindigkeit und der vergangenen Zeit.
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
    }
}
