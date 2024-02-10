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
    public Boolean isOnGame= false;
    public int counterForClicks=0;
    private bool isNextActive=false;
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
            nextPlayer(images, initialized); 

            
        }
    }
    public void nextPlayer(RawImage[] images, bool initialized)
    {
        if (!initialized)
        {
            foreach (Avatar a in avatars)
            {
                a.gameObject.SetActive(false);
            }
            initialized = true;
        }
        Debug.Log(counterForClicks);
        //zweite runde , der aktive Player wird deaktiviert 
        if (counterForClicks - 1 >= 0)
            avatars[counterForClicks - 1].gameObject.SetActive(false);

        for (int i =0; i<images.Length; i++)
        {
            images[i].enabled = false; 
        }
        if (counterForClicks>=images.Length || counterForClicks >= avatars.Length)
        {
            counterForClicks = 0;
        }
              //neuer Player wird aktiviert 
            avatars[counterForClicks].gameObject.SetActive(true);
            images[counterForClicks].enabled = true;
            counterForClicks++;  
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
