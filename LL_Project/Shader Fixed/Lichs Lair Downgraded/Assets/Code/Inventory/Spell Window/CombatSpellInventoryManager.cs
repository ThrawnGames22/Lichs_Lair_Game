using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatSpellInventoryManager : MonoBehaviour
{

    // This script acts the same way as the ITEM INVENTORY MANAGER

    
    public static CombatSpellInventoryManager Instance;
    public List<CombatSpellScriptableObject> CombatSpellItems = new List<CombatSpellScriptableObject>();
    
    public PlayerMagic PlayerMagicController;
    

    public Transform ItemContent;
    public GameObject InventoryItem;

    public Toggle EnableRemove;

    public AbilityList abilityList;

    public CombatSpellItemController[] SpellItems;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(CombatSpellScriptableObject CMBS)
    {
        CombatSpellItems.Add(CMBS);
    }

   

    public void ListItems()
    {
        //Cleans the Inventory content before opening to prevent item duplication
        foreach(Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
        foreach(var item in CombatSpellItems)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();

            itemName.text = item.SpellName;
            itemIcon.sprite = item.SpellIcon;

            if(EnableRemove.isOn)
               removeButton.gameObject.SetActive(true);
        }

        SetInventoryItems();
    }

    

    public void SetInventoryItems()
    {
        SpellItems = ItemContent.GetComponentsInChildren<CombatSpellItemController>();

        for(int i = 0; i < CombatSpellItems.Count; i++)
        {
           SpellItems[i].AddItem(CombatSpellItems[i]);
        }
    }
}
