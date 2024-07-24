using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Enemy : MonoBehaviour
{
    [SerializeField] public float MoveSpeed = 3.0f;

    // How much points each enemy is worth can be changed in inspector
    public int ScoreValue = 10;
  
    public delegate void EnemyKilled(Enemy e); 

    public static EnemyKilled EnemyKilledEvent; 


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If hit by bullet destroy bullet, enemy and increase score
        Bullet b = collision.GetComponent<Bullet>();
        if(b)
        {
            Destroy(b.gameObject);
            PublishEnemyKilledEvent();
            Destroy(gameObject);
        }
        // If enemy is offscreen destroy the enemy
        if (collision.CompareTag("Void"))
        {
            Destroy(gameObject);
        }

        //If the enemy collides with the player destroy the player
        if (collision.CompareTag("Player"))
        {
            //If the player has lives take off a life
            LivesSystem livesSystem = FindObjectOfType<LivesSystem>();
            if (livesSystem != null)
            {
                livesSystem.TakeDamage(1);
                //If the player has no lives go back to the menu 
                if (livesSystem.life <= 0)
                {
                    SceneManager.LoadSceneAsync(0,LoadSceneMode.Single);
                    Destroy(GameController.instance.gameObject);
                    Destroy(livesSystem.gameObject);
                    Destroy(GameObject.FindWithTag("Theme"));// Destroy the theme so it doesnt carry over to the menu
                }
            }
            Destroy(gameObject);
        }
    }
    private void PublishEnemyKilledEvent()
    {
        
        if (EnemyKilledEvent != null)
            EnemyKilledEvent(this);
    }


}
