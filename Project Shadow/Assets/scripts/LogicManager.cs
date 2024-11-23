using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicManager : MonoBehaviour
{
    
    [Header("Game Objects")]
    public GameObject player;
    public GameObject worm;
    public healpotion HealPotion;

    [Header("GO Health")]
    public float PlayerHealth;

    public float WormHealth; 

    [Header("Heal System")]
    public bool hasHealed = false;
    public ParticleSystem healEffect;


    // Start is called before the first frame update
    void Start()
    {
        HealPotion = HealPotion.GetComponent<healpotion>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHealth <= 0)
        {
            Debug.Log("Game Over");
            GameOver();
        }

        if (Input.GetKeyDown("e") && hasHealed == false && HealPotion.HealInInv >= 1)
        {
            StartCoroutine(Heal());
        }
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
        HealPotion.HealInInv -= 1;
        yield return new WaitForSeconds(10);


        hasHealed = false;
    }


}
