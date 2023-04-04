using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    public static SwordController SwordControllerinstance;
    public PlayerController playerController;
    public bool CanApplyDamage = false;

    

    [Header("Sword Damage Values")]

    public float NormalCurrentDamage;
    public float ChargedCurrentDamage;
    public float CurrentDamage;

    // Start is called before the first frame update
    void Start()
    {
        SwordControllerinstance = this;
        CurrentDamage = NormalCurrentDamage;
    }

    // Update is called once per frame
    void Update()
    {
        
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        if(playerController.ChargeAttackTimer > 1)
        {
          CurrentDamage = ChargedCurrentDamage;
        }
        //NormalCurrentDamage = playerController.AttackValue;
    }

    public void StartDamage()
    {
        CanApplyDamage = true;
    }

    public void StopDamage()
    {
        CanApplyDamage = false;
    }

    public void ChangeDamageToCharged()
    {
        
        
        
        if(playerController.ChargeAttackTimer > 1)
        {
               CurrentDamage = ChargedCurrentDamage;
        }
        
      
    }

     public void ChangeDamageToNormal()
    {
      CurrentDamage = NormalCurrentDamage;
    }
}
