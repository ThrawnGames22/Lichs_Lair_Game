using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCanavsManager : MonoBehaviour
{
    public GameObject DeathScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void SetDeathScreenActive()
    {
        DeathScreen.SetActive(true);
    }
}
