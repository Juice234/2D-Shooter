using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShip : MonoBehaviour
{
    private Coroutine firingCoroutine;

    [SerializeField]
    private float bulletSpeed = 20f;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private float fireDelay = 2f;

    [SerializeField]
    private GameObject player; 

    [SerializeField]
    private Patrol patrolScript; 

    private SpriteRenderer mySprite;
    private float lastFireTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        if (mySprite == null)
        {
            mySprite = gameObject.AddComponent<SpriteRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Start firing bullets if the enemy has reached point B, in other words appeared on screen
        // Combination of enemy weapon and patrol script
        if (patrolScript.hasReachedPointB && Time.time >= lastFireTime + fireDelay)
        {
            // Fire the bullet and update lastFireTime
            Fire();
            lastFireTime = Time.time;
        }
    }

    private void Fire()
    {
        // Instantiate bullet, set velocity and position towards the player
        GameObject projectile = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Rigidbody2D rbb = projectile.GetComponent<Rigidbody2D>();

        Vector3 direction = (player.transform.position - transform.position).normalized; // Get the direction towards the player
        projectile.transform.position = transform.position + direction;
        rbb.velocity = direction * bulletSpeed; // Set the bullet's velocity in the direction of the player
    }
}
