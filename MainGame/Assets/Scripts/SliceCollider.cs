using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// diese Klasse macht nur, wenn ein Objekt mit dem Slice trifft, 
//erhoeht oder vermindert die Punkte ggf. Effekte (ohne Distroy)
public class SliceCollider : MonoBehaviour
{
    public Transform effect;
    public int effectDuration;
    ScoreScript myScoreScript;
    void Awake()
    {
        myScoreScript  = transform.GetComponentInParent<ScoreScript>();
    }

    //Triggered by Unity's Physics
	void OnTriggerEnter(Collider theCollision)
    {
        GameObject collisionGO = theCollision.gameObject;
        if (collisionGO.CompareTag("Fruit"))
        {

            //fuer Effekte
            //Transform plusEffectInstance = Instantiate(plusEffect, theCollision.transform.position, Quaternion.identity);
             // Destroy the particle after the specified duration
            //Destroy(plusEffectInstance.gameObject, effectDuration);
  
            myScoreScript.score++;
        }
        else if (collisionGO.CompareTag("Bomb"))
        {

            Transform minusEffectInstance = Instantiate(effect, theCollision.transform.position, Quaternion.identity);
             // Destroy the particle after the specified duration
            Destroy(minusEffectInstance.gameObject, effectDuration);
            Destroy(collisionGO);
            myScoreScript.bombCount++;
            if (myScoreScript.bombCount >= 3) {
                myScoreScript.Explode();
            }
           
        }
    }
}

