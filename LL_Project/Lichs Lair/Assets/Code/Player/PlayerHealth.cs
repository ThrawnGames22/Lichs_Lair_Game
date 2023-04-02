using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;
    public float currentHealth;
    public float maxHealth = 100f;
    public Text Health;
    
    // Start is called before the first frame update
    void Start()
    {
        
        currentHealth = maxHealth;
    }

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Health.text = currentHealth.ToString();
    }

    public void IncreaseHealth(float value)
    {
      currentHealth += value;
      Health.text = currentHealth.ToString();
    }
}
