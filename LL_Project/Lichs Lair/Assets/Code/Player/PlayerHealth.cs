using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;
    public int currentHealth;
    public int maxHealth = 100;
    
    public HealthBar healthBar;
    public bool isTakingDamage;
    public float CurrentDamageTimer;
    public float MaxDamageTimer;

    public GameObject DamageScreen;
    public float ScreenAlpha;

    //Death Screen Attributes
    

    
    // Start is called before the first frame update
    void Start()
    {
        
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        CurrentDamageTimer = MaxDamageTimer;
        
        //DeathScreen.SetActive(false);
        
        
        

    }

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //var BScolor = BlackScreen.GetComponent<Image>().color;
        //var YDIcolor = YouDiedImage.GetComponent<Image>().color;
       healthBar.SetHealth(currentHealth);

        if(currentHealth < 0)
        {
            currentHealth = 0;
        }

        if(currentHealth == 0)
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

    public void IncreaseHealth(int value)
    {
      currentHealth += value;
      healthBar.SetHealth(currentHealth);
    }

    public void Die()
    {
        
        Destroy(this.gameObject);
        DamageScreen.SetActive(false);
        //DeathScreen.SetActive(true);
        
        
    }

    public void TakeDamage(int Damage)
    {
      currentHealth -= Damage;
      isTakingDamage = true;
      //ResetDamageFlag();
      var color = DamageScreen.GetComponent<Image>().color;
      color.a = ScreenAlpha;
      DamageScreen.GetComponent<Image>().color = color;
      
      healthBar.SetHealth(currentHealth);
    }

    public void ResetDamageFlag()
    {
        isTakingDamage = false;
    }

    

    

    //private OnTriggerEnter(Collider other)
    //{
     //   if(other.gameObject.tag == "Enemy")
      //  {
            
       // }
   // }

    
}
