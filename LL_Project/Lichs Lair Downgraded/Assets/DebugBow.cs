using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;

public class DebugBow : MonoBehaviour
{

    public PlayerAnimationManager playerAnimationManager;

    public Toggle BowToggle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerAnimationManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAnimationManager>();
        
        if(playerAnimationManager.IsUsingBow == true)
        {
            BowToggle.isOn = true;
        }

        if(playerAnimationManager.IsUsingBow == false)
        {
            BowToggle.isOn = false;
        }
    }
}
