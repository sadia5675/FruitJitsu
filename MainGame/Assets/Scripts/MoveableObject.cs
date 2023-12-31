using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObject : MonoBehaviour
{
    public float speed;
    // Diese Methode wird in jedem Frame aufgerufen.
    void FixedUpdate()
    {
        // Bewege das GameObject in die "forward"-Richtung (in Weltkoordinaten) basierend auf der Geschwindigkeit und der vergangenen Zeit.
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
    }
}
