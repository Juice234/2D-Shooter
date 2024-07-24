using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    //On player collision replenishes a life assuming the player doesnt have 3
        private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerMove>();

        if (player)
        {
            LivesSystem livesSystem = FindObjectOfType<LivesSystem>();

            if (livesSystem != null && livesSystem.life < 3)
            {
                livesSystem.life += 1;
                livesSystem.ReplenishLife();
                Destroy(gameObject); // Destroy the collected object
            }
        }
    }
}
