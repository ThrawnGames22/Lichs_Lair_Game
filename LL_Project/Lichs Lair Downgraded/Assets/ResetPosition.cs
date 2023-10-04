using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    public bool IsWeapon;
    public bool IsPotion;
    public bool IsTrinket;
    public bool IsPet;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ResetPos());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public IEnumerator ResetPos()
    {
        yield return new WaitForSeconds(0.1f);
        
        if(IsWeapon)
        {
        this.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(2.462158f, 0f);
        }

        if(IsPotion)
        {
        this.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(2.462158f,-2.052979f);
        }

         if(IsTrinket)
        {
        this.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(2.462158f,-47.5f);
        }

         if(IsPet)
        {
        this.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(2.462158f,-47.5f);
        }
        Destroy(this);
        
        
    }
}
