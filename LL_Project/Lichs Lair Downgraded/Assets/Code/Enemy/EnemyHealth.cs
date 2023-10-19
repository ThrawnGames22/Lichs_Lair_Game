using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyHealth : MonoBehaviour
{
    public float enemyCurrentHealth;
    public float enemyMaxHealth;
    
    [Header("Components To Destroy On Death")]
    public CapsuleCollider col;
    public NavMeshAgent agent;
    public EnemyHealth EH;
    public DetectSunlight DS;
    public EnemyController EC;
    public Rigidbody RB;

    public bool IsDead;

    public bool DisableCollider;

    public Animator HurtAnim;

    public bool IsHurt;

[Header("Audio")]

public AudioClip[] HurtSounds;
public AudioClip[] DeathSounds;
public AudioClip[] IdleSounds;

public AudioClip[] HitSounds;

public AudioSource EnemyAudioSource;
public AudioSource EnemyHitAudioSource;


public bool HasPlayedSound;




    // Start is called before the first frame update
    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;
        EnemyAudioSource.volume = 1f;
        EnemyAudioSource.spatialBlend = 1;
        EnemyAudioSource.maxDistance = 300;
        EnemyAudioSource.spread = 360;



        EnemyHitAudioSource.volume = 1f;
        EnemyHitAudioSource.spatialBlend = 1;
        EnemyHitAudioSource.maxDistance = 300;
        EnemyHitAudioSource.spread = 360;

    }

    // Update is called once per frame
    void Update()
    {
      HurtAnim.SetBool("IsHurt", IsHurt);

        // If enemy health number is lower than 0, keep it at 0
        if(enemyCurrentHealth < 0)
        {
            enemyCurrentHealth = 0;
        }
        
        // If Enemy Health is 0, Enemy Dies

        if(enemyCurrentHealth == 0)
        {
            Die();
        }

        if(DisableCollider)
        {
          this.GetComponent<CapsuleCollider>().enabled = false;
        }

        if(!DisableCollider)
        {
          this.GetComponent<CapsuleCollider>().enabled = true;
        }
    }

    // Collsion with Spells take damage
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "FireSpell")
        {
          TakeDamage(collision.gameObject.GetComponent<FireSpell>().fireDamage);
          print("Ememy Just Took Damage");
          EC.IsHitFirst = true;
        }

        if(collision.gameObject.tag == "LightningSpell")
        {
          TakeDamage(collision.gameObject.GetComponent<LightningSpell>().LightningSpellData.LightningDamage);
          print("Ememy Just Took Damage");
          EC.IsHitFirst = true;
        }

        if(collision.gameObject.name == "FireGrenade")
        {
          //enemyCurrentHealth -= collision.gameObject.GetComponent<FireSpell>().fireDamage;
          print("Ememy Just Took Damage");
          EC.IsHitFirst = true;
        }

        
    }
    

    private void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.tag == "LightningSpell")
        {
          TakeDamage(other.gameObject.GetComponent<LightningSpell>().LightningSpellData.LightningDamage);
          print("Ememy Just Took Damage");
          EC.IsHitFirst = true;
        }
        
        if(other.gameObject.tag == "DarkSpell")
        {
          TakeDamage(other.gameObject.GetComponent<DarkSlash>().DarkDamage);
          print("Ememy Just Took Damage");
          EC.IsHitFirst = true;
        }

        if(other.gameObject.tag == "FireSpell")
        {
          //TakeDamage(other.gameObject.GetComponent<DarkSlash>().DarkDamage);
          print("Ememy Just Took Damage");
          EC.IsHitFirst = true;
        }
        
    }

    //Take damage from Player or objects

    public void TakeDamage(int damageValue)
    {
        if(HasPlayedSound == false)
        {
          if(IsDead == false)
          {
            EnemyAudioSource.PlayOneShot(HurtSounds[Random.Range(0, HurtSounds.Length)]);
            EnemyHitAudioSource.PlayOneShot(HitSounds[Random.Range(0, HitSounds.Length)]);

          HasPlayedSound = true;
          }
          
        }
        IsHurt = true;
        enemyCurrentHealth -=damageValue;
        StartCoroutine(ResetHurtFlag());
    }

    //Enemy Dies

    public void Die()
    {
      IsDead = true;

       if(HasPlayedSound == false)
        {
          if(IsDead == true)
          {
            EnemyAudioSource.PlayOneShot(DeathSounds[Random.Range(0, DeathSounds.Length)]);
            //EnemyHitAudioSource.PlayOneShot(HitSounds[Random.Range(0, HitSounds.Length)]);
            
          HasPlayedSound = true;
          }
          
        }
      Destroy(col);
      Destroy(agent);
      //Destroy(EH);
      Destroy(DS);
      Destroy(EC);
      Destroy(RB);
      StartCoroutine(DestroyAfterTime());
    }

    //Destroy Object to prevent clutter in scene

    public IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(1f);
        
            Destroy(this.gameObject);
        
    }

    public IEnumerator DecreaseHealth(int damageValue)
    {
       yield return new WaitForSeconds(0);
       enemyCurrentHealth -= damageValue * Time.deltaTime;
    }

    public IEnumerator ResetHurtFlag()
    {
      yield return new WaitForSeconds(0.1f);
      IsHurt = false;
      ResetFlag();

      
    }

    public void ResetFlag()
    {
      HasPlayedSound = false;
      StopCoroutine(ResetHurtFlag());
    }
}
