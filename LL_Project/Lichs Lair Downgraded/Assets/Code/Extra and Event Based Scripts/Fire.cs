using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    //public MeshCollider meshCollider;
    public FireTrap fireTrap;
    public GameObject Player;
    public float FireDamage;
    public bool StartDamage;
    public GameObject FireBurningPrefab;
    public bool isCreated;
    public float damageWindow;

    public GameObject MistFormClone;

    
    // Start is called before the first frame update
    void Start()
    {
     Player = GameObject.FindGameObjectWithTag("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
      MistFormClone = GameObject.Find("MistForm(Clone)");
      if(StartDamage == true)
      {
        Player.GetComponent<PlayerHealth>().currentHealth -= FireDamage * Time.deltaTime;
        
      }
      else
      {
        return;
      }

      
    }

    private void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.tag == "Player")
      {
        if(!isCreated)
        {
          GameObject clone = Instantiate(FireBurningPrefab, Player.transform.position, Quaternion.identity);
          clone.transform.parent = Player.transform;
          clone.transform.Rotate(-90,0,0);
          isCreated = true;
        }

        if(MistFormClone == null)
        {
           StartCoroutine(InflictDamage()); 
        }
       
      }
    }

    private void OnTriggerExit(Collider other)
    {
      if(other.gameObject.tag == "Player")
      {
        isCreated = false;
      }
    }

    public IEnumerator InflictDamage()
    {
        
        StartDamage = true;
        yield return new WaitForSeconds(3.5f);
        StopDamage();


    }

    public void StopDamage()
    {
      StartDamage = false;
      StopCoroutine(InflictDamage());
    }
}
