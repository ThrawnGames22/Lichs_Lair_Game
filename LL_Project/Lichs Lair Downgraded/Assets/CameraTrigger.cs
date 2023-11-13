using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{

    public CameraSmoothFollow cameraSmoothFollow;
    public Animator LeftDoor;
    public Animator RightDoor;

    public bool OpenDoor;


    public Vector3 Offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LeftDoor.SetBool("OpenDoor", OpenDoor);
        RightDoor.SetBool("OpenDoor", OpenDoor);

    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player")
        {
            OpenDoor = true;

            cameraSmoothFollow.offset = Offset;
            
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
