using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerSword : MonoBehaviour
{
    public int maxDurability = 100;
    public int currentDurability;

    public SwordBar swordDur;

    void Start()
    {
        currentDurability = maxDurability;
        swordDur.setMaxDurability(maxDurability);
    }

    void looseDurability(int damage)
    {
        currentDurability -= damage;
        swordDur.setDurability(currentDurability);
        ///Debug.Log("WWW");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("enemySword"))
        {
            looseDurability(10);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            looseDurability(5);
        }
    }
}
