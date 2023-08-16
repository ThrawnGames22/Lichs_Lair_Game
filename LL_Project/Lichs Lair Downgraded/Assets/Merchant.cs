using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Merchant : MonoBehaviour
{
    public MerchantDatabase MD;
    
    public int MinItems = 3;
    public int MaxItems = 8;

    public GameObject StoreItem1;
    public GameObject StoreItem2;
    public GameObject StoreItem3;
    public GameObject StoreItem4;
    public GameObject StoreItem5;
    public GameObject StoreItem6;
    public GameObject StoreItem7;
    public GameObject StoreItem8;

    public GameObject[] StoreItemsPrefabs;

    public GameObject Slot1;
    public GameObject Slot2;
    public GameObject Slot3;
    public GameObject Slot4;
    public GameObject Slot5;
    public GameObject Slot6;
    public GameObject Slot7;
    public GameObject Slot8;



    public int MaxStoreItems = 8;

    [Header("UI Handling")]

    public GameObject ConfirmPurchasePanel;



    
    // Start is called before the first frame update
    void Start()
    {
        StoreItem1 = StoreItemsPrefabs[Random.Range(0, StoreItemsPrefabs.Length)];
        StoreItem2 = StoreItemsPrefabs[Random.Range(0, StoreItemsPrefabs.Length)];
        StoreItem3 = StoreItemsPrefabs[Random.Range(0, StoreItemsPrefabs.Length)];
        StoreItem4 = StoreItemsPrefabs[Random.Range(0, StoreItemsPrefabs.Length)];
        StoreItem5 = StoreItemsPrefabs[Random.Range(0, StoreItemsPrefabs.Length)];
        StoreItem6 = StoreItemsPrefabs[Random.Range(0, StoreItemsPrefabs.Length)];
        StoreItem7 = StoreItemsPrefabs[Random.Range(0, StoreItemsPrefabs.Length)];
        StoreItem8 = StoreItemsPrefabs[Random.Range(0, StoreItemsPrefabs.Length)];

        ConfirmPurchasePanel.SetActive(false);

        


        GameObject StoreItemClone1 = Instantiate(StoreItem1);
        StoreItemClone1.transform.parent = Slot1.transform;
        StoreItemClone1.GetComponent<RectTransform>().anchoredPosition = Slot1.GetComponent<RectTransform>().anchoredPosition;
        StoreItemClone1.GetComponent<RectTransform>().anchoredPosition = new Vector2(50, -50);

        GameObject StoreItemClone2 = Instantiate(StoreItem2);
        StoreItemClone2.transform.parent = Slot2.transform;
        StoreItemClone2.GetComponent<RectTransform>().anchoredPosition = Slot2.GetComponent<RectTransform>().anchoredPosition;
        StoreItemClone2.GetComponent<RectTransform>().anchoredPosition = new Vector2(50, -50);

        GameObject StoreItemClone3 = Instantiate(StoreItem3);
        StoreItemClone3.transform.parent = Slot3.transform;
        StoreItemClone3.GetComponent<RectTransform>().anchoredPosition = Slot3.GetComponent<RectTransform>().anchoredPosition;
        StoreItemClone3.GetComponent<RectTransform>().anchoredPosition = new Vector2(50, -50);

        GameObject StoreItemClone4 = Instantiate(StoreItem4);
        StoreItemClone4.transform.parent = Slot4.transform;
        StoreItemClone4.GetComponent<RectTransform>().anchoredPosition = Slot4.GetComponent<RectTransform>().anchoredPosition;
        StoreItemClone4.GetComponent<RectTransform>().anchoredPosition = new Vector2(50, -50);

        GameObject StoreItemClone5 = Instantiate(StoreItem5);
        StoreItemClone5.transform.parent = Slot5.transform;
        StoreItemClone5.GetComponent<RectTransform>().anchoredPosition = Slot5.GetComponent<RectTransform>().anchoredPosition;
        StoreItemClone5.GetComponent<RectTransform>().anchoredPosition = new Vector2(50, -50);

        GameObject StoreItemClone6 = Instantiate(StoreItem6);
        StoreItemClone6.transform.parent = Slot6.transform;
        StoreItemClone6.GetComponent<RectTransform>().anchoredPosition = Slot6.GetComponent<RectTransform>().anchoredPosition;
        StoreItemClone6.GetComponent<RectTransform>().anchoredPosition = new Vector2(50, -50);

        GameObject StoreItemClone7 = Instantiate(StoreItem7);
        StoreItemClone7.transform.parent = Slot7.transform;
        StoreItemClone7.GetComponent<RectTransform>().anchoredPosition = Slot7.GetComponent<RectTransform>().anchoredPosition;
        StoreItemClone7.GetComponent<RectTransform>().anchoredPosition = new Vector2(50, -50);

        GameObject StoreItemClone8 = Instantiate(StoreItem8);
        StoreItemClone8.transform.parent = Slot8.transform;
        StoreItemClone8.GetComponent<RectTransform>().anchoredPosition = Slot8.GetComponent<RectTransform>().anchoredPosition;
        StoreItemClone8.GetComponent<RectTransform>().anchoredPosition = new Vector2(50, -50);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    
}
