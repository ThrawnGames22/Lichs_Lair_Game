using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aura : MonoBehaviour
{
    public GameObject Player;
    public GameObject AuraEffect;
    // Start is called before the first frame update
    void Start()
    {
      Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttachAuraToPlayer()
    {
        AuraEffect.transform.parent = Player.transform;
    }
}
