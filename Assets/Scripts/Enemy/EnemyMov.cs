using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyMov : MonoBehaviour
{
    [SerializeField]
    private float speed = 8.0f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //Used for the power UP/DOWN movement 
    void Update()
    {
        // Move the enemy down
        rb.velocity = Vector2.down * speed;
    }



}
