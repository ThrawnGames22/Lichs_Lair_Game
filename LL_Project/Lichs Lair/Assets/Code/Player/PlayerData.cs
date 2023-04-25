using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerData", menuName = "PlayerDta/Create New PlayerData")]
public class PlayerData : ScriptableObject
{
    
    public int CurrentHealth;
    public int CurrentMana;

    

    public Vector3 CurrentPositionInLevel;
}
