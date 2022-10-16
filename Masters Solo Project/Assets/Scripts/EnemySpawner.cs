using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawner;

    [SerializeField] private GameObject enemy;

    private void Update()
    {
        
    }

    private void SpawnEnemy()
    {
        int randomint = Random.RandomRange(1, spawner.Length);
        Transform randomspawner = spawner[randomint];
        Instantiate(enemy, randomspawner.position, randomspawner.rotation);
    }


}
