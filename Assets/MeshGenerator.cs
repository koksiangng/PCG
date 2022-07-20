using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


//X-Z plane!
public class MeshGenerator : MonoBehaviour
{

    Mesh mesh;

    //Mandatory parameters
    // Width, height, shape, room count, floor count.

    public int minWidth, maxWidth, minHeight, maxHeight;
    public int width;
    public int height;


    void Start()
    {
        mesh = new Mesh();

        //Meshfilter references to a mesh.
        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshRenderer>().material = new Material(Shader.Find("Diffuse"));

        CreateRectangleFloor();
    }

    void CreateRectangleFloor()
    {
        List<Vector3> verts = new List<Vector3>();
        List<int> triangleorder;

        for(int w = 0; w <= width; w++)
        {
            for(int h = 0; h <= height; h++)
            {
                verts.Add(new Vector3(w, 0, h));
            }
        }

        //0 ... h, h + w... height + width
        /* 0 ..... h
         * .
         * .
         * .
         * w
         */
        
        triangleorder = new List<int>()
        {   
            //The floor (according to vertices, not face
            // < in for loop
            /*
            0, height - 1, height * (width - 1),
            height * (width - 1), height - 1, 0,

            height - 1, height * (width - 1), height * width - 1,
            height * width - 1, height * (width - 1), height - 1
            */

            //The floor (according to face, not vertices)
            // <= in for loop
            0, height, height * (width + 1),
            height * (width + 1), height, 0,

            height, height * (width + 1), (height + 1) * (width + 1) - 1,
            (height + 1) * (width + 1) - 1, height * (width + 1), height
        };

        UpdateMesh(verts, triangleorder.ToArray());
    }

    // Update mesh
    void UpdateMesh(List<Vector3> vertices, int[] triangles)
    {
       
        mesh.Clear();

        mesh.SetVertices(vertices);
        mesh.triangles = triangles;

        //For light
        //mesh.RecalculateNormals();

        //for lists:
        //mesh.SetVertices()

        //for normals (lists):
        //mesh.SetNormals() for each vertice
        //mesh.SetNormals(n);

    }


}
