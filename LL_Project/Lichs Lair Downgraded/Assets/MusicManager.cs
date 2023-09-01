using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource CombatAudioSource;
    public AudioSource AmbientAudioSource;

    public bool IsCombatTrack;
    


    public AudioClip[] CombatTracks;

    public AudioClip[] AmbientTracks;

    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
        Player = GameObject.FindGameObjectWithTag("Player");
        ReturnToAmbience();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsCombatTrack == false)
        {
            StartCoroutine(FadeAmbientTrack(AmbientTracks[UnityEngine.Random.Range(0, AmbientTracks.Length)]));
        }
    }

    public void ReturnToAmbience()
    {
        SwapToAmbientTrack(AmbientTracks[UnityEngine.Random.Range(0, AmbientTracks.Length)]);
    }

    

    public void SwapToAmbientTrack(AudioClip newClip)
    {
        StopAllCoroutines();

        StartCoroutine(FadeAmbientTrack(newClip));

        IsCombatTrack = false;
    }
    public void SwapToCombatTrack(AudioClip newClip)
    {
        StopAllCoroutines();

        StartCoroutine(FadeCombatTrack(newClip));
        IsCombatTrack = true;
    }


    public IEnumerator FadeCombatTrack(AudioClip newClip)
    {
        float timeToFade = 0.25f;
        float timeElapsed = 0;

        if(!IsCombatTrack)
        {
            //AmbientTracks[UnityEngine.Random.Range(0, AmbientTracks.Length)] = newClip;
            AmbientAudioSource.clip = newClip;
            AmbientAudioSource.Play();


            while(timeElapsed < timeToFade)
            {
                AmbientAudioSource.volume = Mathf.Lerp(0, 1, timeElapsed / timeToFade);
                CombatAudioSource.volume = Mathf.Lerp(1, 0, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
        }

        
    }
    public IEnumerator FadeAmbientTrack(AudioClip newClip)
    {
        float timeToFade = 0.25f;
        float timeElapsed = 0;
    if(IsCombatTrack)
        {
            CombatTracks[UnityEngine.Random.Range(0, CombatTracks.Length)] = newClip;
            CombatAudioSource.clip = newClip;
            CombatAudioSource.Play();

            while(timeElapsed < timeToFade)
            {
                CombatAudioSource.volume = Mathf.Lerp(0, 1, timeElapsed / timeToFade);
                AmbientAudioSource.volume = Mathf.Lerp(1, 0, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
        }
    }
    
}
