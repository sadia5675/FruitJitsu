using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine.Scripting;
public class PlayerUIController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject howToPlayMenu;//ist unser how to play Menü
    public GameObject switchMenu;
    public GameObject calibrationtimerMenu;


    public TextMeshProUGUI maxScore;
    public TextMeshProUGUI score;
    public RawImage loggo;
    public GameObject destroyer;

    public ScoreScript myScoreScript;
    public CharacterSwitcher myCharacterSwitcher;
    public CalibrationTimer myCalibration;
    public AudioManager audioM;

    int timer= 18;
    int counter = 3; 
    public RawImage calibrationStand;
    public RawImage schnittBewegung;
    public RawImage abweichBewegung;

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

    public void Awake()
    {
        audioM = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Update is called once per frame
    void Update()
    {
     if(myCalibration.aktivPlayerModus && !myCalibration.isAktivPlayerModusUsed){
        Debug.Log("MainMenu after Calibration");
        mainMenu.SetActive(true);
        calibrationtimerMenu.SetActive(false);
        myCalibration.isAktivPlayerModusUsed = true;
     }   
    }

    void OnTriggerEnter(Collider theCollision)
    {
        GameObject collisionGO = theCollision.gameObject;
        // Check if the collided object has the "Button" tag
        if (collisionGO.CompareTag("PlayButton"))
        {
            Debug.Log("Play ");
            audioM.PlaySFX(audioM.buttonclick);
            // Call a function or perform an action when player collides with the button
            playUIsetting();

        }
        if (collisionGO.CompareTag("SwitchButton"))
        {
            Debug.Log("Switch ");
            // Call a function or perform an action when player collides with the button
            if (mainMenu != null)
            {

                audioM.PlaySFX(audioM.buttonclick);
                // Deactivate the UI object
                mainMenu.SetActive(false);
                //howToPlayMenu.SetActive(false);
                switchMenu.SetActive(true);
            }
        }
        if (collisionGO.CompareTag("NextButton"))
        {
            Debug.Log("N�chster Player ");
            audioM.PlaySFX(audioM.nextBild);
            myCharacterSwitcher.NextCharacter();

        }
        if (collisionGO.CompareTag("OkButton"))
        {
            Debug.Log("Zur�ck zum Start ");
            // Call a function or perform an action when player collides with the button
            if (switchMenu != null)
            {
                audioM.PlaySFX(audioM.buttonclick);
                // Deactivate the UI object
                //howToPlayMenu.SetActive(false);
                mainMenu.SetActive(true);
                switchMenu.SetActive(false);
            }

        }
        if (collisionGO.CompareTag("HowToPlayButton"))
        {
            Debug.Log("Zur How to Play ");
            // Call a function or perform an action when player collides with the button
            if (mainMenu != null)
            {
                audioM.PlaySFX(audioM.buttonclick);
                mainMenu.SetActive(false);
                howToPlayMenu.SetActive(true);
                StartCoroutine(DiashowRound());
            }
        }

        if (collisionGO.CompareTag("OkButton"))
        {
            Debug.Log("Zur�ck zum Start ");
            // Call a function or perform an action when player collides with the button
            if (howToPlayMenu != null)
            {
                audioM.PlaySFX(audioM.buttonclick);
                mainMenu.SetActive(true);
                howToPlayMenu.SetActive(false);
            }
        }

    }
    private IEnumerator Diashow()
    {
        int t = timer;
       
        while (t > 0)
        {
            if (t == 18)
            {
                calibrationStand.enabled = true;
                schnittBewegung.enabled = false;
                abweichBewegung.enabled = false;
                yield return new WaitForSeconds(6f);
                t = t - 6;
            }
            else if (t == 12)
            {
                calibrationStand.enabled = false;
                schnittBewegung.enabled = true;
                abweichBewegung.enabled = false;
                yield return new WaitForSeconds(6f);
                t = t - 6;
            }
            else if (t == 6)
            {
                calibrationStand.enabled = false;
                schnittBewegung.enabled = false;
                abweichBewegung.enabled = true;
                yield return new WaitForSeconds(6f);
                t = t - 6;
            }
        }
    }
    private IEnumerator DiashowRound()
    {
        int c = counter;
        while (c > 0)
        {
            StartCoroutine(Diashow());
            Debug.Log("raus aus start counting");
            yield return new WaitForSeconds(18f);
            c = c - 1;

            StartCoroutine(Diashow());
            yield return new WaitForSeconds(18f);
            c = c - 1;

            StartCoroutine(Diashow());
            yield return new WaitForSeconds(18f);
            c = c - 1;
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
