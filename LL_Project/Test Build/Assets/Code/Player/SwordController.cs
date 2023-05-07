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
        
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        if(playerController.ChargeAttackTimer > 1)
        {
          CurrentDamage = ChargedCurrentDamage;
        }
        //NormalCurrentDamage = playerController.AttackValue;
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
        isInCooldown = false;
        CanUse = true;
    }

    
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
