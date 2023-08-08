using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class PlayerHealth : MonoBehaviour
{
    public ClassData MageClassData;
    public static PlayerHealth Instance;
    public float currentHealth;
    public float maxHealth;
    
    public HealthBar healthBar;
    public bool isTakingDamage;
    public float CurrentDamageTimer;
    public float MaxDamageTimer;

    public GameObject DamageScreen;
    public float ScreenAlpha;

    public bool UIHasActivated;

    public GameObject PlayerModel;
    public bool IsDead;

    //Death Screen Attributes
    
    //Potion Effects
    
    
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = MageClassData.maxHealth;
        
        
        //DeathScreen.SetActive(false);
        
        
        

    }

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(!UIHasActivated)
        {
            //Find UI components
            healthBar = GameObject.Find("Health Slider").GetComponent<HealthBar>();
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
            CurrentDamageTimer = MaxDamageTimer;
            UIHasActivated = true;
        }
        //var BScolor = BlackScreen.GetComponent<Image>().color;
        //var YDIcolor = YouDiedImage.GetComponent<Image>().color;
       healthBar.SetHealth(currentHealth);

        if(currentHealth < 0f)
        {
            currentHealth = 0f;
        }

        if(currentHealth == 0f)
        {
            Die();
            
            
            
        }
         if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if(DamageScreen != null)
        {
            if(DamageScreen.GetComponent<Image>().color.a > 0)
            {
                var color = DamageScreen.GetComponent<Image>().color;

                color.a -= 0.01f;

                DamageScreen.GetComponent<Image>().color = color;
            }
        }
    }
    // Increase Health
    public void IncreaseHealth(float value)
    {
      currentHealth += value;
      healthBar.SetHealth(currentHealth);
    }
    // Player Death attributes
    public void Die()
    {
        
        IsDead = true;
        PlayerModel.SetActive(false);
        PlayerController.Instance.characterController.enabled = false;
        DamageScreen.SetActive(false);
        //DeathScreen.SetActive(true);
        
        
    }
    // Revive Player on retry level 
    public void Revive()
    {
        IsDead = false;
        PlayerModel.SetActive(true);
        PlayerController.Instance.characterController.enabled = true;
        ResetHealth();
        PlayerMagic.Instance.ResetMana();
        DamageScreen.SetActive(true);
        PlayerController.Instance.IsInFrontCameraView = true;
        //GameObject.Find("Death Screen").GetComponent<DeathManager>().TryAgainButton.SetActive(false);

    }
    // Take Damage From enemies or traps
    public void TakeDamage(float Damage)
    {
      currentHealth -= Damage;
      isTakingDamage = true;
      //ResetDamageFlag();
      var color = DamageScreen.GetComponent<Image>().color;
      color.a = ScreenAlpha;
      DamageScreen.GetComponent<Image>().color = color;
      
      healthBar.SetHealth(currentHealth);
    }
//Animation Events to prevent constant health decreasing
    public void ResetDamageFlag()
    {
        isTakingDamage = false;
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    

    

    //private OnTriggerEnter(Collider other)
    //{
     //   if(other.gameObject.tag == "Enemy")
      //  {
            
       // }
   // }

    
}
