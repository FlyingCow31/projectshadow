using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class wormscript : MonoBehaviour
{
    public GameObject character;
    public characterscript characterscript;
    public LogicManager Logic;
    public Rigidbody2D WormRB;
    public float speed;
    public float timer;
    public bool wormhit = false;

    // Start is called before the first frame update
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        WormRB = GetComponent<Rigidbody2D>();
        characterscript = character.GetComponent<characterscript>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (Logic.WormHealth <= 0)
        {
            WormDeath();
        }
    }

    public void Movement()
    {
        if (timer < 1f)
        {
            timer += 3f;
            UnityEngine.Vector2 direction = (character.transform.position - transform.position).normalized;
            WormRB.velocity = direction * speed;
            //Debug.Log("moving");
        }
        else 
        {
            timer -= Time.deltaTime;
        }
    } 

    public void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.tag == "Player" && wormhit == false)
        {
            StartCoroutine(WormAttack());
            Debug.Log("CoroutwormON");
        }
    }

    public void WormDeath()
    {
        Destroy(gameObject);
    }

    IEnumerator WormAttack()
    {
        wormhit = true;

        Logic.hit(1);
        Debug.Log("Hit");
        characterscript.movementSpeed -= 2;

        yield return new WaitForSeconds(3);

        wormhit = false;
        characterscript.movementSpeed += 2;
    }
}
