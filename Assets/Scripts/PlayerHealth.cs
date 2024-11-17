using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public PlayerHealthBar playerHB;

    void Start()
    {
        currentHealth = maxHealth;
        playerHB.setMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            takeDamage(15);
        }
    }

    void takeDamage(int damage)
    {
        currentHealth -= damage;
        playerHB.setHealth(currentHealth);
    }
}
