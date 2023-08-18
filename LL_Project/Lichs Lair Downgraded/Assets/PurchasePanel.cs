using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchasePanel : MonoBehaviour
{
    public bool HasPressedBack;
    public bool HasPressedConfirm;
    public GameObject Panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HasPressedConfirm == false)
        {
            StopCoroutine(ResetTriggerFlag());
        }
    }

    public void ClosePanel()
    {
        
      Panel.SetActive(false);
      //StartCoroutine(ResetTriggerFlag());
    }

     public void OpenPanel()
    {
        
      Panel.SetActive(true);
      //StartCoroutine(ResetTriggerFlag());
    }

    public void ConfirmPurchase()
    {
        HasPressedConfirm = true;
        ClosePanel();
        StartCoroutine(ResetTriggerFlag());
    }

    public IEnumerator ResetTriggerFlag()
    {
        yield return new WaitForSeconds(0.7f);
        HasPressedConfirm = false;
        
    }
}

    
