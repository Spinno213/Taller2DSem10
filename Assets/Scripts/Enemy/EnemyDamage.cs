using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            player.HealthModifier(damage * -1);
        }
    }
}
