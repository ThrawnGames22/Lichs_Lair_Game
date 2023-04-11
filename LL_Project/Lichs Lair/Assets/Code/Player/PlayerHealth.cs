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
    
    // Start is called before the first frame update
    void Start()
    {
        
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    public void IncreaseHealth(int value)
    {
      currentHealth += value;
      healthBar.SetHealth(currentHealth);
    }

    public void Die()
    {
        
        Destroy(this.gameObject);
        
    }

    public void TakeDamage(int Damage)
    {
      currentHealth -= Damage;

      healthBar.SetHealth(currentHealth);
    }

    
}
