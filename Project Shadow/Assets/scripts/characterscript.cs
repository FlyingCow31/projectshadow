using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class characterscript : MonoBehaviour
{


    public Rigidbody2D Charigidbody2D;
    public LogicManager Logic;
    private bool isOnFloor = false;
    public float movementSpeed;
    public float jumpHeight;

    [Header("Dash Settings")]
    public float dashSpeed = 20f; //How fast the dash is
    public float dashDuration = 1f; //How long each dash lasts
    private bool isDashing = false;
    //seting up is dashing to false by default
    private float dashCooldown = 1f; // Time between dashes
    private float lastDashTime = -3f; //Time since last dash

    void Start()
    {
        Logic = GameObject.FindWithTag("Logic").GetComponent<LogicManager>();
        Charigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Charigidbody2D.velocity = new Vector2(horizontalInput * movementSpeed, Charigidbody2D.velocity.y);
    
        if (Input.GetKeyDown("w") && isOnFloor)
        {
            Charigidbody2D.velocity = new Vector2(Charigidbody2D.velocity.x, jumpHeight);
            Debug.Log("Jump");
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time >= lastDashTime + dashCooldown)
        {
            StartCoroutine(Dash());
            Debug.Log("Dashing");
        }
        // If the left shift key is pressed and the last time the chara. dash is less than -10 + 1 
        // then start the coroutine (which pauses the game without pausing it and returns to the last frame)
        if (isDashing == true)
        {
            Debug.Log("True");
        }


        // Character flip to fix dash direction
        if (horizontalInput > 0 && transform.localScale.x < 0)
        {
            Flip();
        }
        // If the horizontal input is greater than 0 and the character is facing left, then flip the character to the right.
        else if (horizontalInput < 0 && transform.localScale.x > 0)
        {
            Flip();
        }
        // If the horizontal input is less than 0 and chara is facing right (after 0 is right)
        // then flip it to the left.
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnFloor = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnFloor = false;
        }
    }

    IEnumerator Dash()
    { 
        isDashing = true;
        lastDashTime = Time.time; //Records the dash time 

        float dashDirection = transform.localScale.x; //get the side of the character, if it's -1 then he is looking left, if 1 right. 
        
        Charigidbody2D.velocity = new Vector2(dashDirection * dashSpeed, Charigidbody2D.velocity.y);
        yield return new WaitForSeconds(dashDuration);

        isDashing = false;
    }
    void FixedUpdate()
    {
        if (isDashing)
        {
            float dashDirection = transform.localScale.x;
            Charigidbody2D.velocity = new Vector2(dashDirection * dashSpeed, Charigidbody2D.velocity.y);
        }
        //make this code run before update so it can be used in the update function
    }

    void Flip()
    {
        Vector3 characterScale = transform.localScale;
        // get the local scale of the character
        characterScale.x *= -1;
        // flip the character
        transform.localScale = characterScale;
        //the chara's scale is now the flipped scale
    }
    
}



    
