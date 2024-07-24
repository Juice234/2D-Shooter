using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theme : MonoBehaviour
{ 
    //An object which plays the theme of the game and isnt destroyed between scenes
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }




    
}
