using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerAfterSlice : MonoBehaviour
{
    // Zeitverzögerung in Sekunden, bevor das Objekt zerstört wird
    public float destroyDelay = 5f;

    void OnTriggerEnter(Collider otherCollider)
    {
        // StartCoroutine ist eine Methode in Unity, die es ermöglicht, Coroutine-Funktionen zu starten
        // Starte die Coroutine DestroyWithDelay mit dem GameObject, das zerstört werden soll, und der Verzögerungszeit
        StartCoroutine(DestroyWithDelay(otherCollider.gameObject, destroyDelay));
    }

    // Coroutine-Funktion, um ein GameObject mit einer Verzögerung zu zerstören
    IEnumerator DestroyWithDelay(GameObject objToDestroy, float delay)
    {
        // yield return new WaitForSeconds(delay); wartet für die angegebene Zeit
        yield return new WaitForSeconds(delay);
        // Nach der Verzögerung wird das GameObject zerstört
        Destroy(objToDestroy);
    }
}
