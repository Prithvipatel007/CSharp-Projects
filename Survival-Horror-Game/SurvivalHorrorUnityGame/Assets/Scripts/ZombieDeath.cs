using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeath : MonoBehaviour
{
    [SerializeField]
    public int EnemyHealth = 20;

    [SerializeField]
    public GameObject Enemy;

    public int StatusCheck;

    void DamageZombie(int DamageAmount)
    {
        EnemyHealth -= DamageAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyHealth <= 0 && StatusCheck == 0)
        {
            StatusCheck = 2;
            Enemy.GetComponent<Animation>().Stop("walk");
            Enemy.GetComponent<Animation>().Play("BackFall");
        }
    }
}
