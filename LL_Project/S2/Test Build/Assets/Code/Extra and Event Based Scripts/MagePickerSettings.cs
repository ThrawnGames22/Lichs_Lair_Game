using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagePickerSettings : MonoBehaviour
{
    public int SortOrder;
    // Start is called before the first frame update
    void Start()
    {
      GameObject.Find("DeathCanvas").GetComponent<DeathCanavsManager>().SetDeathScreenActive();
      GameObject.Find("DeathCanvas").GetComponent<Canvas>().sortingOrder = SortOrder;
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
