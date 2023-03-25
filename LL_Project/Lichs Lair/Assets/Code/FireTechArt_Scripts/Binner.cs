using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Binner : MonoBehaviour
{
    public float deathTime = 10;
    void Update()
    {
        //takes down death time over time
        deathTime -= Time.deltaTime;

        //destroys object when deathtime reaches 0
        if(deathTime < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
