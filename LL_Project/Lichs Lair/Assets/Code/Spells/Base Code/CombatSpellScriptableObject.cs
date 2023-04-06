using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEditor;

public enum CombatType
{
    Fire,
    Ice,
    Posion,
    Drain,
    Slow,
    Darken

}
[CreateAssetMenu(fileName = "New Combat Spell", menuName = "Combat Spells")]
public class CombatSpellScriptableObject : ScriptableObject
{
    
    //Name
    public string SpellName;
    public string Description;
    //Attributes

    public CombatType combatType;
    
    //Spell Important Based Attributes that are accessed by the UtilitySpell Script
    
    public float ManaCost = 5f;
    public float Lifetime = 2f;
    public float Speed = 15f;
    public float SpellRadius = 0.5f;
    //public float DelayBetweenCast;

    //Type Based Attributes that will be accessed by seperate style based scripts e.g "Fire Script" or "Posion Script"
    public float FireDamage;
    public float PosionDamage;
    public float FreezeDamage;
    public float DrainAmount;
    public float SlowSpeed;
    public float DarkenAmount;

    public Sprite SpellIcon;
    public Sprite SpellCoolingIcon;
     
   
    
}
[CustomEditor(typeof(CombatSpellScriptableObject))]
public class CombatSpellEditor : Editor
{
    CombatSpellScriptableObject CTS;

    

    void OnEnable()
    {
        CTS =(CombatSpellScriptableObject)target;
    }
//Editor Properties
    public override void OnInspectorGUI()
    {
        CTS.combatType = (CombatType)EditorGUILayout.EnumPopup("CombatType", CTS.combatType);

        switch(CTS.combatType)
        {
            //Heal
            case CombatType.Fire:
            {
                CTS.SpellName = EditorGUILayout.TextField("Spell Name", CTS.SpellName);
                CTS.Description = EditorGUILayout.TextField("Description", CTS.Description);
                CTS.FireDamage = EditorGUILayout.FloatField("Fire Damage Apllied", CTS.FireDamage);
                CTS.ManaCost = EditorGUILayout.FloatField("Mana Cost", CTS.ManaCost);
                CTS.Lifetime = EditorGUILayout.FloatField("Lifetime", CTS.Lifetime);
                CTS.Speed = EditorGUILayout.FloatField("Speed", CTS.Speed);
                CTS.SpellRadius = EditorGUILayout.FloatField("Spell Radius", CTS.SpellRadius);
                //CTS.DelayBetweenCast = EditorGUILayout.FloatField("DelayBetweenCast", CTS.DelayBetweenCast);

                CTS.SpellIcon = (Sprite)EditorGUILayout.ObjectField("Spell Icon", CTS.SpellIcon, typeof(Sprite), false);
                CTS.SpellCoolingIcon = (Sprite)EditorGUILayout.ObjectField("Spell Cooling Icon", CTS.SpellCoolingIcon, typeof(Sprite), false);

                break;
            }
            //Ice
            case CombatType.Ice:
            {
                CTS.SpellName = EditorGUILayout.TextField("Spell Name", CTS.SpellName);
                CTS.Description = EditorGUILayout.TextField("Description", CTS.Description);
                CTS.FreezeDamage = EditorGUILayout.FloatField("Freeze Damage Applied", CTS.FreezeDamage);
                CTS.ManaCost = EditorGUILayout.FloatField("Mana Cost", CTS.ManaCost);
                CTS.Lifetime = EditorGUILayout.FloatField("Lifetime", CTS.Lifetime);
                CTS.Speed = EditorGUILayout.FloatField("Speed", CTS.Speed);
                CTS.SpellRadius = EditorGUILayout.FloatField("Spell Radius", CTS.SpellRadius);
                //CTS.DelayBetweenCast = EditorGUILayout.FloatField("DelayBetweenCast", CTS.DelayBetweenCast);

                CTS.SpellIcon = (Sprite)EditorGUILayout.ObjectField("Spell Icon", CTS.SpellIcon, typeof(Sprite), false);
                CTS.SpellCoolingIcon = (Sprite)EditorGUILayout.ObjectField("Spell Cooling Icon", CTS.SpellCoolingIcon, typeof(Sprite), false);

                break;
            }
            //Posion
            case CombatType.Posion:
            {
                CTS.SpellName = EditorGUILayout.TextField("Spell Name", CTS.SpellName);
                CTS.Description = EditorGUILayout.TextField("Description", CTS.Description);
                CTS.PosionDamage = EditorGUILayout.FloatField("Poison Damage Apllied", CTS.PosionDamage);
                CTS.ManaCost = EditorGUILayout.FloatField("Mana Cost", CTS.ManaCost);
                CTS.Lifetime = EditorGUILayout.FloatField("Lifetime", CTS.Lifetime);
                CTS.Speed = EditorGUILayout.FloatField("Speed", CTS.Speed);
                CTS.SpellRadius = EditorGUILayout.FloatField("Spell Radius", CTS.SpellRadius);
                //CTS.DelayBetweenCast = EditorGUILayout.FloatField("DelayBetweenCast", CTS.DelayBetweenCast);

                CTS.SpellIcon = (Sprite)EditorGUILayout.ObjectField("Spell Icon", CTS.SpellIcon, typeof(Sprite), false);
                CTS.SpellCoolingIcon = (Sprite)EditorGUILayout.ObjectField("Spell Cooling Icon", CTS.SpellCoolingIcon, typeof(Sprite), false);

                break;
            }
            //Drain
            case CombatType.Drain:
            {
                CTS.SpellName = EditorGUILayout.TextField("Spell Name", CTS.SpellName);
                CTS.Description = EditorGUILayout.TextField("Description", CTS.Description);
                CTS.DrainAmount = EditorGUILayout.FloatField("Drain Damage Per Second", CTS.DrainAmount);
                CTS.ManaCost = EditorGUILayout.FloatField("Mana Cost", CTS.ManaCost);
                CTS.Lifetime = EditorGUILayout.FloatField("Lifetime", CTS.Lifetime);
                CTS.Speed = EditorGUILayout.FloatField("Speed", CTS.Speed);
                CTS.SpellRadius = EditorGUILayout.FloatField("Spell Radius", CTS.SpellRadius);
                //CTS.DelayBetweenCast = EditorGUILayout.FloatField("DelayBetweenCast", CTS.DelayBetweenCast);

                CTS.SpellIcon = (Sprite)EditorGUILayout.ObjectField("Spell Icon", CTS.SpellIcon, typeof(Sprite), false);
                CTS.SpellCoolingIcon = (Sprite)EditorGUILayout.ObjectField("Spell Cooling Icon", CTS.SpellCoolingIcon, typeof(Sprite), false);

                break;
            }
            //Slow
            case CombatType.Slow:
            {
                CTS.SpellName = EditorGUILayout.TextField("Spell Name", CTS.SpellName);
                CTS.Description = EditorGUILayout.TextField("Description", CTS.Description);
                CTS.SlowSpeed = EditorGUILayout.FloatField("Slow Speed Damage Per Second", CTS.SlowSpeed);
                CTS.ManaCost = EditorGUILayout.FloatField("Mana Cost", CTS.ManaCost);
                CTS.Lifetime = EditorGUILayout.FloatField("Lifetime", CTS.Lifetime);
                CTS.Speed = EditorGUILayout.FloatField("Speed", CTS.Speed);
                CTS.SpellRadius = EditorGUILayout.FloatField("Spell Radius", CTS.SpellRadius);
                //CTS.DelayBetweenCast = EditorGUILayout.FloatField("DelayBetweenCast", CTS.DelayBetweenCast);

                CTS.SpellIcon = (Sprite)EditorGUILayout.ObjectField("Spell Icon", CTS.SpellIcon, typeof(Sprite), false);
                CTS.SpellCoolingIcon = (Sprite)EditorGUILayout.ObjectField("Spell Cooling Icon", CTS.SpellCoolingIcon, typeof(Sprite), false);

                break;
            }
            //Darken
            case CombatType.Darken:
            {
                CTS.SpellName = EditorGUILayout.TextField("Spell Name", CTS.SpellName);
                CTS.Description = EditorGUILayout.TextField("Description", CTS.Description);
                CTS.DarkenAmount = EditorGUILayout.FloatField("Darken Damage Per Second", CTS.DarkenAmount);
                CTS.ManaCost = EditorGUILayout.FloatField("Mana Cost", CTS.ManaCost);
                CTS.Lifetime = EditorGUILayout.FloatField("Lifetime", CTS.Lifetime);
                CTS.Speed = EditorGUILayout.FloatField("Speed", CTS.Speed);
                CTS.SpellRadius = EditorGUILayout.FloatField("Spell Radius", CTS.SpellRadius);
                //CTS.DelayBetweenCast = EditorGUILayout.FloatField("DelayBetweenCast", CTS.DelayBetweenCast);

                CTS.SpellIcon = (Sprite)EditorGUILayout.ObjectField("Spell Icon", CTS.SpellIcon, typeof(Sprite), false);
                CTS.SpellCoolingIcon = (Sprite)EditorGUILayout.ObjectField("Spell Cooling Icon", CTS.SpellCoolingIcon, typeof(Sprite), false);

                break;
            }
            
        }
        
           
        
    }


    
}

