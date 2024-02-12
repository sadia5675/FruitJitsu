using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSwitcher : MonoBehaviour
{
    public Avatar[] avatars;

    //Banana ist immer am Anfang
    int index = 0;

    //bool initialized;
    public RawImage[] images;  

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
            avatars[index].gameObject.SetActive(false);
            images[index].enabled = false;
            index=(index +1)%avatars.Length;
            avatars[index].gameObject.SetActive(true);
            images[index].enabled = true;
    }
}
