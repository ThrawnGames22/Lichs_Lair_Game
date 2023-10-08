using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrinketSlotManager : MonoBehaviour
{
    public bool hasTrinket;
    public TrinketManager trinketManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(trinketManager.HasTrinket == true)
      {
        hasTrinket = true;
      }
      if(trinketManager.HasTrinket == false)
      {
        hasTrinket = false;
      }  
      
    }
}
