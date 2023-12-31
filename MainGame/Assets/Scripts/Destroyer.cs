using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    // Diese Methode wird aufgerufen, wenn ein Collider (z. B. ein anderes GameObject) in diesen Trigger hineinläuft.
    void OnTriggerEnter(Collider otherCollider)
    {
        // Zerstöre das GameObject, das den Trigger betreten hat.
        Destroy(otherCollider.gameObject);
    }
}
