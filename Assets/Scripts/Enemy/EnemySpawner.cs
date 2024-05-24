using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyToSpawn;
    [SerializeField] private bool canSpawn;
    [SerializeField] private float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Spawner();
    }

    void Spawner()
    {
        if (!canSpawn) return;
        else
        {
            GameObject EnemySpawned = Instantiate(enemyToSpawn);
            EnemySpawned.transform.position = transform.position;

            canSpawn = false;

            Invoke(nameof(ResetSpawn), spawnTime);
        }
    }

    void ResetSpawn()
    {
        canSpawn = true;
    }
}
