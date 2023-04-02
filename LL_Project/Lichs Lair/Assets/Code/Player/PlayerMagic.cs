using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMagic : MonoBehaviour
{

    public static PlayerMagic Instance;
    public PlayerController playerController;
    [Header("Spell Slots For Combat Spells")]
    public CombatSpell CombatSpellSlot1;
    public CombatSpell CombatSpellSlot2;

    [Header("Spell Slots For Utility And Selected Comabt Spell")]

    public CombatSpell CombatSpellToCast;
    public UtilitySpell UtilitySpell;

    public Text ManaText;

    
    public float maxMana = 100f;
    public float currentMana;
    public float manaReplenishRate = 2f;
    public float timeBetweenCasts = 0.25f;
    public float currentCastTimer;

    public GameObject GameManager;
    public AbilityList AbilityManager;

    public Transform castPoint;

    public bool castingMagic = false;

    // Start is called before the first frame update
    void Start()
    {
        AbilityManager = GameManager.GetComponent<AbilityList>();
    }

    private void Awake()
    {
      Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        bool hasEnoughMana = currentMana - CombatSpellToCast.spellToCast.ManaCost >= 0f || currentMana - UtilitySpell.spellToCast.ManaCost >= 0f;
       
        ManaText.text = currentMana.ToString();

        if(!castingMagic && Input.GetKeyDown(KeyCode.Mouse1) && hasEnoughMana)
        {
           castingMagic = true;
           currentMana -= CombatSpellToCast.spellToCast.ManaCost;
           currentCastTimer = 0;
           print("We Love Casting Combat Spells!");
           CastCombatSpell();
        }

        if(!castingMagic && Input.GetKeyDown(KeyCode.Q) && hasEnoughMana)
        {
           castingMagic = true;
           currentMana -= UtilitySpell.spellToCast.ManaCost;
           currentCastTimer = 0;
           print("We Love Casting Utility Spells!");
           CastUtilitySpell();
        }


        if(castingMagic)
        {
            currentCastTimer += Time.deltaTime;

            if (currentCastTimer > timeBetweenCasts) castingMagic = false;
        }
    }

    void CastCombatSpell()
    {
        Instantiate(CombatSpellToCast, castPoint.position, castPoint.rotation);
    }

    void CastUtilitySpell()
    {
        Instantiate(UtilitySpell, castPoint.position, castPoint.rotation);
    }

    public void IncreaseMana(float value)
    {
      currentMana += value;
      ManaText.text = currentMana.ToString();
    }
}
