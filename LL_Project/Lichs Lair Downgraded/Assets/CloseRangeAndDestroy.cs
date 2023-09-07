using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseRangeAndDestroy : MonoBehaviour
{
    public Transform MoveSphereLocation;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<SphereCollider>().radius = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator CloseDestroyRange()
    {
        this.gameObject.GetComponent<SphereCollider>().radius = 0.02f;
        this.gameObject.transform.position = MoveSphereLocation.transform.position;
        yield return new WaitForSeconds(10);
        this.gameObject.SetActive(false);
    }
}
