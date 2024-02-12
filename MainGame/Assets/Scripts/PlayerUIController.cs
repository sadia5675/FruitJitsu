using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    public GameObject playerMenu;
    public ScoreScript myScoreScript;
     Vector3 newCameraPosition=new Vector3(0.4f, -3.23f, -9.76f);
     Vector3 newCameraRotation=new Vector3(30.8f, -179.63f, -0.045f);
    Vector3 basePos,baseRot;
    public GameObject switchMenu; 
    public RawImage[] images;  
    public bool isOnGame= false;
    public int posBasedOnClicks=0;
    public Avatar[] avatars;
    private bool initialized; 
    void Start()
    {

        initialized = false; 
        basePos =Camera.main.transform.position;
        baseRot = Camera.main.transform.eulerAngles;
        switchMenu.SetActive(false); 
    }


    // Update is called once per frame
    void FixedUpdate()
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
        if (collisionGO.CompareTag("SwitchButton"))
        {
            Debug.Log("Switch ");
            // Call a function or perform an action when player collides with the button
            if (playerMenu != null)
            {
                // Deactivate the UI object
                playerMenu.SetActive(false);
                switchMenu.SetActive(true);
            }

        }
        if (collisionGO.CompareTag("OkButton"))
        {
            Debug.Log("Zurück zum Start ");
            // Call a function or perform an action when player collides with the button
            if (switchMenu != null)
            {
                // Deactivate the UI object
                playerMenu.SetActive(true);
                switchMenu.SetActive(false);
            }

        }
        if (collisionGO.CompareTag("NextButton"))
        {
            Debug.Log("Nächster Player ");
            choosePlayer(); 

            
        }
    }
void choosePlayer()
    {
        Debug.Log(posBasedOnClicks);
        if (!initialized)
        {
            foreach (Avatar a in avatars)
            {
                a.gameObject.SetActive(false);
            }

            foreach (RawImage r in images)
            {
                r.enabled = false;
            }

            initialized = true;
        }
        //zweite runde
        if (posBasedOnClicks >= 0)
        {
            avatars[posBasedOnClicks].gameObject.SetActive(false);
            images[posBasedOnClicks].enabled = false;
        }

        ++posBasedOnClicks;
        //neuer Player wird aktiviert 
        if (posBasedOnClicks >= avatars.Length)
        {
            posBasedOnClicks = 0;
        }
        avatars[posBasedOnClicks].gameObject.SetActive(true);
        images[posBasedOnClicks].enabled = true;
  
    }


    void playUIsetting(){
        Camera.main.transform.position = newCameraPosition;
        Camera.main.transform.eulerAngles = newCameraRotation;
        isOnGame=true;
        if (playerMenu != null)
        {
            // Deactivate the UI object
            playerMenu.SetActive(false);
        }
        myScoreScript.NewGame();
    }

    public void gameoverUIsetting(){
        Camera.main.transform.position = basePos;
        Camera.main.transform.eulerAngles = baseRot;
        isOnGame=false;

            // Deactivate the UI object
        playerMenu.SetActive(true);
        
    }
}
