using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health;

    private void Update()
    {
        Dead();
    }

    public void HealthModifier(int amount)
    {
        health += amount;
        if (health < 0)
        {
            health = 0;
        }
    }

    void Dead()
    {        
        if(health == 0)
        {
            Destroy(gameObject);
        }
        
    }
}
