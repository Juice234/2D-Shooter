using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ExitLevel : MonoBehaviour
{
 
    //Exit the level if triggered, used for getting out of the tuturial
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var Player = collision.GetComponent<PlayerMove>();

        if (Player)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            if (currentScene.name == "Tutorial")
            {
                SceneManager.LoadSceneAsync("Menu");
                Destroy(collision.gameObject); //Destroy the player from the heirachy to prevent issues when loading a new level in the menu
            }
            else
            {
                int nextSceneIndex = currentScene.buildIndex + 1;
                SceneManager.LoadSceneAsync(nextSceneIndex);
            }
        }
    }



}
