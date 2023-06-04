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
    public bool isInCooldown;

    
    

    [Header("Sword Damage Values")]

    public int NormalCurrentDamage;
    public int ChargedCurrentDamage;
    public int CurrentDamage;

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
        //Find objects and set them in slots
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        // Set values
        if(playerController.ChargeAttackTimer > 1)
        {
          CurrentDamage = ChargedCurrentDamage;
        }
        //NormalCurrentDamage = playerController.AttackValue;


    // Sets the player based   
    if(playerController.HasActivatedWeapons)
    {
      if(PlayerController.Instance.CanUseWeapons == true)
      {
      if(CanUse == true)
      {
        if(Input.GetKey(KeyCode.E))
          {
            isInCooldown = true;
            SwordAttack();
            //PlayerHealth.Instance.currentHealth += 30f;
            //PlayerMagic.Instance.currentMana += 100;
            
            
          }
      }
      else
      {
        return;
      }
      }
      if(CanUse == true)
      {
        StopCoroutine(DelayAttack());
        //PlayerController.Instance.CanUseWeapons = true;
      }
//Cooldown
      if(isInCooldown)
      {
        playerController.CanUseWeapons = false;
      }

       if(!isInCooldown)
      {
        playerController.CanUseWeapons = true;
      }
    }
 


        
        
    }
//Animation Events
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

    
//Sword Attack
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
//Delay the attack
    public IEnumerator DelayAttack()
    {
      
        
        CanUse = false;
        yield return new WaitForSeconds(MeleeWeaponDelay);
        AttackBlocked = false;
        isInCooldown = false;
        CanUse = true;
    }

  //Collsions  
   private void OnTriggerEnter(Collider other)
   {
     if(other.gameObject.tag == "EnemyCollider")
     {
      if(CanApplyDamage == true)
      {
       other.gameObject.GetComponent<DamageManager>().enemyHealth.TakeDamage(50);
      }
      
      

       if(other.gameObject.GetComponent<DamageManager>().enemyHealth.IsDead)
        {
          PlayerHealth.Instance.currentHealth += 30f;
          PlayerMagic.Instance.currentMana += 100;
        }
     }
   }

   

    
}
