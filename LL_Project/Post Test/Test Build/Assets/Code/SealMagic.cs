using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealMagic : MonoBehaviour
{
    public SealStone sealStone;
    public GameObject SealWave;
    public GameObject SealMagicObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(sealStone.SealIsBroken)
        {
          SealMagicObject.SetActive(false);
          SealWave.SetActive(true);
        }
    }
}
