using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class code3 : MonoBehaviour
{
  
  


    public Vector3[] vertexList;
    public int[] faceList;

    public int startIT;
    public Mesh meshCube;
    public Shader shader1;
    public Shader shader11;
    public Shader shader2;
    public Shader shader3;
    public Shader shader4;
    public Shader shader6;
    public Shader shader7;
    public Shader shader5;
    public Renderer rend;
    public Material MAT;
    public Renderer rend1;
    public Material MAT1;
    public Renderer rend2;
    public Material MAT2;
    public Renderer rend3;
    public Material MAT3;
    public Renderer rend4;
    public Material MAT4;
    public Renderer rend5;
    public Material MAT5;
    public GameObject CUBE;
    public GameObject CYLINDER;
    public GameObject CAPSULE;
    public GameObject SPHERE;
    public GameObject PLANE;

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
         

    }


    public Texture2D texture;
    public Texture norm,metal;
    // Start is called before the first frame update

    // Start is called before the first frame update
    void Start()
    {
        //all the shades
        startIT = 8;
        shader1 = Shader.Find("Standard");
        shader2 = Shader.Find("Custom/shade2");
        shader3 = Shader.Find("Custom/shade3");
        shader4 = Shader.Find("Custom/shade4");
        shader5 = Shader.Find("Custom/shade5");
        shader6 = Shader.Find("Custom/shade6");
        shader7 = Shader.Find("Custom/shade7");

        //load the image
        texture = new Texture2D(100, 100);
        byte[] d = File.ReadAllBytes("C:/Users/Yijun Liu/Desktop/Computer Graph/New Unity Project 5/fake.jpeg");
        bool loaded= texture.LoadImage(d);

        //Assign the material to the cube
        CUBE = GameObject.Find( "Cube" );
        rend1 = CUBE.GetComponent<Renderer>();
        MAT1 = rend1.material;
        MAT1.mainTexture = texture;
        

     
        MAT1.EnableKeyword("_METALLICGLOSSMAP");
        MAT1.SetTexture("_METALLICGLOSSMAP", metal);
        
        //Assign the material to the Cylinder
        CYLINDER = GameObject.Find( "Cylinder" );
        rend2 = CYLINDER.GetComponent<Renderer>();
        MAT2 = rend2.material;
        

        
        //Assign the material to the Capsule
        CAPSULE = GameObject.Find( "Capsule" );
        rend3 = CAPSULE.GetComponent<Renderer>();
        MAT3 = rend3.material;

     

        //Assign the material to the Sphere
        SPHERE = GameObject.Find( "Sphere" );
        rend4 = SPHERE.GetComponent<Renderer>();
        MAT4 = rend4.material;


        //Assign the material to the Plane
        PLANE = GameObject.Find( "Plane" );
        rend5 = PLANE.GetComponent<Renderer>();
        MAT5 = rend5.material;



        //set point light
        GameObject pointLight = new GameObject("Point Light");
        Light lightComp = pointLight.AddComponent<Light>();
        lightComp.color = Color.red;
        lightComp.type = LightType.Point;
        lightComp.intensity = 15;
        lightComp.range = 15;
        pointLight.transform.position = new Vector3(1f, 0f, 0f);

        //set direction light
        GameObject directionalLight = new GameObject("Directional Light");
        Light lightComp2 = directionalLight.AddComponent<Light>();
        lightComp2.color = Color.blue;
        lightComp2.type = LightType.Directional;
        directionalLight.transform.position = new Vector3(0f, 0f, 1f);
        directionalLight.transform.rotation = Quaternion.Euler(50, -30, 0);

        //set spot line
        GameObject spotLight = new GameObject("Spot Light");
        Light lightComp3 = spotLight.AddComponent<Light>();
        lightComp3.color = Color.green;
        lightComp3.type = LightType.Spot;
        lightComp3.intensity = 10;
        lightComp3.range = 15;
        lightComp3.spotAngle = 60;
        spotLight.transform.position = new Vector3(0f, 0f, 0f);
        spotLight.transform.rotation = Quaternion.Euler(50, 0, 0);


        //set shader of my created mesh object
        rend = GetComponent<Renderer>();
        shader11 = Shader.Find("Standard");
        rend.material.shader = shader11;

        //set the rendering material
        MAT = rend.material;
        MAT.color = Color.black;

        //createMesh
        createMeshCube();
      


      
    }

    // Update is called once per frame
    void Update()
    {

        //This is the input function which we can take orders from keyboard
        if (Input.GetKey( "1" ))
        {
            startIT = 1;
        }
        else if (Input.GetKey("2"))
        {
            startIT = 2;
        }
        else if (Input.GetKey("3"))
        {
            startIT = 3;
        }
        
        //input different key value to change the shade of objects
        //object 1
        if(startIT == 8){
            MAT1.shader = shader1; 
        }if(startIT == 1){
            MAT1.shader = shader1;
        }if(startIT == 2){
            MAT1.shader = shader6;
        }if(startIT == 3){
            MAT1.shader = shader7;
        }

        //object2
        if(startIT == 8){
            MAT2.shader = shader2; 
        }if(startIT == 1){
            MAT2.shader = shader1;
        }if(startIT == 2){
            MAT2.shader = shader6;
        }if(startIT == 3){
            MAT2.shader = shader7;
        }

        //object3
        if(startIT == 8){
            MAT3.shader = shader3; 
        }if(startIT == 1){
            MAT3.shader = shader1;
        }if(startIT == 2){
            MAT3.shader = shader6;
        }if(startIT == 3){
            MAT3.shader = shader7;
        }

        //object4
        if(startIT == 8){
            MAT4.shader = shader4; 
        }if(startIT == 1){
            MAT4.shader = shader1;
        }if(startIT == 2){
            MAT4.shader = shader6;
        }if(startIT == 3){
            MAT4.shader = shader7;
        }

        //object5
        if(startIT == 8){
            MAT5.shader = shader5; 
        }if(startIT == 1){
            MAT5.shader = shader1;
        }if(startIT == 2){
            MAT5.shader = shader6;
        }if(startIT == 3){
            MAT5.shader = shader7;
        }

    }



    void OnPostRender()
    {


        
        MAT.SetPass(0); //set rendering material state
        MAT1.SetPass(0);
        MAT2.SetPass(0);
        MAT3.SetPass(0);
        MAT4.SetPass(0);
        MAT5.SetPass(0);

        Quaternion rotation = Quaternion.Euler(45, 45, 45);
        // draw mesh at the origin and rotation
        Graphics.DrawMeshNow(meshCube, Vector3.zero, rotation);
  
    }
}