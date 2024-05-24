using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteEnemy : MonoBehaviour
{
    private EnemyHealth health;

    private void Awake()
    {
        health = GetComponent<EnemyHealth>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerWhiteBullet"))
        {
            health.HealthModifier(-1);
        }
    }
}
