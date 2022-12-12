using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    //spawn states
    public enum SpawnStat { SPAWNING, WAITING, COUNTING};

    //varibles
    [SerializeField] private Wave[] waves;

    [SerializeField] private float timeBetweenWaves = 3f;
    [SerializeField] private float waveCountdown = 0;

    private SpawnStat state = SpawnStat.COUNTING;

    private int currentWave;

    //References 
    [SerializeField] private Transform[] spawner;
    [SerializeField] private List<CharacterStats> enemyList;


    //sets wave countdown
    private void Start()
    {
        waveCountdown = timeBetweenWaves;
        currentWave = 0;
    }

    private void Update()
    {

        if(state == SpawnStat.WAITING)
        {
            //check if all enemies are dead
            if (!EnemiesAreDead())
                return;
            else
                CompleteWave();
                //complete The wave
        }

        if(waveCountdown <= 0)
        {
            if(state != SpawnStat.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[currentWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    //spawns starting wave
    private IEnumerator SpawnWave(Wave wave)
    {
        state = SpawnStat.SPAWNING;

        for(int i = 0; i < wave.enemiesAmount; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(wave.delay);
        }
        
        state = SpawnStat.WAITING;

        yield break;
    }

    //spawns enemies accordily
    private void SpawnEnemy(GameObject enemy)
    {
        int randomint = Random.RandomRange(1, spawner.Length);
        Transform randomspawner = spawner[randomint];

       GameObject newEnemy = Instantiate(enemy, randomspawner.position, randomspawner.rotation);
       CharacterStats newEnemyStats = newEnemy.GetComponent<CharacterStats>();

       enemyList.Add(newEnemyStats);
    }

    //check if waves of enemies are dead
    private bool EnemiesAreDead()
    {
        int i = 0;
        foreach(CharacterStats enemy in enemyList)
        {
            if (enemy.IsDead())
                i++;
            else
                return false;
        }
        return true;
    }

    //completes wave and starts new wave when enemies are dead or endscene if all rounds complete
    private void CompleteWave()
    {
        //WAVE COMPLETE 

        state = SpawnStat.COUNTING;
        waveCountdown = timeBetweenWaves;

        if(currentWave + 1 > waves.Length - 1)
        {
            currentWave = 0;
            Debug.Log("WAVE COMPLETED");
            SceneManager.LoadScene(2);
            // END GAME CONTENT
        }
        else
        {
            currentWave++;
        }        
    }
    

}
