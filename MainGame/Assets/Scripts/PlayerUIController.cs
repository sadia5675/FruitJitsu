using System;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    public GameObject uiObject;
    public ScoreScript myScoreScript;
     Vector3 newCameraPosition=new Vector3(0.4f, -3.23f, -9.76f);
     Vector3 newCameraRotation=new Vector3(30.8f, -179.63f, -0.045f);
    Vector3 basePos,baseRot;

    public Boolean isOnGame= false;

    void Start()
    {
        basePos=Camera.main.transform.position;
        baseRot = Camera.main.transform.eulerAngles;
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
        isOnGame=true;
        if (uiObject != null)
        {
            // Deactivate the UI object
            uiObject.SetActive(false);
        }
        myScoreScript.NewGame();
    }

    public void gameoverUIsetting(){
        Camera.main.transform.position = basePos;
        Camera.main.transform.eulerAngles = baseRot;
        isOnGame=false;

            // Deactivate the UI object
        uiObject.SetActive(true);
        
    }
}
