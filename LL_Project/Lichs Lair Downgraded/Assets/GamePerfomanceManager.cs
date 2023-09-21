using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePerfomanceManager : MonoBehaviour
{

    public GameObject FPSData;

    public bool TurnOnData;
    // Start is called before the first frame update
    void Start()
    {
        TurnOnData = false;
        DontDestroyOnLoad(this);

    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Keypad9))
        {
            TurnOnData = !TurnOnData;
        }

        if(TurnOnData)
        {
            FPSData.SetActive(true);
        }

        if(!TurnOnData)
        {
            FPSData.SetActive(false);
        }
    }
}
