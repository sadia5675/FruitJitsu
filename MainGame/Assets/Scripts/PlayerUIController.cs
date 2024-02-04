using System;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    public GameObject uiObject;
     Vector3 newCameraPosition=new Vector3(0.4f, -3.23f, -9.76f);
     Vector3 newCameraRotation=new Vector3(30.8f, -179.63f, -0.045f);
    //Vector3 basePos,baseRot;

    //Boolean isOnGameCamera = false;

    void Start()
    {
        //basePos=Camera.main.transform.position;
        //baseRot = Camera.main.transform.eulerAngles;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider theCollision)
    {
        GameObject collisionGO = theCollision.gameObject;
        // Check if the collided object has the "Button" tag
        if (collisionGO.CompareTag("PlayButton"))
        {
            Debug.Log("Collided ");
            // Call a function or perform an action when player collides with the button
            playUIsetting();
            
        }
    }

    void playUIsetting(){
        Camera.main.transform.position = newCameraPosition;
        Camera.main.transform.eulerAngles = newCameraRotation;
        if (uiObject != null)
        {
            // Deactivate the UI object
            uiObject.SetActive(false);
        }
    }
}
