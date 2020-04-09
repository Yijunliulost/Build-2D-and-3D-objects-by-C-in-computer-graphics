using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class code3 : MonoBehaviour
{
  
    public Shader shader1;
    public Renderer rend1;
    public Material MAT1;
    public GameObject CUBE;

   
    public Texture2D texture;
    public Texture norm,metal;
    // Start is called before the first frame update

    // Start is called before the first frame update
    void Start()
    {
        //shaders
        shader1 = Shader.Find("Standard");


        //load the image
        texture = new Texture2D(100, 100);
        byte[] d = File.ReadAllBytes("Assets/fake.jpeg");
        bool loaded= texture.LoadImage(d);

        //Assign the material to the cube
        CUBE = GameObject.Find( "Cube" );
        rend1 = CUBE.GetComponent<Renderer>();
        MAT1 = rend1.material;
        MAT1.mainTexture = texture;
        

     



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



    
      


      
    }

    // Update is called once per frame
    void Update()
    {

        


    }



    void OnPostRender()
    {


        
        MAT1.SetPass(0); //set rendering material state
  
    }
}