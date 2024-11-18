using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public PlayerHealthBar playerHB;
    private PlayerSword swordDB;
    public SwordBar swordDBar;

    void Start()
    {
        currentHealth = maxHealth;
        playerHB.setMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            takeDamage(15);
        }
    }

    void takeDamage(int damage)
    {
        currentHealth -= damage;
        playerHB.setHealth(currentHealth);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("heart"))
        {
            increaseHealth(20);
        }

        if (collision.gameObject.CompareTag("ore"))
        {
            addDurability(20);
        }
    }

    void addDurability(int addDur)
    {
        swordDB.currentDurability += addDur;
        swordDBar.setDurability(swordDB.currentDurability);
    }

    void increaseHealth(int addHealth)
    {
        currentHealth += addHealth;
        playerHB.setHealth(currentHealth);
    }
}
