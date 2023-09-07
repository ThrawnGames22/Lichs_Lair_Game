using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerTrigger : MonoBehaviour
{
    public bool PlayerHasTriggeredSpawner;
    public EnemySpawner enemySpawner;

    public bool HasDoorIntergration;

    public RoomDoor Door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
      if(other.gameObject.tag == "Player")
      {
        enemySpawner.StartCoroutine(enemySpawner.SpawnTimer());
        enemySpawner.SpawnerHasStarted = true;
        Destroy(this.gameObject);


        if(HasDoorIntergration)
        {
            Door.SpawnerIsTriggered = true;
        }
      }
    }
}