using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawn : MonoBehaviour
{
    public GameObject firePart;
    public GameObject sparkPart;
    public ValueHolder valhol;
    public static FireSpawn FireStarter;

    private float fDelaySaver;
    private float fTrueDelay;

    private float sDelaySaver;
    private float sTrueDelay;
    
    private void Start()
    {
        //Fills the static variable which any other fires will inherit from. Has a strange name so it isnt confused with another Dev's game objects.
        if (FireStarter == null && this.gameObject.name == "SmartFireFireStarter")
        {
            FireStarter = this;
        }
        //fill variables with Firestarter's
        firePart = FireStarter.firePart;
        sparkPart = FireStarter.sparkPart;
        valhol = FireStarter.valhol;
    }
    

    // Update is called once per frame
    void Update()
    {
        //Fire instanciator
        fDelaySaver = 1f / valhol.fireSpawnFrequency;

        fTrueDelay -= Time.deltaTime;

        if(fTrueDelay < 0f)
        {
            Instantiate(firePart, transform.position, Quaternion.identity);
            fTrueDelay = fDelaySaver;
        }

        //Spark instanciator
        if (valhol.sparksOn == true)
        {
            sDelaySaver = 1f / valhol.sparkSpawnFrequency;

            sTrueDelay -= Time.deltaTime;

            if (sTrueDelay < 0f)
            {
                Instantiate(sparkPart, transform.position, Quaternion.identity);
                sTrueDelay = sDelaySaver;
            }

        }
    }
}
