using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class ReferencePixelShader : MonoBehaviour
{
    
 


    void Start()
    {
        // Try to find the shader
        Shader myShader = Shader.Find("Hidden/Pixelize");
        if (myShader==null) {Debug.Log("Shader -Hidden/Pixelize- isnt loaded!");}
        else {Debug.Log("Shader -Hidden/Pixelize- is loaded!");}
    }

}
