using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public enum UtilityType
{
    Heal,
    Protect,
    Summon

}
[CreateAssetMenu(fileName = "New Utility Spell", menuName = "Uitlity Spells")]
public class UtilitySpellScriptableObject : ScriptableObject
{
    //Name
    public string SpellName;
    public string Description;
    
    //Base Attributes

    public UtilityType utilityType;
    
    //Spell Important Based Attributes that are accessed by the UtilitySpell Script
    public float ManaCost = 5f;
    public float Lifetime = 2f;
    public float Speed = 15f;
    public float SpellRadius = 0.5f;

    //Type Based Attributes that will be accessed by seperate style based scripts e.g "Fire Script" or "Posion Script"
    public float HealthToApply;
    public GameObject SummonToSpawn;

    void init()
    {
        if(utilityType == UtilityType.Heal)
        {
          
        }
    }
}

[CustomEditor(typeof(UtilitySpellScriptableObject))]
public class UtilitySpellEditor : Editor
{
    UtilitySpellScriptableObject UTS;

    void OnEnable()
    {
        UTS =(UtilitySpellScriptableObject)target;
    }

    public override void OnInspectorGUI()
    {
        UTS.utilityType = (UtilityType)EditorGUILayout.EnumPopup("UtilityType", UTS.utilityType);

        switch(UTS.utilityType)
        {
            case UtilityType.Heal:
            {
                UTS.SpellName = EditorGUILayout.TextField("Spell Name", UTS.SpellName);
                UTS.Description = EditorGUILayout.TextField("Description", UTS.Description);
                UTS.HealthToApply = EditorGUILayout.FloatField("Health To Apply", UTS.HealthToApply);
                UTS.ManaCost = EditorGUILayout.FloatField("Mana Cost", UTS.ManaCost);
                UTS.Lifetime = EditorGUILayout.FloatField("Lifetime", UTS.Lifetime);
                UTS.Speed = EditorGUILayout.FloatField("Speed", UTS.Speed);
                UTS.SpellRadius = EditorGUILayout.FloatField("Spell Radius", UTS.SpellRadius);

                break;
            }
        }
        
           
        
    }


    
}
