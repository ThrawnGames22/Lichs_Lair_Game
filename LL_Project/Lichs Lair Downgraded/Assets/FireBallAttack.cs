using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallAttack : MonoBehaviour
{

     public float FireRate;

     public float nextFire = 1f;
    public float MoveSpeed = 3;

    public Transform CenterPoint;

    public MiniBoss miniBoss;

    public Transform Player;

    public GameObject FireGrenadeProjectile;

    public Transform EnemyShootPoint;

    public bool HasFired;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyShootPoint = GameObject.Find("EnemyShootPos").transform;
        CenterPoint = GameObject.Find("FireThrowPos").transform;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = Vector3.Lerp(transform.position, CenterPoint.transform.position, Time.deltaTime * MoveSpeed);
        transform.LookAt(Player);
        StartCoroutine(ThrowFireGrenade());

        if(miniBoss.IsPhase2isActive == false)
        {
            StopCoroutine(ThrowFireGrenade());
            
        }
    }

    public IEnumerator ThrowFireGrenade()
    {
      HasFired = false;
      yield return new WaitForSeconds(nextFire);
      if(HasFired == false)
      {

      GameObject GrenadeClone = Instantiate(FireGrenadeProjectile, EnemyShootPoint.position, EnemyShootPoint.rotation);
      HasFired = true;
      Stop();
      }
      
    }

    public void Stop()
    {
     StopAllCoroutines();
     
     StartCoroutine(ThrowFireGrenade());
    }
}
