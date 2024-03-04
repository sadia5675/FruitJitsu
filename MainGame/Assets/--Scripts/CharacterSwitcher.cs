using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSwitcher : MonoBehaviour
{
    public Avatar[] avatars;

    //Banana ist immer am Anfang
    int index = 0;

    public Vector3 restPosition= new Vector3(-0.0399999991f,-5.30999994f,6f);
    public Vector3 spielPosition = new Vector3(0.829999983f,-5.4000001f,0.140000001f);

    //bool initialized;
    public RawImage[] images;  
    public bool isOnGame= false;

    public void NextCharacter()
    {

            // if(!initialized)
            // {
            //     foreach(Avatar a in avatars)
            //     {
            //         a.gameObject.SetActive(false);
            //     }
            //     initialized = true;
            // }


//            if(index >=0)
            avatars[index].transform.position = restPosition;
            images[index].enabled = false;
            index=(index +1)%avatars.Length;
            avatars[index].transform.position = spielPosition;
            images[index].enabled = true;
    }
}
