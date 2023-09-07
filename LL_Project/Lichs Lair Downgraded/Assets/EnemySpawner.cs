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

    public GameObject CombatMusicTriggerSphere;

    public List<GameObject> EnemiesJustSpawned;

    public bool EnemiesHaveFilledTheList;
    
    
    //debug
    public bool SpawnerHasStarted;
    // Start is called before the first frame update
    void Start()
    {
        CombatMusicTriggerSphere.SetActive(false);
        EnemiesHaveFilledTheList = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(SpawnerHasStarted == true)
        {
            CombatMusicTriggerSphere.SetActive(true);

            

            
        }
        
        if(EnemiesHaveFilledTheList == true)
        {
            if(EnemiesJustSpawned.Count == 0)
            {
                CombatMusicTriggerSphere.GetComponent<CloseRangeAndDestroy>().StartCoroutine(CombatMusicTriggerSphere.GetComponent<CloseRangeAndDestroy>().CloseDestroyRange());
            }
        }

        if(EnemiesSpawned == maxEnemiesToSpawn)
        {
            StopTimer();
        }

        if(SpawnerHasStarted == false)
        {
         StopCoroutine(SpawnTimer());
        }

        

        foreach (GameObject Enemy in EnemiesJustSpawned)
            {

            if(Enemy.GetComponent<EnemyHealth>().IsDead)
            {
                EnemiesJustSpawned.Remove(Enemy);
            }

            
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
              EnemiesJustSpawned.Add(EnemyClone);
              EnemiesHaveFilledTheList = true;

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
