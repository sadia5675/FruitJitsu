using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceListener : MonoBehaviour
{
    // Das Slicer-Objekt, das die Slicing-Funktionalität enthält.
    public Slicer slicer;
    // Wird aufgerufen, wenn ein anderer Collider mit diesem Collider kollidiert.
    private void OnTriggerEnter(Collider other)
    {
        // Setze die 'isTouched'-Variable des Slicer-Objekts auf 'true', wenn ein Trigger-Objekt diesen Collider berührt.
        slicer.isTouched = true;
    }
}
