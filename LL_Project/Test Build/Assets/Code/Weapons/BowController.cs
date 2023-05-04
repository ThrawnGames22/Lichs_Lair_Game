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
public class BowController : MonoBehaviour
{
    
    public int currentArrowCount;
    public int MaxArrowCount;
    public BowType bowType;

    public float NextShot;
    public float CurrentDelayTimer;
    public bool CanUse;




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

      if(CanUse == true)
      {
        StopCoroutine(StartCoolDown());
      }
    }
    }

    public void Shoot()
    {
      currentArrowCount -= 1;
      GameObject clone;
      clone = Instantiate(ArrowToShoot, ArrowShootPoint.position, Quaternion.identity);
      clone.GetComponent<Rigidbody>().AddForce(-transform.right * ArrowSpeed);
      clone.transform.rotation = ArrowShootPoint.transform.rotation;
    }

    public IEnumerator StartCoolDown()
    {
        CanUse = false;
        yield return new WaitForSeconds(CurrentDelayTimer);
        CanUse = true;
    }
}
