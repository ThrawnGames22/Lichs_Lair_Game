using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwap : MonoBehaviour
{
    public AudioClip CombatMusic;
    public AudioClip NormalMusic;

    private void OnTriggerEnter(Collider other) 
    {
      if(other.CompareTag("Player"))
      {
        GameObject.Find("CombatAudioManager").GetComponent<CharacterSoundManager>().SwapTrack(CombatMusic);
      }  
    }

    private void OnTriggerExit(Collider other) 
    {
      if(other.CompareTag("Player"))
      {
        GameObject.Find("CombatAudioManager").GetComponent<CharacterSoundManager>().SwapTrack(NormalMusic);
      }  
    }
}
