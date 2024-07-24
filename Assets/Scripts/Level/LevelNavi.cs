using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelNavi1 : MonoBehaviour
{

    // Used for menu option to naviagte to the chosed level which can be changed via inspector
    [SerializeField] private string sceneName;
    public AudioSource soundPlayer;
    public void changeScene()
    {

        //SceneManager.LoadScene(sceneName);
        SceneManager.LoadSceneAsync(sceneName);
    }

    //Sound on be played on click
    public void playThisSound()
    {

        soundPlayer.Play();
    }
    
    //Game can be exit on click
    public void QuitGame()
    {
        Application.Quit();
    }
}
