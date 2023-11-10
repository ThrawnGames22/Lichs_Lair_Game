using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrapDoor : MonoBehaviour
{

    public Animator LeftDoor;
    public Animator RightDoor;

    public bool OpenTrapDoor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LeftDoor.SetBool("OpenTrapDoor", OpenTrapDoor);
        RightDoor.SetBool("OpenTrapDoor", OpenTrapDoor);

    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player")
        {
            OpenTrapDoor = true;
            
        }
    }
}
