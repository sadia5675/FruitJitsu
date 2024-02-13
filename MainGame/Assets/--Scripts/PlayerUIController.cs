using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject instructionMenu;
    public GameObject optionMenu;
    public GameObject switchMenu;
    public TextMeshProUGUI maxScore;
    public TextMeshProUGUI score;
    public RawImage loggo;
    public GameObject destroyer;

    public ScoreScript myScoreScript;
    public CharacterSwitcher myCharacterSwitcher;
    public AudioManager audioM;
    

     Vector3 newCameraPosition=new Vector3(0.4f, -3.23f, -9.76f);
     Vector3 newCameraRotation=new Vector3(30.8f, -179.63f, -0.045f);
     Vector3 basePos,baseRot;

    Vector3 oldDestroyerPos = new Vector3(-0.04f, -5.31f, 5.05f);
    Vector3 newDestroyerPos = new Vector3(-0.04f, -5.31f, -14.15f);

    void Start()
    {

        basePos =Camera.main.transform.position;
        baseRot = Camera.main.transform.eulerAngles;
        //switchMenu.SetActive(false); 
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
            Debug.Log("Play ");
            // Call a function or perform an action when player collides with the button
            playUIsetting();

        }
        if (collisionGO.CompareTag("SwitchButton"))
        {
            Debug.Log("Switch ");
            // Call a function or perform an action when player collides with the button
            if (mainMenu != null)
            {
                // Deactivate the UI object
                mainMenu.SetActive(false);
                optionMenu.SetActive(false);
                switchMenu.SetActive(true);
            }

        }
        if (collisionGO.CompareTag("OkButton"))
        {
            Debug.Log("Zur�ck zum Start ");
            // Call a function or perform an action when player collides with the button
            if (switchMenu != null)
            {
                // Deactivate the UI object
                mainMenu.SetActive(true);
                switchMenu.SetActive(false);
            }

        }
        if (collisionGO.CompareTag("NextButton"))
        {
            Debug.Log("N�chster Player ");
            myCharacterSwitcher.NextCharacter();

            
        }

        if (collisionGO.CompareTag("OptionButton"))
        {
            mainMenu.SetActive(false);
            optionMenu.SetActive(true);
        }


        if (collisionGO.CompareTag("InstructionButton"))
        {
            optionMenu.SetActive(false);
            instructionMenu.SetActive(true);
        }
        if (collisionGO.CompareTag("BackMain"))
        {
            optionMenu.SetActive(false);
            mainMenu.SetActive(true);
        }
        if (collisionGO.CompareTag("BackOption"))
        {
            optionMenu.SetActive(true);
            instructionMenu.SetActive(false);
            switchMenu.SetActive(false);
        }

    }
// void choosePlayer()
//     {
//         Debug.Log(posBasedOnClicks);
//         if (!initialized)
//         {
//             foreach (Avatar a in avatars)
//             {
//                 a.gameObject.SetActive(false);
//             }

//             foreach (RawImage r in images)
//             {
//                 r.enabled = false;
//             }

//             initialized = true;
//         }
//         //zweite runde
//         if (posBasedOnClicks >= 0)
//         {   

//             avatars[posBasedOnClicks].gameObject.SetActive(false);
//             images[posBasedOnClicks].enabled = false;
//         }

//         ++posBasedOnClicks;
//         //neuer Player wird aktiviert 
//          if (posBasedOnClicks >= avatars.Length)
//             {
//                 posBasedOnClicks = 0;
//             }

//         avatars[posBasedOnClicks].gameObject.SetActive(true);
//         images[posBasedOnClicks].enabled = true;
  
//     }


    void playUIsetting(){
        Camera.main.transform.position = newCameraPosition;
        Camera.main.transform.eulerAngles = newCameraRotation;
        destroyer.transform.position = oldDestroyerPos;
        myCharacterSwitcher.isOnGame=true;
        audioM.startSong = true;

        // Deactivate the UI object
        mainMenu.SetActive(false);
        myScoreScript.NewGame();
        myScoreScript.resetHealth();
        Debug.Log("Play-UIController");
    }

    public void gameoverUIsetting(){
        Camera.main.transform.position = basePos;
        Camera.main.transform.eulerAngles = baseRot;
        destroyer.transform.position = newDestroyerPos;
        myCharacterSwitcher.isOnGame=false;
        audioM.startSong = false;
        loggo.enabled = false;

        maxScore.SetText("maxScore:"+(myScoreScript.maxScore));
        score.SetText("score:" + (myScoreScript.score));

        // Activate the UI object
        mainMenu.SetActive(true);
        
    }
}
