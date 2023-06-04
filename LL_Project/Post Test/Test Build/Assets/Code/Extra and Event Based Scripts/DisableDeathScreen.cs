using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableDeathScreen : MonoBehaviour
{
    public GameObject DeathScreen;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        DeathScreen = GameObject.Find("Death Screen");
        DeathScreen.SetActive(false);
    }
}
