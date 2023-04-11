using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class SunLight : MonoBehaviour
{
    public GameObject[] Enemies;
    public int SlowedSpeed;
    // Start is called before the first frame update
    void Start()
    {
      Enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.active)
        {
            foreach(GameObject Enemy in Enemies)
            {
                Enemy.GetComponent<EnemyController>().speed = SlowedSpeed;
            }
        }
        else
        {
             foreach(GameObject Enemy in Enemies)
            {
                Enemy.GetComponent<EnemyController>().speed = Enemy.GetComponent<EnemyController>().OriginalSpeed;
            }
        }
    }
}
