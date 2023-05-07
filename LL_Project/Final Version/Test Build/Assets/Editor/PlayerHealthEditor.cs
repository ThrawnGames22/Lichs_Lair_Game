using System.Collections;
using System.Collections.Generic;
using UnityEditor;


[CustomEditor(typeof(PlayerHealth))]
public class PlayerHealthEditor : Editor
{
    
    public override void OnInspectorGUI()
    {
      DrawDefaultInspector();
      PlayerHealth myHealth = (PlayerHealth)target;

      EditorGUILayout.HelpBox("This is The Player Health Component", MessageType.Info);
    }
}
