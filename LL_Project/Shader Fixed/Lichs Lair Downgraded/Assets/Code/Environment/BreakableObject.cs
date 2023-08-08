using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    public GameObject StaticObject;
    public GameObject RigidObject;

    public bool HasCollided;
    
    // Start is called before the first frame update
    void Start()
    {

      //Set the static object active first before the broken object
      StaticObject.SetActive(true);
      RigidObject.SetActive(false);


        
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {

      //Seperate objects and turn off kinematic 
        
      if(other.gameObject.tag == "DarkSpell")
      {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        Debug.Log("HasCollided");
        HasCollided = true;

        StaticObject.SetActive(false);
        RigidObject.SetActive(true);
        
      }

      if(other.gameObject.tag == "FireSpell")
      {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        Debug.Log("HasCollided");
        HasCollided = true;

        StaticObject.SetActive(false);
        RigidObject.SetActive(true);
        
      }
    }
}
