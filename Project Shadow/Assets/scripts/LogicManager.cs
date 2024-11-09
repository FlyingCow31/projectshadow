using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicManager : MonoBehaviour
{
    public GameObject player;
    public GameObject worm;
    public float PlayerHealth;

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
}
