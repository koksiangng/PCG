using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MeshGenerator))]
public class CustomInspector : Editor
{


    public override void OnInspectorGUI()
    {
        //Draws default inspector (with values displayed, e.g. width/height
        DrawDefaultInspector();

        //Call independent generation.
        if (GUILayout.Button("T-Shape"))
        {
            //Do T-Shape generation
        }
        if (GUILayout.Button("Rectangle-Shape"))
        {
            //Do Rectangle shape generation
        }
        if (GUILayout.Button("L-Shape"))
        {
            //Do L-Shape generation
        }
    }
}
