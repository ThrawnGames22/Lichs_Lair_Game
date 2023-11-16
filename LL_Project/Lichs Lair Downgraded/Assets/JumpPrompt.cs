using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpPrompt : MonoBehaviour
{
    
    public GameObject JumpPromptText;
    public SideList KeybindList;

    public bool IsJumpPrompt;

    public bool IsShiftPrompt;
    public bool IsSpellPrompt;
    public bool IsMeleePrompt;


    
    // Start is called before the first frame update
    void Start()
    {
        JumpPromptText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player")
        {
            JumpPromptText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player")
        {
            JumpPromptText.SetActive(false);

            if(IsJumpPrompt == true)
            {
              AddJumpToSideList();
            }

            if(IsShiftPrompt == true)
            {
              AddDashToSideList();
            }

            //if(IsSpellPrompt == true)
            //{
            //  AddSpellToSideList();
            //}

           // if(IsMeleePrompt == true)
            //{
            //  AddMeleeToSideList();
           // }
        }
    }


    public void AddJumpToSideList()
    {
      KeybindList.AddJumpTextToList();
    }

    public void AddDashToSideList()
    {
      KeybindList.AddDashTextToList();
    }

    public void AddSpellToSideList()
    {
      KeybindList.AddSpellTextToList();
    }
    public void AddMeleeToSideList()
    {
      KeybindList.AddMeleeTextToList();
    }
}
