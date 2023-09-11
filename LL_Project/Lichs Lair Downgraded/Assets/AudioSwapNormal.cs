using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwapNormal : MonoBehaviour
{
    
    public AudioClip NormalMusic;

    private void OnTriggerEnter(Collider other) 
    {
      if(other.CompareTag("Player"))
      {
        GameObject.Find("CombatAudioManager").GetComponent<CharacterSoundManager>().SwapTrack(NormalMusic);
      }  
    }

    
}
