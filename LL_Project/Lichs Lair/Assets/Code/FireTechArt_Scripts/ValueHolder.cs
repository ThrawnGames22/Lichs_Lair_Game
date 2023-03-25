using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Holder")]
public class ValueHolder : ScriptableObject
{
    //FireSpawn Values
    public float fireSpawnFrequency = 1;

    //Fire Values
    public float fireLifetime;
    public Color fireStartColour;
    public Color fireMidColour;
    public Color fireEndColour;
    public float colorChangeSpeed;
    public float fireEmisionStrength;
    public float fireSize;
    public float fireGrowthRate;
    public float fireSpeed;
    public float fireRotSpeed;

    //Spark Values
    public bool sparksOn;
    public float sparkSpawnFrequency;
    public float sparkLifetime;
    public Color sparkColour;
    public float sparkEmmisionStrength;
    public float sparkSize;
    public float sparkSpeed;
    public float sparkRotSpeed;
}
