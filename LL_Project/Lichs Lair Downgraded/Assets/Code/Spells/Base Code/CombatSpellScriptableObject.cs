using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEditor;
using UnityEngine.Rendering.Universal;

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
    //THIS SCRIPT HANDLES THE DATA ABOUT THE TYPE AND USAGE OF THE SPELLS
    //Name
    public string SpellName;
    public string Description;
    //Attributes

    public CombatType combatType;
    
    //Spell Important Based Attributes that are accessed by the UtilitySpell Script
    
    public int ManaCost = 5;
    public float Lifetime = 2f;
    public float Speed = 15f;
    public float SpellRadius = 0.5f;
    //public float DelayBetweenCast;

    //Type Based Attributes that will be accessed by seperate style based scripts e.g "Fire Script" or "Posion Script"
    public int FireDamage;
    public int PosionDamage;
    public int FreezeDamage;
    public int DrainAmount;
    public float SlowSpeed;
    public int DarkenAmount;

    public Sprite SpellIcon;
    public Sprite SpellCoolingIcon;
    public GameObject SpellObject;

    public AudioClip[] SpellAudioClips;
     
   
    
}

 #if UNITY_EDITOR
[CustomEditor(typeof(CombatSpellScriptableObject))]
public class CombatSpellEditor : Editor
{
    CombatSpellScriptableObject CTS;

    void ForceSerialization()
    {
      #if UNITY_EDITOR
          UnityEditor.EditorUtility.SetDirty(this);
      #endif
    }

    void OnEnable()
    {
        CTS =(CombatSpellScriptableObject)target;
    }
//Editor Properties
    public override void OnInspectorGUI()
    {
        ForceSerialization();
        EditorUtility.SetDirty(target);
        CTS.combatType = (CombatType)EditorGUILayout.EnumPopup("CombatType", CTS.combatType);
        SerializedObject so = new SerializedObject(target);
        SerializedProperty SpellAudioProperty = so.FindProperty("SpellAudioClips");

        switch(CTS.combatType)
        {
            //Heal
            case CombatType.Fire:
            {
                CTS.SpellName = EditorGUILayout.TextField("Spell Name", CTS.SpellName);
                CTS.Description = EditorGUILayout.TextField("Description", CTS.Description);
                CTS.FireDamage = EditorGUILayout.IntField("Fire Damage Apllied", CTS.FireDamage);
                CTS.ManaCost = EditorGUILayout.IntField("Mana Cost", CTS.ManaCost);
                CTS.Lifetime = EditorGUILayout.FloatField("Lifetime", CTS.Lifetime);
                CTS.Speed = EditorGUILayout.FloatField("Speed", CTS.Speed);
                CTS.SpellRadius = EditorGUILayout.FloatField("Spell Radius", CTS.SpellRadius);
                //CTS.DelayBetweenCast = EditorGUILayout.FloatField("DelayBetweenCast", CTS.DelayBetweenCast);

                CTS.SpellIcon = (Sprite)EditorGUILayout.ObjectField("Spell Icon", CTS.SpellIcon, typeof(Sprite), false);
                CTS.SpellCoolingIcon = (Sprite)EditorGUILayout.ObjectField("Spell Cooling Icon", CTS.SpellCoolingIcon, typeof(Sprite), false);
                CTS.SpellObject = (GameObject)EditorGUILayout.ObjectField("Spell Object", CTS.SpellObject, typeof(GameObject), false);
                EditorGUILayout.PropertyField(SpellAudioProperty, true);
                so.ApplyModifiedProperties();

                break;
            }
            //Ice
            case CombatType.Ice:
            {
                CTS.SpellName = EditorGUILayout.TextField("Spell Name", CTS.SpellName);
                CTS.Description = EditorGUILayout.TextField("Description", CTS.Description);
                CTS.FreezeDamage = EditorGUILayout.IntField("Freeze Damage Applied", CTS.FreezeDamage);
                CTS.ManaCost = EditorGUILayout.IntField("Mana Cost", CTS.ManaCost);
                CTS.Lifetime = EditorGUILayout.FloatField("Lifetime", CTS.Lifetime);
                CTS.Speed = EditorGUILayout.FloatField("Speed", CTS.Speed);
                CTS.SpellRadius = EditorGUILayout.FloatField("Spell Radius", CTS.SpellRadius);
                //CTS.DelayBetweenCast = EditorGUILayout.FloatField("DelayBetweenCast", CTS.DelayBetweenCast);

                CTS.SpellIcon = (Sprite)EditorGUILayout.ObjectField("Spell Icon", CTS.SpellIcon, typeof(Sprite), false);
                CTS.SpellCoolingIcon = (Sprite)EditorGUILayout.ObjectField("Spell Cooling Icon", CTS.SpellCoolingIcon, typeof(Sprite), false);
                CTS.SpellObject = (GameObject)EditorGUILayout.ObjectField("Spell Object", CTS.SpellObject, typeof(GameObject), false);
                EditorGUILayout.PropertyField(SpellAudioProperty, true);
                so.ApplyModifiedProperties();

                break;
            }
            //Posion
            case CombatType.Posion:
            {
                CTS.SpellName = EditorGUILayout.TextField("Spell Name", CTS.SpellName);
                CTS.Description = EditorGUILayout.TextField("Description", CTS.Description);
                CTS.PosionDamage = EditorGUILayout.IntField("Poison Damage Apllied", CTS.PosionDamage);
                CTS.ManaCost = EditorGUILayout.IntField("Mana Cost", CTS.ManaCost);
                CTS.Lifetime = EditorGUILayout.FloatField("Lifetime", CTS.Lifetime);
                CTS.Speed = EditorGUILayout.FloatField("Speed", CTS.Speed);
                CTS.SpellRadius = EditorGUILayout.FloatField("Spell Radius", CTS.SpellRadius);
                //CTS.DelayBetweenCast = EditorGUILayout.FloatField("DelayBetweenCast", CTS.DelayBetweenCast);

                CTS.SpellIcon = (Sprite)EditorGUILayout.ObjectField("Spell Icon", CTS.SpellIcon, typeof(Sprite), false);
                CTS.SpellCoolingIcon = (Sprite)EditorGUILayout.ObjectField("Spell Cooling Icon", CTS.SpellCoolingIcon, typeof(Sprite), false);
                CTS.SpellObject = (GameObject)EditorGUILayout.ObjectField("Spell Object", CTS.SpellObject, typeof(GameObject), false);
                EditorGUILayout.PropertyField(SpellAudioProperty, true);
                so.ApplyModifiedProperties();
                

                break;
            }
            //Drain
            case CombatType.Drain:
            {
                CTS.SpellName = EditorGUILayout.TextField("Spell Name", CTS.SpellName);
                CTS.Description = EditorGUILayout.TextField("Description", CTS.Description);
                CTS.DrainAmount = EditorGUILayout.IntField("Drain Damage Per Second", CTS.DrainAmount);
                CTS.ManaCost = EditorGUILayout.IntField("Mana Cost", CTS.ManaCost);
                CTS.Lifetime = EditorGUILayout.FloatField("Lifetime", CTS.Lifetime);
                CTS.Speed = EditorGUILayout.FloatField("Speed", CTS.Speed);
                CTS.SpellRadius = EditorGUILayout.FloatField("Spell Radius", CTS.SpellRadius);
                //CTS.DelayBetweenCast = EditorGUILayout.FloatField("DelayBetweenCast", CTS.DelayBetweenCast);

                CTS.SpellIcon = (Sprite)EditorGUILayout.ObjectField("Spell Icon", CTS.SpellIcon, typeof(Sprite), false);
                CTS.SpellCoolingIcon = (Sprite)EditorGUILayout.ObjectField("Spell Cooling Icon", CTS.SpellCoolingIcon, typeof(Sprite), false);
                CTS.SpellObject = (GameObject)EditorGUILayout.ObjectField("Spell Object", CTS.SpellObject, typeof(GameObject), false);
                EditorGUILayout.PropertyField(SpellAudioProperty, true);
                so.ApplyModifiedProperties();
                

                break;
            }
            //Slow
            case CombatType.Slow:
            {
                CTS.SpellName = EditorGUILayout.TextField("Spell Name", CTS.SpellName);
                CTS.Description = EditorGUILayout.TextField("Description", CTS.Description);
                CTS.SlowSpeed = EditorGUILayout.FloatField("Slow Speed Damage Per Second", CTS.SlowSpeed);
                CTS.ManaCost = EditorGUILayout.IntField("Mana Cost", CTS.ManaCost);
                CTS.Lifetime = EditorGUILayout.FloatField("Lifetime", CTS.Lifetime);
                CTS.Speed = EditorGUILayout.FloatField("Speed", CTS.Speed);
                CTS.SpellRadius = EditorGUILayout.FloatField("Spell Radius", CTS.SpellRadius);
                //CTS.DelayBetweenCast = EditorGUILayout.FloatField("DelayBetweenCast", CTS.DelayBetweenCast);

                CTS.SpellIcon = (Sprite)EditorGUILayout.ObjectField("Spell Icon", CTS.SpellIcon, typeof(Sprite), false);
                CTS.SpellCoolingIcon = (Sprite)EditorGUILayout.ObjectField("Spell Cooling Icon", CTS.SpellCoolingIcon, typeof(Sprite), false);
                CTS.SpellObject = (GameObject)EditorGUILayout.ObjectField("Spell Object", CTS.SpellObject, typeof(GameObject), false);
                EditorGUILayout.PropertyField(SpellAudioProperty, true);
                so.ApplyModifiedProperties();
                

                break;
            }
            //Darken
            case CombatType.Darken:
            {
                CTS.SpellName = EditorGUILayout.TextField("Spell Name", CTS.SpellName);
                CTS.Description = EditorGUILayout.TextField("Description", CTS.Description);
                CTS.DarkenAmount = EditorGUILayout.IntField("Darken Damage", CTS.DarkenAmount);
                CTS.ManaCost = EditorGUILayout.IntField("Mana Cost", CTS.ManaCost);
                CTS.Lifetime = EditorGUILayout.FloatField("Lifetime", CTS.Lifetime);
                CTS.Speed = EditorGUILayout.FloatField("Speed", CTS.Speed);
                CTS.SpellRadius = EditorGUILayout.FloatField("Spell Radius", CTS.SpellRadius);
                //CTS.DelayBetweenCast = EditorGUILayout.FloatField("DelayBetweenCast", CTS.DelayBetweenCast);

                CTS.SpellIcon = (Sprite)EditorGUILayout.ObjectField("Spell Icon", CTS.SpellIcon, typeof(Sprite), false);
                CTS.SpellCoolingIcon = (Sprite)EditorGUILayout.ObjectField("Spell Cooling Icon", CTS.SpellCoolingIcon, typeof(Sprite), false);
                CTS.SpellObject = (GameObject)EditorGUILayout.ObjectField("Spell Object", CTS.SpellObject, typeof(GameObject), false);
                EditorGUILayout.PropertyField(SpellAudioProperty, true);
                so.ApplyModifiedProperties();
                

                break;
            }
            
        }
        
           
        
    }
    


    
}
#endif

