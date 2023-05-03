using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerData", menuName = "PlayerDta/Create New PlayerData")]
public class PlayerData : ScriptableObject
{
    
    public float CurrentHealth;
    public int CurrentMana;

    

    public Vector3 CurrentPositionInLevel;
}
