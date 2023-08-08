using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pet", menuName = "Pet/Create New Pet")]
public class Pet : ScriptableObject
{

    // This script is a scriptable object script that contains information about the 'Item" Class
    
    public enum PetType
    {
        Rat,
        Pheonix,
        Chicken,
        Dog,
        Cat,
        Bird,
        Lizard,
        Dragon,
        Turtle,
        Crow
    }
    public int id;
    public string PetName;
    public int value;
    public Sprite PetIcon;
    
    public GameObject PetGameObject;
    public PetType petType;
    public GameObject PetEffects;
}


