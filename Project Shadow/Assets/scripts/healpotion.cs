using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healpotion : MonoBehaviour
{
    public LogicManager logicManager;
    public int HealInInv;
    // Start is called before the first frame update
    void Start()
    {
        HealInInv = 1;
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { 
            HealInInv = HealInInv + 1; 
            Destroy(gameObject);
            Debug.Log("CollisionHeal");
            Debug.Log(HealInInv);
        }
    }
}
