using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkCloudSpell : MonoBehaviour
{
     public bool HasSpawned;
    public float TotalSpellLifetime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LifeTime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator LifeTime()
    {
      yield return new WaitForSeconds(TotalSpellLifetime);
      Destroy(this.gameObject);
    }
}
