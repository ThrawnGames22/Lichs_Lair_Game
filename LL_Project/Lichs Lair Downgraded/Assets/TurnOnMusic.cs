using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnMusic : MonoBehaviour
{
    public AudioClip NormalMusic;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().TurnOnCombatMusicManager();

        GameObject.Find("CombatAudioManager").GetComponent<CharacterSoundManager>().SwapTrack(NormalMusic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
