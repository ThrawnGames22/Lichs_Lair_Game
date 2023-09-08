using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAttackBoss : MonoBehaviour
{
     public float SpinSpeed = 10;
    public float MoveSpeed = 3;

    public Transform Player;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      Player = GameObject.FindGameObjectWithTag("Player").transform;
      transform.Rotate(0,20,0 * SpinSpeed * Time.deltaTime);
      transform.position = Vector3.Lerp(transform.position, Player.transform.position, Time.deltaTime * MoveSpeed);
    }
}
