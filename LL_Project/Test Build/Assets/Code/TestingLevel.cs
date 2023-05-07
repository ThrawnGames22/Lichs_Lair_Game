using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerController.Instance.HasActivatedMagic = true;
        PlayerController.Instance.HasActivatedWeapons = true;
        PlayerController.Instance.HasActivatedGameplay = true;
        PlayerController.Instance.HasAquiredWeapons = true;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
