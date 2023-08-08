using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    //SCRIPT IS USED TO DESTROY OBJECTS OVER TIME TO PREVENT CLUTTER IN SCENE
    public float TimeTillDestroyed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Destroy()
    {
        yield return new WaitForSeconds(TimeTillDestroyed);
        Destroy(this.gameObject);
        
    }
}
