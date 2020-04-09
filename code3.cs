using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class code3 : MonoBehaviour
{
  
  


    public Vector3[] vertexList;
    public int[] faceList;

    public Mesh meshCube;
    public Shader shader1;
    public Renderer rend;
    public Material MAT;

    private void createMeshCube()
    {

        Vector3[] Meshvertices = {
            new Vector3 (0, 0, 0),
            new Vector3 (1, 0, 0),
            new Vector3 (1, 1, 0),
            new Vector3 (0, 1, 0),
            new Vector3 (0, 1, 1),
            new Vector3 (1, 1, 1),
            new Vector3 (1, 0, 1),
            new Vector3 (0, 0, 1),
            };

        int[] Meshtriangles = {
            0, 2, 1, //face front
            0, 3, 2,

            2, 3, 4, //face top
            2, 4, 5,

            1, 2, 5, //face right
            1, 5, 6,

            0, 7, 4, //face left
            0, 4, 3,

            5, 4, 7, //face back
            5, 7, 6,

            0, 6, 7, //face bottom
            0, 1, 6
            };



        meshCube = GetComponent<MeshFilter>().mesh;
        meshCube.Clear();
        meshCube.vertices = Meshvertices;
        meshCube.triangles = Meshtriangles;
        meshCube.RecalculateNormals();
         
         for( int i = 0; i <= Meshtriangles.Length; i++ ) {

         }
    }


    // Start is called before the first frame update
    void Start()
    {


        //set shader
        rend = GetComponent<Renderer>();
        shader1 = Shader.Find("Standard");
        rend.material.shader = shader1;

        //set rendering material
        MAT = rend.material;
        MAT.color = Color.red;

        //set light1
        GameObject pointLight = new GameObject("Point Light");
        Light lightComp = pointLight.AddComponent<Light>();
        lightComp.color = Color.blue;
        lightComp.type = LightType.Point;
        lightComp.intensity = 15;
        lightComp.range = 15;
        pointLight.transform.position = new Vector3(2.18f, 4.48f, -4.73f);

        //set light2
        GameObject directionalLight = new GameObject("Directional Light");
        Light lightComp2 = directionalLight.AddComponent<Light>();
        lightComp2.color = Color.yellow;
        lightComp2.type = LightType.Directional;
        directionalLight.transform.position = new Vector3(0f, 3f, 0f);
        directionalLight.transform.rotation = Quaternion.Euler(50, -30, 0);

        //createMesh
        createMeshCube();
      
    }

    // Update is called once per frame
    void Update()
    {
       

    }



    void OnPostRender()
    {



        MAT.SetPass(0); //set rendering material state

        Quaternion rotation = Quaternion.Euler(45, 45, 45);
        // draw mesh at the origin and rotation
        Graphics.DrawMeshNow(meshCube, Vector3.zero, rotation);
  
    }
}