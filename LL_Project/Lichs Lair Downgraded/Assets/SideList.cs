using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideList : MonoBehaviour
{

    public GameObject WASDText;
    public GameObject JumpText;
    public GameObject DashText;
    public GameObject SpellText;
    public GameObject MeleeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddJumpTextToList()
    {
        JumpText.SetActive(true);
    }

    public void AddDashTextToList()
    {
        DashText.SetActive(true);
    }

    public void AddSpellTextToList()
    {
        SpellText.SetActive(true);
    }

    public void AddMeleeTextToList()
    {
        MeleeText.SetActive(true);
    }
}
