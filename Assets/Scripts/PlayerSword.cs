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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            looseDurability(15);
        }
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

        //if (collision.gameObject.CompareTag("Player"))
        //{
        //    addDurability(20);
        //}
    }

    //void addDurability(int addDur)
    //{
    //    currentDurability += addDur;
    //    swordDur.setDurability(currentDurability);
    //}
    void looseDurability(int damage)
    {
        currentDurability -= damage;
        swordDur.setDurability(currentDurability);
        ///Debug.Log("WWW");
    }
}
