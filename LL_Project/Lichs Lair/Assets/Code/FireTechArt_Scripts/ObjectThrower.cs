using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectThrower : MonoBehaviour
{
    public GameObject cubeOBJ;
    public GameObject newOne;
    public Rigidbody newRig;
    public float forceStren = 29.76f;

    //Throws a 'ThrowCube' with the velocity needed to throw it into the fire;
    public void ThrowCube()
    {
        newOne = Instantiate(cubeOBJ);
        newRig = newOne.GetComponent<Rigidbody>();
        newRig.AddForce(Vector3.right * forceStren, ForceMode.Impulse);

    }
}
