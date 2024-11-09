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
    public float jumphight;
  

    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        Charigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Charigidbody2D.velocity = new Vector2(horizontalInput * movementSpeed, Charigidbody2D.velocity.y);
    
        if (Input.GetKeyDown("w") && isOnFloor)
        {
            Charigidbody2D.velocity = new Vector2(Charigidbody2D.velocity.x, jumphight);
            Debug.Log("Jump");
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            dash();
        }
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

    public void dash()
    {
    
    }
}
