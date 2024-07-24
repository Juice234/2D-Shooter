using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_Bullet : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //IF enemy bullet hits outside screen delete bullet, done for perfomance
        if (collision.CompareTag("Void"))
        {
            Destroy(gameObject);
        }
        // If enemy bullet hits player delete bullet , take a life off the player
        if (collision.CompareTag("Player"))
        {
            LivesSystem livesSystem = FindObjectOfType<LivesSystem>();
            if (livesSystem != null)
            {
                livesSystem.TakeDamage(1);
                if (livesSystem.life <= 0)
                {
                    //Again if no lives reset back to menu
                    SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
                    Destroy(GameObject.FindWithTag("Theme")); // Destroy the theme so it doesnt carry over to the next scene

                    Destroy(GameController.instance.gameObject);
                    Destroy(livesSystem.gameObject);
                }
            }
            Destroy(gameObject);
        }
    }
}
