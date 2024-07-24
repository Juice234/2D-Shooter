using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private int bulletHits = 0; // new variable to keep track of the number of times the bullet has hit the enemy



    //Similar collision used if the player collides with the ship take a life
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LivesSystem livesSystem = FindObjectOfType<LivesSystem>();
            if (livesSystem != null)
            {
                livesSystem.TakeDamage(1);
                if (livesSystem.life <= 0)
                {
                    Destroy(GameController.instance.gameObject);
                    Destroy(livesSystem.gameObject);
                }
            }
            Destroy(gameObject);
        }

        Bullet b = collision.GetComponent<Bullet>();
        if (b)
        {   
            
            bulletHits++; 
            if (bulletHits >= 20) // If the mother ship has been hit more than 20 times then destroy the ship and bullet, a mini boss of sort
            {
                Destroy(b.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
