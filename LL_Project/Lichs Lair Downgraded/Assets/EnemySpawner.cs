using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] EnemiesToSpawn;

    public Transform EnemySpawnPoint;

    public Transform[] MultipleEnemySpawnPoints;

    public Animator SpawnerAnimator;

    public EnemySpawnerTrigger enemySpawnerTrigger;

    

    public float SpawnerDelay;

    public int maxEnemiesToSpawn;

    public int EnemiesSpawned;

    public bool hasMoreThanOneSpawnerLocation;
    
    
    //debug
    public bool SpawnerHasStarted;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        

        if(EnemiesSpawned == maxEnemiesToSpawn)
        {
            StopTimer();
        }

        if(SpawnerHasStarted == false)
        {
         StopCoroutine(SpawnTimer());
        }
    }

    public IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(SpawnerDelay);
        EnemiesSpawned += 1;

        if(!hasMoreThanOneSpawnerLocation)
        {
        GameObject EnemyClone = Instantiate(EnemiesToSpawn[Random.Range(0, EnemiesToSpawn.Length)], EnemySpawnPoint.position, EnemySpawnPoint.rotation);
        }

        if(hasMoreThanOneSpawnerLocation)
        {
            foreach(Transform Spawn in MultipleEnemySpawnPoints)
            {
             GameObject EnemyClone = Instantiate(EnemiesToSpawn[Random.Range(0, EnemiesToSpawn.Length)], Spawn.position, Spawn.rotation); 
            }
        }

        if(EnemiesSpawned <= maxEnemiesToSpawn - 1)
        {
        StartCoroutine(SpawnTimer());
        }
        else
        {
          StopCoroutine(SpawnTimer()); 
          enemySpawnerTrigger.PlayerHasTriggeredSpawner = false;
          Destroy(enemySpawnerTrigger.gameObject);
        }


    }

    public void StopTimer()
    {
        
        SpawnerHasStarted = false;
    }
}
