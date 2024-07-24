using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tut_Manager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int counter = 0;


    // Trigger a different message based on how many times a collision has occured this is used for the tutorial
    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.CompareTag("Enemy"))
        {
            switch (counter)
            {
                case 0:
                    scoreText.text = "Oh look a bad guy move up to  kill him";
                    scoreText.enabled = true;
                    break;
                case 1:
                    scoreText.text = "Oh look another bad guy he shoots things";
                    scoreText.enabled = true;
                    break;
                case 2:
                    scoreText.text = "You can press space to give yourself a boost";
                    scoreText.enabled = true;
                    break;
                case 3:
                    scoreText.text = "Take the blue pill to gain a life if you lose one";
                    scoreText.enabled = true;
                    break;
                case 4:
                    scoreText.text = "Dont take this pill its bad";
                    scoreText.enabled = true;
                    break;
            }
            
            counter++;
        }
    }

    // Disable the text if the collision box has been left
    private void OnTriggerExit2D(Collider2D collison)
    {
        if (collison.CompareTag("Enemy"))
        {
            scoreText.enabled = false;
        }

    }

}
