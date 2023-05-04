using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDoor : MonoBehaviour
{
    

    public bool UnlockDoor;
    public bool isMagicDoor;
    public bool isNormalOpeningDoor;
    public GameObject MagicBarrier;
    public bool MagicIsBroken;
    public bool IsInRange;

    public Animator DoorAnimator;
    public float dissolve = 2.74f;

    public List<GameObject> MagicSeals;
    // Start is called before the first frame update
    void Start()
    {
       if(isMagicDoor)
       {
       MagicBarrier.GetComponent<MeshRenderer>().material.SetFloat("_Dissolve_Amount", dissolve);
       }

       MagicIsBroken = false;
    }

    // Update is called once per frame
    void Update()
    {
       DoorAnimator.SetBool("IsUnlocked", UnlockDoor);
       
      if(isMagicDoor)
      {
        if(MagicIsBroken)
        {
            
            
            dissolve += 10f * Time.deltaTime;
            MagicBarrier.GetComponent<MeshRenderer>().material.SetFloat("_Dissolve_Amount", dissolve);
            MagicBarrier.GetComponent<MeshCollider>().enabled = false;
        }

        if( MagicBarrier.GetComponent<MeshRenderer>().material.GetFloat("_Dissolve_Amount") > 50)
        {
            Destroy(MagicBarrier);
        }

        foreach(GameObject MS in MagicSeals)
        {
            if(MS.GetComponent<SealStone>().SealIsBroken)
            {
                MagicSeals.Remove(MS);
            }
        }

        

        
      }

      if(isNormalOpeningDoor == true)
        {
            if(IsInRange == true)
            {
              
                UnlockDoor = true;
              
            }
        }

      if(MagicSeals.Count == 0)
        {
           MagicIsBroken = true;
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Player")
        {
            IsInRange = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if(other.gameObject.tag == "Player")
        {
            IsInRange = false;
        }
    }
}
