using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int CoinValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoinAmount()
    {
      GameObject.Find("UI").GetComponent<SlotUIController>().SetCoinAmount(CoinValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            AddCoinAmount();
            Destroy(this.gameObject);
        }
    }
}
