using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public float CurrentHealth;

    public EnemyHealth enemyHealth;

    public Slider HealthSlider;

    public GameObject HealthBarUI;

    
    // Start is called before the first frame update
    void Start()
    {
        HealthSlider.maxValue = enemyHealth.enemyMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = enemyHealth.enemyCurrentHealth;
        HealthSlider.value = CurrentHealth;
    }
}
