using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;






public class ChangeVertexColor : MonoBehaviour
{
    public Color UnSelectedColor;
    public Color SelectedColor;

    

    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select()
    {
      text.color = SelectedColor;
    }

    public void UnSelect()
    {
      text.color = UnSelectedColor;
        
    }
}
