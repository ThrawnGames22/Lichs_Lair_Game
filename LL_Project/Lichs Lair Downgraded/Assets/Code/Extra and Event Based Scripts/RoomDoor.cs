using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDoor : MonoBehaviour
{
    

    public bool UnlockDoor;
    public bool isMagicDoor;
    public bool isNormalOpeningDoor;
    public bool isStartingDoor;
    public GameObject MagicBarrier;
    public bool MagicIsBroken;
    public bool IsInRange;

    public Animator DoorAnimator;
    public float dissolve = 2.74f;

    public List<GameObject> MagicSeals;
    public bool HasPassedThrough;

[Header("Enemy Spawner Mechanic Intergration")]
    public bool RequiresEnemiesDefeated;
    public bool EnemyGroupEliminated;

    public EnemySpawnerTrigger enemySpawnerTrigger;
    public List<GameObject> EnemiesToBeDefeated;

    public bool SpawnerIsTriggered;

    public bool HasSpawnerTrigger;
    // Start is called before the first frame update
    void Start()
    {
     /*
       if(isMagicDoor)
       {
        
        
       MagicBarrier.GetComponent<MeshRenderer>().material.SetFloat("_Dissolve_Amount", dissolve);
       MagicSeals = new  List<GameObject>(GameObject.FindGameObjectsWithTag("SealStone"));
        
       }
       else
       {
        MagicBarrier.SetActive(false);
       }

       MagicIsBroken = false;
       */

       
       
       
       
         
       
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(MagicSeals[0] == null)
        {
           foreach(GameObject seals in MagicSeals)
        {
          MagicSeals.Remove(seals);
          MagicBarrier.SetActive(false);
        } 
        }
        */
    
       DoorAnimator.SetBool("IsUnlocked", UnlockDoor);
       DoorAnimator.SetBool("HasPassedThrough", HasPassedThrough);

       if(RequiresEnemiesDefeated)
       {
        if(!HasSpawnerTrigger)
        {
        EnemiesToBeDefeated = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
         if(EnemiesToBeDefeated.Count == 0)
        {
           EnemyGroupEliminated = true;
        }
        if(EnemyGroupEliminated)
        {
            UnlockDoor = true;
        
        }
        }


       
        if(SpawnerIsTriggered)
        {
            if(HasSpawnerTrigger)
           {
            
          EnemiesToBeDefeated = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));

         foreach (GameObject Enemy in EnemiesToBeDefeated)
         {
            if(Enemy.GetComponent<EnemyHealth>().IsDead)
            {
                EnemiesToBeDefeated.Remove(Enemy);
            }

        if(EnemiesToBeDefeated.Count == 0)
        {
           EnemyGroupEliminated = true;
        }

        if(EnemyGroupEliminated)
        {
            UnlockDoor = true;
        
        }
         }
           }

        


       
        
       }
         


       }
        

       
      if(isMagicDoor)
      {
        if(MagicIsBroken)
        {
            
            
            dissolve += 10f * Time.deltaTime;
            MagicBarrier.GetComponent<MeshRenderer>().material.SetFloat("_Dissolve_Amount", dissolve);
            MagicBarrier.GetComponent<MeshCollider>().enabled = false;
        }

        if( MagicBarrier.GetComponent<MeshRenderer>().material.GetFloat("_Dissolve_Amount") > 50)
        {
            Destroy(MagicBarrier);
        }
        if(MagicSeals == null)
        {

        
        foreach(GameObject MS in MagicSeals)
        {
            
            
            if(MS.GetComponent<SealStone>().SealIsBroken)
            {
                MagicSeals.Remove(MS);
            }
            
        }
        }

        

        
      }

      if(isNormalOpeningDoor == true)
        {
            if(IsInRange == true)
            {
              
                UnlockDoor = true;
              
            }
        }

      if(MagicSeals.Count == 0)
        {
           MagicIsBroken = true;
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Player")
        {
            IsInRange = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if(other.gameObject.tag == "Player")
        {
            IsInRange = false;
        }
    }
}
