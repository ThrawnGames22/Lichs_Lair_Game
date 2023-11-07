using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public enum UtilityType
{
    Heal,
    Protect,
    Summon,

    Inflict,

    Teleport

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
    public int ManaCost = 5;
    public float Lifetime = 2f;
    public float Speed = 15f;
    public float SpellRadius = 0.5f;

    public float CoolingDownTime;
    public float NormalCoolingDownTime;


    public Sprite SpellIcon;
    public Sprite SpellCoolingIcon;


    //Type Based Attributes that will be accessed by seperate style based scripts e.g "Heal Script" or "Summon Script"
    public float HealthToApply;
    public Object SummonToSpawn;
    public float SummonHealth;
    public float ProtectionAgainstEnemies;
    public GameObject SpellObject;

    public AudioClip[] SpellAudioClips;

    void OnEnable()
    {
        if(utilityType == UtilityType.Heal)
        {
          
        }

        
    }

    
    
}
#if UNITY_EDITOR
[CustomEditor(typeof(UtilitySpellScriptableObject))]
public class UtilitySpellEditor : Editor
{

    void ForceSerialization()
    {
      #if UNITY_EDITOR
          UnityEditor.EditorUtility.SetDirty(this);
      #endif
    }
    UtilitySpellScriptableObject UTS;

    void OnEnable()
    {
        UTS =(UtilitySpellScriptableObject)target;
    }

    public override void OnInspectorGUI()
    {
        ForceSerialization();
        EditorUtility.SetDirty(target);
        UTS.utilityType = (UtilityType)EditorGUILayout.EnumPopup("UtilityType", UTS.utilityType);
        SerializedObject so = new SerializedObject(target);
        SerializedProperty SpellAudioProperty = so.FindProperty("SpellAudioClips");

        switch(UTS.utilityType)
        {
            //Heal
            case UtilityType.Heal:
            {
                UTS.SpellName = EditorGUILayout.TextField("Spell Name", UTS.SpellName);
                UTS.Description = EditorGUILayout.TextField("Description", UTS.Description);
                UTS.HealthToApply = EditorGUILayout.FloatField("Health To Apply", UTS.HealthToApply);
                UTS.ManaCost = EditorGUILayout.IntField("Mana Cost", UTS.ManaCost);
                UTS.Lifetime = EditorGUILayout.FloatField("Lifetime", UTS.Lifetime);
                UTS.Speed = EditorGUILayout.FloatField("Speed", UTS.Speed);
                UTS.SpellRadius = EditorGUILayout.FloatField("Spell Radius", UTS.SpellRadius);
                UTS.SpellIcon = (Sprite)EditorGUILayout.ObjectField("Spell Icon", UTS.SpellIcon, typeof(Sprite), false);
                UTS.SpellCoolingIcon = (Sprite)EditorGUILayout.ObjectField("Spell Cooling Icon", UTS.SpellCoolingIcon, typeof(Sprite), false);
                UTS.SpellObject = (GameObject)EditorGUILayout.ObjectField("Spell Object", UTS.SpellObject, typeof(GameObject), false);
                UTS.CoolingDownTime = EditorGUILayout.FloatField("Cooldown Time", UTS.CoolingDownTime);
                UTS.NormalCoolingDownTime = EditorGUILayout.FloatField("Normal Cooldown Time", UTS.NormalCoolingDownTime);

                EditorGUILayout.PropertyField(SpellAudioProperty, true);
                so.ApplyModifiedProperties();


                break;
            }
            //Protect
            case UtilityType.Protect:
            {
                UTS.SpellName = EditorGUILayout.TextField("Spell Name", UTS.SpellName);
                UTS.Description = EditorGUILayout.TextField("Description", UTS.Description);
                UTS.ProtectionAgainstEnemies = EditorGUILayout.FloatField("Protection Against Enemies", UTS.ProtectionAgainstEnemies);
                UTS.ManaCost = EditorGUILayout.IntField("Mana Cost", UTS.ManaCost);
                UTS.Lifetime = EditorGUILayout.FloatField("Lifetime", UTS.Lifetime);
                UTS.Speed = EditorGUILayout.FloatField("Speed", UTS.Speed);
                UTS.SpellRadius = EditorGUILayout.FloatField("Spell Radius", UTS.SpellRadius);
                UTS.SpellIcon = (Sprite)EditorGUILayout.ObjectField("Spell Icon", UTS.SpellIcon, typeof(Sprite), false);
                UTS.SpellCoolingIcon = (Sprite)EditorGUILayout.ObjectField("Spell Cooling Icon", UTS.SpellCoolingIcon, typeof(Sprite), false);
                UTS.SpellObject = (GameObject)EditorGUILayout.ObjectField("Spell Object", UTS.SpellObject, typeof(GameObject), false);
                UTS.CoolingDownTime = EditorGUILayout.FloatField("Cooldown Time", UTS.CoolingDownTime);
                UTS.NormalCoolingDownTime = EditorGUILayout.FloatField("Normal Cooldown Time", UTS.NormalCoolingDownTime);


                EditorGUILayout.PropertyField(SpellAudioProperty, true);
                so.ApplyModifiedProperties();

                break;
            }
            //Summon
            case UtilityType.Summon:
            {
                UTS.SpellName = EditorGUILayout.TextField("Spell Name", UTS.SpellName);
                UTS.Description = EditorGUILayout.TextField("Description", UTS.Description);
                UTS.SummonToSpawn = EditorGUILayout.ObjectField("Summon Object",UTS.SummonToSpawn, typeof(Object), true);
                UTS.SummonHealth = EditorGUILayout.FloatField("Summon Health", UTS.SummonHealth);
                UTS.ManaCost = EditorGUILayout.IntField("Mana Cost", UTS.ManaCost);
                UTS.Lifetime = EditorGUILayout.FloatField("Lifetime", UTS.Lifetime);
                UTS.Speed = EditorGUILayout.FloatField("Speed", UTS.Speed);
                UTS.SpellRadius = EditorGUILayout.FloatField("Spell Radius", UTS.SpellRadius);
                UTS.SpellIcon = (Sprite)EditorGUILayout.ObjectField("Spell Icon", UTS.SpellIcon, typeof(Sprite), false);
                UTS.SpellCoolingIcon = (Sprite)EditorGUILayout.ObjectField("Spell Cooling Icon", UTS.SpellCoolingIcon, typeof(Sprite), false);
                UTS.SpellObject = (GameObject)EditorGUILayout.ObjectField("Spell Object", UTS.SpellObject, typeof(GameObject), false);
                UTS.CoolingDownTime = EditorGUILayout.FloatField("Cooldown Time", UTS.CoolingDownTime);
                UTS.NormalCoolingDownTime = EditorGUILayout.FloatField("Normal Cooldown Time", UTS.NormalCoolingDownTime);


                EditorGUILayout.PropertyField(SpellAudioProperty, true);
                so.ApplyModifiedProperties();

                break;
            }

             case UtilityType.Inflict:
            {
                UTS.SpellName = EditorGUILayout.TextField("Spell Name", UTS.SpellName);
                UTS.Description = EditorGUILayout.TextField("Description", UTS.Description);
                UTS.SummonToSpawn = EditorGUILayout.ObjectField("Summon Object",UTS.SummonToSpawn, typeof(Object), true);
                UTS.SummonHealth = EditorGUILayout.FloatField("Summon Health", UTS.SummonHealth);
                UTS.ManaCost = EditorGUILayout.IntField("Mana Cost", UTS.ManaCost);
                UTS.Lifetime = EditorGUILayout.FloatField("Lifetime", UTS.Lifetime);
                UTS.Speed = EditorGUILayout.FloatField("Speed", UTS.Speed);
                UTS.SpellRadius = EditorGUILayout.FloatField("Spell Radius", UTS.SpellRadius);
                UTS.SpellIcon = (Sprite)EditorGUILayout.ObjectField("Spell Icon", UTS.SpellIcon, typeof(Sprite), false);
                UTS.SpellCoolingIcon = (Sprite)EditorGUILayout.ObjectField("Spell Cooling Icon", UTS.SpellCoolingIcon, typeof(Sprite), false);
                UTS.SpellObject = (GameObject)EditorGUILayout.ObjectField("Spell Object", UTS.SpellObject, typeof(GameObject), false);
                UTS.CoolingDownTime = EditorGUILayout.FloatField("Cooldown Time", UTS.CoolingDownTime);
                UTS.NormalCoolingDownTime = EditorGUILayout.FloatField("Normal Cooldown Time", UTS.NormalCoolingDownTime);


                EditorGUILayout.PropertyField(SpellAudioProperty, true);
                so.ApplyModifiedProperties();

                break;
            }

            case UtilityType.Teleport:
            {
                UTS.SpellName = EditorGUILayout.TextField("Spell Name", UTS.SpellName);
                UTS.Description = EditorGUILayout.TextField("Description", UTS.Description);
                UTS.SummonToSpawn = EditorGUILayout.ObjectField("Summon Object",UTS.SummonToSpawn, typeof(Object), true);
                UTS.SummonHealth = EditorGUILayout.FloatField("Summon Health", UTS.SummonHealth);
                UTS.ManaCost = EditorGUILayout.IntField("Mana Cost", UTS.ManaCost);
                UTS.Lifetime = EditorGUILayout.FloatField("Lifetime", UTS.Lifetime);
                UTS.Speed = EditorGUILayout.FloatField("Speed", UTS.Speed);
                UTS.SpellRadius = EditorGUILayout.FloatField("Spell Radius", UTS.SpellRadius);
                UTS.SpellIcon = (Sprite)EditorGUILayout.ObjectField("Spell Icon", UTS.SpellIcon, typeof(Sprite), false);
                UTS.SpellCoolingIcon = (Sprite)EditorGUILayout.ObjectField("Spell Cooling Icon", UTS.SpellCoolingIcon, typeof(Sprite), false);
                UTS.SpellObject = (GameObject)EditorGUILayout.ObjectField("Spell Object", UTS.SpellObject, typeof(GameObject), false);
                UTS.CoolingDownTime = EditorGUILayout.FloatField("Cooldown Time", UTS.CoolingDownTime);
                UTS.NormalCoolingDownTime = EditorGUILayout.FloatField("Normal Cooldown Time", UTS.NormalCoolingDownTime);


                EditorGUILayout.PropertyField(SpellAudioProperty, true);
                so.ApplyModifiedProperties();

                break;
            }
        }
        
           
        
    }


    
}
#endif
