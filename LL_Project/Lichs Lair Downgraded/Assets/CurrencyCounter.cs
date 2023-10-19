using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyCounter : MonoBehaviour
{
    public SlotUIController PlayerUI;
    public int coins;

    public Text CoinText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       PlayerUI = GameObject.Find("UI").GetComponent<SlotUIController>();
       coins = PlayerUI.Coins;
       CoinText.text = "Coins: "+ coins;
    }
}
