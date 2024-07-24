using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuff : MonoBehaviour
{
    public float speedReduction = 150f; 
    public float duration = 2f; 

    private bool isBuffActive = false;

    //If it collides with the player it will apply a movement speed reduction
    //I think this has some issues where if enough of these are collected the player can have negative movement 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMove playerMove = collision.GetComponent<PlayerMove>();
            if (playerMove != null && !isBuffActive)
            {
                playerMove.moveSpeed -= speedReduction;
                isBuffActive = true;
                StartCoroutine(RemoveBuff(playerMove));// After 2 seconds remove the de buff
            }
            Destroy(gameObject);

        }
        //Remove the object if it is off screen for performance 
        if (collision.CompareTag("Void"))
        {
            Destroy(gameObject);
        }
    }

    //This should de actiavte the boost after the duration peroids
    private IEnumerator RemoveBuff(PlayerMove playerMove)
    {
        yield return new WaitForSeconds(duration);
        playerMove.moveSpeed += speedReduction;
        isBuffActive = false;
    }
}
