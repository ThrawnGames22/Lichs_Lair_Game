using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCollector : MonoBehaviour
{

    public GameObject SwapCanvas;

    public CombatSpellScriptableObject ComabtSpellData;

    public PlayerMagic PM;

    public bool IsInRange;
    // Start is called before the first frame update
    void Start()
    {
        SwapCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PM = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMagic>();
        
        if(IsInRange == true)
        {
        if(Input.GetKeyDown(KeyCode.E))
            {
                if(PM.HasSecondarySpell == true)
                {
             GameObject SpellDrop = Instantiate(PM.inventoryController.CurrentCombatSpell2.SpellDropObject, GameObject.Find("PlayerDropPoint").transform.position, GameObject.Find("PlayerDropPoint").transform.rotation);
             PM.inventoryController.CurrentCombatSpell2 = null;
             PM.inventoryController.CurrentCombatSpell2 = ComabtSpellData;
             PM.HasSecondarySpell = true;
             Destroy(this.gameObject);
                }

                if(PM.HasSecondarySpell == false)
                {
                    PM.inventoryController.CurrentCombatSpell2 = null;
                    PM.inventoryController.CurrentCombatSpell2 = ComabtSpellData;
                    PM.HasSecondarySpell = true;
                    Destroy(this.gameObject);
                }
            }
        }
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player")
        {
            SwapCanvas.SetActive(true);
            IsInRange = true;
            
          
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player")
        {
            SwapCanvas.SetActive(false);
            IsInRange = false;
        }
    }
}
