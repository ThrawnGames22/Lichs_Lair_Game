using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;



public class PromptAreaManager : MonoBehaviour
{
    [Header("Prompts")]

    public GameObject MagicPrompt;
    public GameObject MagicPromptArea1;
    public GameObject MagicPromptArea2;


    public GameObject PotionPrompt;

    public GameObject HealthPotion;
    public GameObject ManaPotion;


    public GameObject EnemyPrompt;
    public GameObject BasicCombatPrompt;
    public GameObject BasicAndEnemyPromptArea;

    public GameObject WeaponPrompt;

    public GameObject TrapPrompt;
    public GameObject TrapPromptArea;

    public GameObject PotionPromptArea1;
    public GameObject PotionPromptArea2;

   public bool HasSpawnedPotions;
   public bool PromptIsActive;


    public Volume volume;
    private Vignette vig;
    public float vigneteIntensity = 0.625f;
    public float normalVigneteIntensity = 0.25f;

    public Camera camera;
    public GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGet(out vig);
        vig.intensity.value = normalVigneteIntensity;
        MagicPrompt.SetActive(false);
        TrapPrompt.SetActive(false);
        EnemyPrompt.SetActive(false);
        BasicCombatPrompt.SetActive(false);
        PotionPrompt.SetActive(false);
        
        //WeaponPrompt.SetActive(false);
        
        volume.profile.TryGet(out vig);
        
    }

    // Update is called once per frame
    void Update()
    {

        //Magic
        if(MagicPrompt.active == true)
        {
          PlayerMagic.Instance.MagicPaused = true;
        }
        if(MagicPrompt.active == false)
        {
            PlayerMagic.Instance.MagicPaused = false;
        }
        //Potion
        if(PotionPrompt.active == true)
        {
          PlayerMagic.Instance.MagicPaused = true;
        }
        if(PotionPrompt.active == false)
        {
            PlayerMagic.Instance.MagicPaused = false;
        }
        //Trap
        if(TrapPrompt.active == true)
        {
          PlayerMagic.Instance.MagicPaused = true;
        }
        if(TrapPrompt.active == false)
        {
            PlayerMagic.Instance.MagicPaused = false;
        }
        //Enemy
        if(EnemyPrompt.active == true)
        {
          PlayerMagic.Instance.MagicPaused = true;
        }
        if(EnemyPrompt.active == false)
        {
            PlayerMagic.Instance.MagicPaused = false;
        }
         //Weapon Combat
        if(BasicCombatPrompt.active == true)
        {
          PlayerMagic.Instance.MagicPaused = true;
        }
        if(BasicCombatPrompt.active == false)
        {
            PlayerMagic.Instance.MagicPaused = false;
        }
        
        

        


    }
    //Magic Prompts
    public void MagicPromptStart()
    {
        MagicPrompt.SetActive(true);
        volume.profile.TryGet(out vig);
        vig.intensity.value = vigneteIntensity;
        PlayerController.Instance.speed = 0;
        
    }

    public void MagicPromptClose()
    {
        MagicPrompt.SetActive(false);
        volume.profile.TryGet(out vig);
        vig.intensity.value = normalVigneteIntensity;
        PlayerController.Instance.speed = 5;
        MagicPromptArea1.SetActive(false);
        MagicPromptArea2.SetActive(false);
        PlayerController.Instance.HasActivatedMagic = true;

    }
    //Trap Prompts

    public void TrapPromptStart()
    {
        TrapPrompt.SetActive(true);
        volume.profile.TryGet(out vig);
        vig.intensity.value = vigneteIntensity;
        PlayerController.Instance.speed = 0; 
    }

    public void TrapPromptClose()
    {
        TrapPrompt.SetActive(false);
        volume.profile.TryGet(out vig);
        vig.intensity.value = normalVigneteIntensity;
        PlayerController.Instance.speed = 5;
        TrapPromptArea.SetActive(false);
        

    }

    //Enemy and basic melee combat Prompts

    public void EnemyPromptStart()
    {
        EnemyPrompt.SetActive(true);
        volume.profile.TryGet(out vig);
        vig.intensity.value = vigneteIntensity;
        PlayerController.Instance.speed = 0;
        camera.GetComponent<CameraSmoothFollow>().target = Enemy.transform;
        camera.GetComponent<CameraSmoothFollow>().offset.x = 0.72f;
        camera.GetComponent<CameraSmoothFollow>().offset.y = 0.24f;
        camera.GetComponent<CameraSmoothFollow>().offset.z = 3.09f;

    }

    public void EnemyPromptPart2()
    {
        EnemyPrompt.SetActive(false);
        BasicCombatPrompt.SetActive(true);
        
        
    }

    public void EnemyPromptClose()
    {
        BasicCombatPrompt.SetActive(false);
        volume.profile.TryGet(out vig);
        vig.intensity.value = normalVigneteIntensity;
        PlayerController.Instance.speed = 5;
        BasicAndEnemyPromptArea.SetActive(false);
        camera.GetComponent<CameraSmoothFollow>().target = GameObject.FindGameObjectWithTag("Player").transform;
        camera.GetComponent<CameraSmoothFollow>().offset.x = 0f;
        camera.GetComponent<CameraSmoothFollow>().offset.y = 10f;
        camera.GetComponent<CameraSmoothFollow>().offset.z = 10f;
        PlayerController.Instance.HasActivatedWeapons = true;
        

    }

    public void PotionPromptStart()
    {
        PotionPrompt.SetActive(true);
        volume.profile.TryGet(out vig);
        vig.intensity.value = vigneteIntensity;
        PlayerController.Instance.speed = 0;
    }

    public void PotionPromptClose()
    {
        
        PotionPrompt.SetActive(false);
        volume.profile.TryGet(out vig);
        vig.intensity.value = normalVigneteIntensity;
        PlayerController.Instance.speed = 5;
        PotionPromptArea1.SetActive(false);
        PotionPromptArea2.SetActive(false);
        SpawnPotions();
        
        //PlayerController.Instance.HasActivatedMagic = true; 
    }

    public void SpawnPotions()
    {
      if(HasSpawnedPotions == false)
      {
        GameObject clone1;
        GameObject clone2;

        clone1 = Instantiate(HealthPotion, GameObject.FindGameObjectWithTag("Player").transform.position, GameObject.FindGameObjectWithTag("Player").transform.rotation);
        clone1 = Instantiate(ManaPotion, GameObject.FindGameObjectWithTag("Player").transform.position, GameObject.FindGameObjectWithTag("Player").transform.rotation);
        HasSpawnedPotions = true;
      }  
    }

    
}
