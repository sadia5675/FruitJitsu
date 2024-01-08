using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    public int theScore = 0;


	void Update () {

	}
    
    void OnGUI()
    {
        //We display the game GUI from the playerscript
        //It would be nicer to have a seperate script dedicated to the GUI though...
        GUILayout.Label("Score: " + theScore);
    }    

}
