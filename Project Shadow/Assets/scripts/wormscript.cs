using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class wormscript : MonoBehaviour
{
    public GameObject character;
    public LogicManager Logic;
    public float speed;
    public float timer;



    // Start is called before the first frame update
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        if (timer < 1f)
        {
            transform.position = UnityEngine.Vector3.MoveTowards(transform.position, character.transform.position, speed * Time.deltaTime);
            timer += 4f;
            //Debug.Log("moving");
        }
        else 
        {
            timer -= Time.deltaTime;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.tag == "Player")
        {
            Logic.hit(1);
            Debug.Log("Hit");
        }
    }
}