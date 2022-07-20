using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MeshGenerator : MonoBehaviour
{




    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    //Mandatory parameters
    // Width, height, shape, room count, floor count.
    public int width;
    public int height;


    void Start()
    {
        mesh = new Mesh();

        //Meshfilter references to a mesh.
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();
    }

    void CreateShape()
    {
        vertices = new Vector3[]
        {
            new Vector3(0, 0, 0),
            new Vector3(0, 0, 1),
            new Vector3(1, 0, 0),
        };

        triangles = new int[]
        {
            0, 1, 2, 2, 1, 0
        };
    }

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }

    [CustomEditor(typeof(MeshGenerator))]
    public class CustomInspector : Editor
    {


        public override void OnInspectorGUI()
        {

            DrawDefaultInspector();

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
}
