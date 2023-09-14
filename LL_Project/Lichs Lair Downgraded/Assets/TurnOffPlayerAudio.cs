using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffPlayerAudio : MonoBehaviour
{
    public bool TurnOff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(TurnOff)
        {
        GameObject.Find("CombatAudioManager").SetActive(false);
        }

        if(!TurnOff)
        {
        GameObject.Find("CombatAudioManager").SetActive(true);
        }
    }
}
