using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossFightFire : MonoBehaviour
{
    public GameObject FireRing;

    public GameObject MiniBoss;

    public GameObject Spotlight;

    public bool FightHasStarted;

    public bool StartEnemyPhases;

    public bool FightHasEnded;

    public Animator FireRingAnimator;
    public Animator SpotLightAnimator;

    public float EndDelay; 

    public Transform BossSpawn;

    public List<GameObject> Boss;

    public RoomDoor roomDoor;

    // Start is called before the first frame update
    void Start()
    {
       FireRing.SetActive(false);
       //MiniBoss.SetActive(false);
       Spotlight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        FireRingAnimator.SetBool("FireSpawned", FightHasStarted);
        SpotLightAnimator.SetBool("FireLightSpawned", FightHasStarted);

        if(FightHasStarted)
        {
           if(StartEnemyPhases == false)
          {
            GameObject BossClone = Instantiate(MiniBoss, BossSpawn.transform.position, BossSpawn.transform.rotation);
            StartEnemyPhases = true;
            Boss.Add(BossClone);
            
                
            }
          
                
            
          
        
           FireRing.SetActive(true);
           //MiniBoss.SetActive(true);
           Spotlight.SetActive(true); 
           
        }

        


        if(Boss[0].GetComponent<EnemyHealth>().IsDead)
        {
            FightHasStarted = false;
            FightHasEnded = true;
            StartCoroutine(DestroyAfterFightFinished());
        }

        if(FightHasEnded == true)
        {
            
        }
    }

    public IEnumerator DestroyAfterFightFinished()
    {
        yield return new WaitForSeconds(EndDelay);
        FireRing.SetActive(false);
            
        Spotlight.SetActive(false);

        Destroy(this.gameObject);

    }
}
