using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class PlayerHealth : MonoBehaviour
{
   
    public float currentHealth;
    public float maxHealth = 100f;
    public Text Health;
    
    // Start is called before the first frame update
    void Start()
    {
        
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Health.text = currentHealth.ToString();
    }

    public void IncreaseHealth(int value)
    {
      currentHealth += value;
    }
}
