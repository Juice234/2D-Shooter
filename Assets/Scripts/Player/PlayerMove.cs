using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 555f;
    public float boostSpeed = 500f;
    public float boostDuration = 3f;
    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite DefaultSprite;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBody2D;
    [SerializeField] private float gravity;
    private float boostTime = 0f;
    private bool isBoostActive = false;
    public Joystick joystick;
    public bool useJoystick = true;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
            
            Vector2 movement = Vector2.zero;
            
        //Using the joystick can be set in the inspector
            if (useJoystick)
            {
                float horizontalInput = joystick.Horizontal;
                float verticalInput = joystick.Vertical;
                movement = new Vector2(horizontalInput, verticalInput).normalized;
            }
            else//Keyboard input
            {
                float horizontalInput = Input.GetAxisRaw("Horizontal");
                float verticalInput = Input.GetAxisRaw("Vertical");
                movement = new Vector2(horizontalInput, verticalInput).normalized;
            }

            
        

        //Boost the player for a duration of time
        //Done by chaning player speed
        float currentMoveSpeed = moveSpeed;
        if (isBoostActive)
        {
            currentMoveSpeed = boostSpeed;
            boostTime += Time.deltaTime;
            if (boostTime >= boostDuration)
            {
                isBoostActive = false;
                boostTime = 0f;
            }
        }

        //Binds the player to the box preventing them from going offscreen
        Vector2 newPos = (Vector2)transform.position + movement * currentMoveSpeed * Time.deltaTime;
        newPos.x = Mathf.Clamp(newPos.x, -1000f, 1000f);
        newPos.y = Mathf.Clamp(newPos.y, -500f, 500f);

        transform.position = newPos;

        //Changes type of sprite based on the direction the player is moving
        //Gravity also changes for an increased challenge
        if (movement.x > 0)
        {
            rigidBody2D.gravityScale = 0f;
            spriteRenderer.flipX = false;
            spriteRenderer.sprite = DefaultSprite;
        }
        else if (movement.x < 0)
        {
            spriteRenderer.flipX = true;
        }

        if (movement.y > 0)
        {
            rigidBody2D.gravityScale = -gravity;
            spriteRenderer.sprite = upSprite;
        }
        else if (movement.y < 0)
        {
            rigidBody2D.gravityScale = gravity;
            spriteRenderer.sprite = downSprite;
        }
        //Key used to activate boost
        if (Input.GetKeyDown(KeyCode.Space) && !isBoostActive)
        {
            isBoostActive = true;
        }
    }
}
