using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackEnemy : MonoBehaviour
{
    private EnemyHealth health;

    private void Awake()
    {
        health = GetComponent<EnemyHealth>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBlackBullet"))
        {
            health.HealthModifier(-1);
        }
    }
}
