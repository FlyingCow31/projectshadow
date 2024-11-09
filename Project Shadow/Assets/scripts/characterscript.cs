using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class characterscript : MonoBehaviour
{


    public Rigidbody2D Charigidbody2D;
    public LogicManager Logic;

    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) == true) 
        {
            transform.position = transform.position + (Vector3.up * 1);
        }
        if (Input.GetKeyDown(KeyCode.A) == true)
        { 
            transform.position += (Vector3.left * 1);
            Console.WriteLine("Hello2");
        }
        if (Input.GetKeyDown(KeyCode.D) == true)
        {
            transform.position += (Vector3.right * 1);
            Console.WriteLine("Hello");
        }        
    }
}
