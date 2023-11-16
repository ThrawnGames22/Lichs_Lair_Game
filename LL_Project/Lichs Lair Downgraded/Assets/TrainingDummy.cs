using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingDummy : MonoBehaviour
{
    public Animator DummyAnimator;

    public bool IsHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      DummyAnimator.SetBool("IsHit", IsHit);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Sword")
        {
          StartCoroutine(Hit());
        }

        if(other.gameObject.tag == "LightningSpell")
        {
          StartCoroutine(Hit());
        }

        if(other.gameObject.tag == "Bow")
        {
          StartCoroutine(Hit());
        }

        if(other.gameObject.tag == "FireSpell")
        {
          StartCoroutine(Hit());
        }

        if(other.gameObject.tag == "DarkSpell")
        {
          StartCoroutine(Hit());
        }
    }

    public IEnumerator Hit()
    {
        IsHit = true;
        yield return new WaitForSeconds(0.5f);
        IsHit = false;

    }

    public void ResetHitFlag()
    {
        StopCoroutine(Hit());
        IsHit = false;

    }
}
