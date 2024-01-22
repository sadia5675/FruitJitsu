using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeObjects : MonoBehaviour
{
    public List<Transform> objectReactingToBasses, objectReactingToNB, objectReactingToMiddles, objectReactingToHighs;
    [SerializeField] float t = 0.1f;
    public List<Transform> objectsToShake;
    
    void FixedUpdate()
    {
            makeObjectsShakeScale();    }

    public void makeObjectsShakeScaleToBasses(Transform objectReactingToBasses)
    {
        objectReactingToBasses.localScale = Vector3.Lerp(objectReactingToBasses.localScale, new Vector3(1, AudioManager.instance.getFrequenciesDiapason(1, 7, 10), 1), t);
    }
    public void makeObjectsShakeScaleToNB(Transform objectReactingToNB)
    {
        objectReactingToNB.localScale = Vector3.Lerp(objectReactingToNB.localScale, new Vector3(1, AudioManager.instance.getFrequenciesDiapason(1, 7, 10), 1), t);
    }
    public void makeObjectsShakeScaleToMiddles(Transform objectReactingToMiddles)
    {
        objectReactingToMiddles.localScale = Vector3.Lerp(objectReactingToMiddles.localScale, new Vector3(1, AudioManager.instance.getFrequenciesDiapason(1, 7, 10), 1), t);
    }
    public void makeObjectsShakeScaleToHighs(Transform objectReactingToHighs)
    {
        objectReactingToHighs.localScale = Vector3.Lerp(objectReactingToHighs.localScale, new Vector3(1, AudioManager.instance.getFrequenciesDiapason(1, 7, 10), 1), t);
    }
    public void makeObjectsShakeScale()
        { 
               foreach (Transform obj in objectReactingToBasses)
               {
                   obj.localScale = Vector3.Lerp(obj.localScale, new Vector3(1, AudioManager.instance.getFrequenciesDiapason(1, 7, 10), 1), t);
               }
               foreach (Transform obj in objectReactingToNB)
               {
                   obj.localScale = Vector3.Lerp(obj.localScale, new Vector3(1, AudioManager.instance.getFrequenciesDiapason(7, 15, 100), 1), t);
               }
               foreach (Transform obj in objectReactingToMiddles)
               {
                   obj.localScale = Vector3.Lerp(obj.localScale, new Vector3(1, AudioManager.instance.getFrequenciesDiapason(15, 30, 200), 1), t);
               }
               foreach (Transform obj in objectReactingToHighs)
               {
                   obj.localScale = Vector3.Lerp(obj.localScale, new Vector3(1, AudioManager.instance.getFrequenciesDiapason(30, 32, 1000), 1), t);
               }

           }

    /*public void makeObjectsShakeScale(Transform obj)
    {
        obj.localScale = Vector3.Lerp(obj.localScale, new Vector3(1, AudioManager.instance.getFrequenciesDiapason(0, 7, 10), 1), t);
    }*/
}
        /*
           */
  



