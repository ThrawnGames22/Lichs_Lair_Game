using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordController : MonoBehaviour
{
    
    public static SwordController SwordControllerinstance;
    public PlayerController playerController;
    public bool CanApplyDamage = false;
    public float NextShot;
    public float CurrentDelayTimer;
       
    public bool AttackBlocked;
    public float MeleeWeaponDelay;

    
    

    [Header("Sword Damage Values")]

    public float NormalCurrentDamage;
    public float ChargedCurrentDamage;
    public float CurrentDamage;

    public bool CanUse;
    

    
    


    // Start is called before the first frame update
    void Start()
    {
        SwordControllerinstance = this;
        CurrentDamage = NormalCurrentDamage;
        CanUse = true;
        
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
      if(CanUse == true)
      {
        if(Input.GetKey(KeyCode.E))
          {
            
            SwordAttack();
            
            
          }
      }
      else
      {
        return;
      }
      if(CanUse == true)
      {
        StopCoroutine(DelayAttack());
      }
 


        
        
    }

    public void StartDamage()
    {
        CanApplyDamage = true;
        CurrentDamage = NormalCurrentDamage;
    }

    public void StopDamage()
    {
        CanApplyDamage = false;
        CurrentDamage = NormalCurrentDamage;
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

    

    public void SwordAttack()
    {

        if(AttackBlocked)
        {
            return;
        }
        playerController.WeaponAnimator.SetTrigger("Attack");
        AttackBlocked = true;
        StartCoroutine(DelayAttack());
        
    }

    public IEnumerator DelayAttack()
    {
        CanUse = false;
        yield return new WaitForSeconds(MeleeWeaponDelay);
        AttackBlocked = false;
        CanUse = true;
    }

    


    
}
