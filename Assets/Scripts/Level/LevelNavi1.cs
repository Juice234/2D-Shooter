using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelNavi : MonoBehaviour
{

    [SerializeField] private string sceneName;
    public AudioSource soundPlayer;
    public void changeScene()
    {

        //SceneManager.LoadScene(sceneName);
        SceneManager.LoadSceneAsync(sceneName);
    }

    //Sound can be be played on click 
    public void playThisSound()
    {

        soundPlayer.Play();
    }
}
