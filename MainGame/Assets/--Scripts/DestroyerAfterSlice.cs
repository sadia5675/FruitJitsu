using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerAfterSlice : MonoBehaviour
{
    // Zeitverz�gerung in Sekunden, bevor das Objekt zerst�rt wird
    public float destroyDelay = 5f;

    void OnTriggerEnter(Collider otherCollider)
    {
        // StartCoroutine ist eine Methode in Unity, die es erm�glicht, Coroutine-Funktionen zu starten
        // Starte die Coroutine DestroyWithDelay mit dem GameObject, das zerst�rt werden soll, und der Verz�gerungszeit
        StartCoroutine(DestroyWithDelay(otherCollider.gameObject, destroyDelay));
    }

    // Coroutine-Funktion, um ein GameObject mit einer Verz�gerung zu zerst�ren
    IEnumerator DestroyWithDelay(GameObject objToDestroy, float delay)
    {
        // yield return new WaitForSeconds(delay); wartet f�r die angegebene Zeit
        yield return new WaitForSeconds(delay);
        // Nach der Verz�gerung wird das GameObject zerst�rt
        Destroy(objToDestroy);
    }
}
