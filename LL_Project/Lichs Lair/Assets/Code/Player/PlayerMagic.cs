using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMagic : MonoBehaviour
{
    public ClassData MageClassData;
    public static PlayerMagic Instance;
    public PlayerController playerController;
    [Header("Spell Slots For Combat Spells")]
    public CombatSpell CombatSpellSlot1;
    public CombatSpell CombatSpellSlot2;

    [Header("Spell Slots For Utility And Selected Comabt Spell")]

    public CombatSpell CombatSpellToCast;
    public UtilitySpell UtilitySpell;

    public Text ManaText;

    public SlotUIController slotUIController;
    public GameObject UI;

    
    public int maxMana;
    public int currentMana;
    public float manaReplenishRate = 2f;
    public float timeBetweenCasts = 0.2f;
    public float currentCombatCastTimer;
    public float currentUtilityCastTimer;

    

    public float UtilityCoolDown;

    public GameObject GameManager;
    public AbilityList AbilityManager;

    public Transform CombatCastPoint;
    public Transform UtilityCastPointNotAttached;
    public Transform UtilityCastPointAttached;
    



    public bool castingCombatMagic1 = false;
    public bool castingCombatMagic2 = false;

    public bool castingUtilityMagic = false;

    //UI

    public ManaBar manaBar;
    public PlayerInventoryController inventoryController;

    public bool UIHasActivated = false;

    public bool StartAssigningValuesBasedOnClass = false;


    // Start is called before the first frame update
    void Start()
    {
        manaBar = GameObject.Find("Mana Slider").GetComponent<ManaBar>();
        GameManager = GameObject.Find("GameManager(Clone)");
        AbilityManager = GameManager.GetComponent<AbilityList>();
        UI = GameObject.Find("UI");
        slotUIController = UI.GetComponent<SlotUIController>();
        manaBar.slider.maxValue = maxMana;
         UtilityCoolDown = UtilitySpell.spellToCast.Lifetime * 2;
        CombatSpellToCast = CombatSpellSlot1;
        inventoryController = GameObject.Find("Item Inventory Manager").GetComponent<PlayerInventoryController>();
        

        
        
        //slotUIController = UI.GetComponent<SlotUIController>();
        //manaBar.SetMaxMana(maxMana);
        
        
        
    }

    private void Awake()
    {
      Instance = this;
      
    }

    private void OnEnable()
    {
      
      
    }

    // Update is called once per frame
    void Update()
    {
      if(!StartAssigningValuesBasedOnClass)
      {
      maxMana = MageClassData.maxMana;
      CombatSpellSlot1 = MageClassData.CombatSpell1;
      CombatSpellSlot2 = MageClassData.CombatSpell2;
      UtilitySpell = MageClassData.UtilitySpell;
      StartAssigningValuesBasedOnClass = true;
      }
        
        
        if(currentMana > maxMana)
        {
            currentMana = maxMana;
        }

        if(currentMana < 0)
        {
            currentMana = 0;
        }
        manaBar.slider.value = currentMana;
        
        
        //timeBetweenCasts = CombatSpellToCast.GetComponent<CombatSpell>().spellToCast.DelayBetweenCast;
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
           //CombatSpellToCast = CombatSpellSlot1;
        }

        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
           //CombatSpellToCast = CombatSpellSlot2;
        }
        bool hasEnoughMana = currentMana - CombatSpellSlot1.spellToCast.ManaCost >= 0f || currentMana - UtilitySpell.spellToCast.ManaCost >= 0f || currentMana - CombatSpellSlot2.spellToCast.ManaCost >= 0f;
       
        //ManaText.text = currentMana.ToString();

      if(inventoryController.InventoryIsOpen == false)
      {

      
        if(!castingCombatMagic1 && Input.GetKeyDown(KeyCode.Mouse0) && hasEnoughMana)
        {
           castingCombatMagic1 = true;
           DecreaseMana(CombatSpellSlot1.spellToCast.ManaCost);
           currentCombatCastTimer = 0;
           print("We Love Casting Combat Spells!");
           CastCombatSpell1();
           manaBar.slider.value = currentMana;
        }
        if(!castingCombatMagic2 && Input.GetKeyDown(KeyCode.Mouse1) && hasEnoughMana)
        {
           castingCombatMagic2 = true;
           DecreaseMana(CombatSpellSlot2.spellToCast.ManaCost);
           currentCombatCastTimer = 0;
           print("We Love Casting Combat Spells!");
           CastCombatSpell2();
           manaBar.slider.value = currentMana;
        }

        if(!castingUtilityMagic && Input.GetKeyDown(KeyCode.Q))
        {
           castingUtilityMagic = true;
           DecreaseMana(UtilitySpell.spellToCast.ManaCost);
           currentUtilityCastTimer = 0;
           print("We Love Casting Utility Spells!");
           CastUtilitySpell();
           manaBar.slider.value = currentMana;
        }


        
      }
      if(castingCombatMagic1)
        {
            currentCombatCastTimer += Time.deltaTime;

            if (currentCombatCastTimer > timeBetweenCasts)
            {
               castingCombatMagic1 = false;
               slotUIController.SpellCoolingImage1.gameObject.SetActive(false);
               slotUIController.SpellReadyImage1.gameObject.SetActive(true);

            } 

            if (currentCombatCastTimer < timeBetweenCasts)
            {
               slotUIController.SpellCoolingImage1.gameObject.SetActive(true);
               slotUIController.SpellReadyImage1.gameObject.SetActive(false);
            }
        }
      

        if(castingCombatMagic2)
        {
            currentCombatCastTimer += Time.deltaTime;

            if (currentCombatCastTimer > timeBetweenCasts)
            {
               castingCombatMagic2 = false;
               slotUIController.SpellCoolingImage2.gameObject.SetActive(false);
               slotUIController.SpellReadyImage2.gameObject.SetActive(true);
               
            } 

            if (currentCombatCastTimer < timeBetweenCasts)
            {
               slotUIController.SpellCoolingImage2.gameObject.SetActive(true);
               slotUIController.SpellReadyImage2.gameObject.SetActive(false);

            }
        }

        if(castingUtilityMagic)
        {
            currentUtilityCastTimer += Time.deltaTime;
            slotUIController.cooldownSlider.gameObject.SetActive(true);
            StartCoroutine(Cooldown());

            if (currentUtilityCastTimer > UtilityCoolDown)
            {
               currentUtilityCastTimer = UtilityCoolDown;
               castingUtilityMagic = false;
               
            }
            if (currentCombatCastTimer < UtilityCoolDown)
            {
               slotUIController.UtilitySpellCoolingImage.gameObject.SetActive(true);
               slotUIController.UtilitySpellReadyImage.gameObject.SetActive(false);
               

            }
            
            if (currentUtilityCastTimer == UtilityCoolDown)
            {
               slotUIController.UtilitySpellCoolingImage.gameObject.SetActive(false);
               slotUIController.UtilitySpellReadyImage.gameObject.SetActive(true);
               StopCoroutine(Cooldown());
               slotUIController.ResetCooldown();
            }

            
        }
    }

    void CastCombatSpell1()
    {
        Instantiate(CombatSpellSlot1, CombatCastPoint.position, CombatCastPoint.rotation);
    }
    void CastCombatSpell2()
    {
        Instantiate(CombatSpellSlot2, CombatCastPoint.position, CombatCastPoint.rotation);
    }

    void CastUtilitySpell()
    {
        if(UtilitySpell.IsAttachedToPlayer == false)
        {
          Instantiate(UtilitySpell, UtilityCastPointNotAttached.position, UtilityCastPointNotAttached.rotation);
        }

        if(UtilitySpell.IsAttachedToPlayer)
        {
          UtilitySpell mySpell = Instantiate(UtilitySpell, UtilityCastPointAttached.position, UtilityCastPointAttached.rotation) as UtilitySpell;
          mySpell.gameObject.transform.parent = this.gameObject.transform;
        }
    }

    public void IncreaseMana(int value)
    {
      currentMana += value;
      manaBar.slider.value = currentMana;
      //ManaText.text = currentMana.ToString();
    }

    public void DecreaseMana(int manaValue)
    {
      currentMana -= manaValue;
      manaBar.slider.value = currentMana;
    }

    public IEnumerator Cooldown()
    {
        slotUIController.cooldownSlider.value -= Time.deltaTime;
        yield return new WaitForSeconds(0);

    }

    public void ResetMana()
    {
      currentMana = maxMana;
    }
}
