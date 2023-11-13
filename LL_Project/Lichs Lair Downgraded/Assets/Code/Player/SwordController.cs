using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordController : MonoBehaviour
{
    public Weapon WeaponData;
    public static SwordController SwordControllerinstance;
    public PlayerController playerController;
    public bool CanApplyDamage = false;
    public float NextShot;
    public float CurrentDelayTimer;
       
    public bool AttackBlocked;
    public float MeleeWeaponDelay;
    public bool isInCooldown;

    public ParticleSystem SwordParticleSystem;

    public PlayerAnimationManager PAM;

    public BoxCollider boxCollider;

    
    

    [Header("Sword Damage Values")]

    public int NormalCurrentDamage;
    public int ChargedCurrentDamage;
    public int CurrentDamage;

    public bool CanUse;
    

    
    


    // Start is called before the first frame update
    void Start()
    {
      NormalCurrentDamage = WeaponData.Damage;
        SwordControllerinstance = this;
        CurrentDamage = NormalCurrentDamage;
        CanUse = true;
        SwordParticleSystem.Stop();
        
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
            PAM.StartCoroutine(PAM.Swinging());
            PAM.StartCoroutine(PAM.SwingingBoxCollider());
            

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
        //StartDamage();
      }

       if(!isInCooldown)
      {
        playerController.CanUseWeapons = true;
        //StopDamage();
        
        
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

    public void ActivateParticles()
    {
      SwordParticleSystem.Play();

    }

    public void DeactivateParticles()
    {
      SwordParticleSystem.Stop();
      
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
