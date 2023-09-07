using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class CharacterSoundManager : MonoBehaviour
{
    public GameObject Player;
    
    public AudioClip CombatMusic;
    public AudioClip NormalMusic;

    public GameObject NearestEnemy;

    public float DistanceBetweenEnemyAndPlayer;
    public float DangerDistance = 5;

    public bool IsInRangeOfEnemy = false;
    public bool IsSafe = true;
    private GameObject target;

    public AudioSource CBMusicSource;
    public AudioSource NMMusicSource;

    public AudioClip DefaultAmbience;

    public float minVolume = 0;
    public float MaxVolume = 1;


    public bool HasPlayedMusic = false;

    public bool isPlayingCombatTrack;
    

  


    private GameObject FindClosestEnemyWithinRange(float range)
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
            
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;

            if (curDistance <= range && curDistance < distance)
            {
                closest = go;
                distance = curDistance;
                
            }
           
        }

        return closest;
    }
    // Start is called before the first frame update
    void Start()
    {
        //CombatSoundManager.PlayMusic(gameObject, NormalMusic);

        ReturnToDefault();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        NearestEnemy = FindClosestEnemyWithinRange(76);
        

        if(NearestEnemy != null)
        {
            IsInRangeOfEnemy = true;
            
            
            
            

        }
        else
        {
            IsInRangeOfEnemy = false;
            
            
        }
        
        
       //Normal Zone
       if(IsInRangeOfEnemy == true)
       {
         //isPlayingCombatTrack = true;
        
       }

       if(IsInRangeOfEnemy == false)
       {
        //isPlayingCombatTrack = false;
        

         
       }

       
      
    
       
    
    }

    public void SwapTrack(AudioClip newClip)
    {
       StopAllCoroutines();
        
       StartCoroutine(FadeTrack(newClip));

       isPlayingCombatTrack = !isPlayingCombatTrack;
       
       
    }

    public void ReturnToDefault()
    {
        SwapTrack(DefaultAmbience);
    }

    


    private IEnumerator FadeTrack(AudioClip newClip)
    {
        float timeElapsed = 0;
        float timeToFade = 2.25f;
        if(isPlayingCombatTrack)
        {
            NMMusicSource.clip = newClip;
            NMMusicSource.Play();
            
            while(timeElapsed < timeToFade)
            {
                NMMusicSource.volume = Mathf.Lerp(0, 1, timeElapsed / timeToFade);
                CBMusicSource.volume = Mathf.Lerp(1, 0, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            CBMusicSource.Stop();
        }
        else
        {
            CBMusicSource.clip = newClip;
            CBMusicSource.Play();
            
            while(timeElapsed < timeToFade)
            {
                NMMusicSource.volume = Mathf.Lerp(1, 0, timeElapsed / timeToFade);
                CBMusicSource.volume = Mathf.Lerp(0, 1, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;

                yield return null;
            }

            NMMusicSource.Stop();
        }
    }
    
    

   

   

    

    

    

    
}
