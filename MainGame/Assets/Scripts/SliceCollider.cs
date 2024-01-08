using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// diese Klasse macht nur, wenn ein Objekt mit dem Slice trifft, 
//erhoeht oder vermindert die Punkte ggf. Effekte (ohne Distroy)
public class SliceCollider : MonoBehaviour
{
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
            myScoreScript.theScore++;
        }
        else if (collisionGO.CompareTag("Bomb"))
        {

            //Transform minusEffectInstance = Instantiate(minusEffect, theCollision.transform.position, Quaternion.identity);
             // Destroy the particle after the specified duration
            //Destroy(minusEffectInstance.gameObject, effectDuration);

            myScoreScript.theScore--;
        }
    }
}

