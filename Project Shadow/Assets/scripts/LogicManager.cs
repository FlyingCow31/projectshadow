using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicManager : MonoBehaviour
{
    public GameObject player;
    public GameObject worm;
    public float PlayerHealth;

    public float WormHealth;

    public bool hasHealed = false;

    public ParticleSystem healEffect;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHealth <= 0)
        {
            Debug.Log("Game Over");
            GameOver();
        }

        if (Input.GetKeyDown("e") && hasHealed == false)
        {
            StartCoroutine(Heal());
        }
        // TODO : Add heal potion condition. 
    }


    public void hit(int damage)
    {
        PlayerHealth = PlayerHealth - damage;
        Debug.Log(PlayerHealth);
    }


    public void GameOver()
    {
        player.SetActive(false);
        worm.SetActive(false);
    }

    IEnumerator Heal()
    {
        hasHealed = true;

        PlayerHealth = PlayerHealth + 1;
        healEffect.Play();
        yield return new WaitForSeconds(10);


        hasHealed = false;
    }


}
