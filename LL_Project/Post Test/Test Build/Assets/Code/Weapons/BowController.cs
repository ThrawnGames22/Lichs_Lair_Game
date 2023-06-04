using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BowType
{
    Standard,
    Fire,
    Ice,
    Poison,
    Sunlight
}

// Handles bow weapon values its usage
public class BowController : MonoBehaviour
{
    
    public int currentArrowCount;
    public int MaxArrowCount;
    public BowType bowType;

    public float NextShot;
    public float CurrentDelayTimer;
    public bool CanUse;
    public bool isInCooldown;




    public Transform ArrowShootPoint;
    public GameObject ArrowToShoot;
    public float ArrowSpeed;
    // Start is called before the first frame update
    void Start()
    {
        currentArrowCount = MaxArrowCount;
        CanUse = true;
    }

    // Update is called once per frame
    void Update()
    {
    if(PlayerController.Instance.HasActivatedWeapons)
    {
      if(currentArrowCount > 0)
      {
        if(PlayerController.Instance.CanUseWeapons == true)
        {
        if(CanUse == true)
        {
           if(Input.GetKeyDown(KeyCode.E))
             {
              Shoot();
              StartCoroutine(StartCoolDown());
        
             }
        }
        else
        {
            return;
        }
        }
       
      }

      if(CanUse == true)
      {
        StopCoroutine(StartCoolDown());
        
      }
    }

    if(isInCooldown)
      {
        PlayerController.Instance.CanUseWeapons = false;
      }

       if(!isInCooldown)
      {
        PlayerController.Instance.CanUseWeapons = true;
      }
    }
  // Shoot an arrow
    public void Shoot()
    {
      currentArrowCount -= 1;
      GameObject clone;
      clone = Instantiate(ArrowToShoot, ArrowShootPoint.position, Quaternion.identity);
      clone.GetComponent<Rigidbody>().AddForce(-transform.right * ArrowSpeed);
      clone.transform.rotation = ArrowShootPoint.transform.rotation;
    }
  // Cooldown between shots
    public IEnumerator StartCoolDown()
    {
        
        CanUse = false;
        isInCooldown = true;
        yield return new WaitForSeconds(CurrentDelayTimer);
        isInCooldown = false;
        CanUse = true;

    }
}
