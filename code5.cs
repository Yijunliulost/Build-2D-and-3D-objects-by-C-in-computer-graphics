using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Globalization;




//Build one class for the attributes of objects
public class Objectsin{
    public float scale;
    public Color color;
    public Vector3 movepoint;
    public Matrix4x4 tranformed;
    public Vector3 ambient_m;
    public Vector3 diffuse_m;
    public Vector3 specular_m;
    public float shin_m;


    public void Hittime(Vector4 eye, Vector4 direction, out float Time_C, out bool IsHit){
        Matrix4x4 translateTo = Matrix4x4.Translate( new Vector3( -movepoint.x, -movepoint.y, -movepoint.z ) );
        Matrix4x4 scaleTo = Matrix4x4.Scale( new Vector3( 1f / scale, 1f / scale, 1f / scale ) );
        tranformed  = scaleTo*translateTo;

        Vector3 eye_tranform = tranformed*eye;
        Vector3 direction_tranform = tranformed*direction;
        //calculate the Intersection of a Ray with a Sphere
        float A = Vector3.Dot(direction_tranform, direction_tranform);
        float B = Vector3.Dot(direction_tranform, eye_tranform);
        float C = Vector3.Dot(eye_tranform, eye_tranform) - 1.0f;
        //based on the formula in slides, we can get:
        if((B*B - A*C) > 0){
            IsHit = true;
            Time_C = Math.Min((float)(-B/A) + (float)(Math.Sqrt(B*B - A*C))/A, (float)(-B/A) - (float)(Math.Sqrt(B*B - A*C))/A);
        }else if((B*B - A*C) < 0){
            IsHit = false;
            Time_C = float.PositiveInfinity;
        }else{
            IsHit = false;
            Time_C = (float)(-B/A);
        }

    }
}




//Based on the objects class, we build the PayCast class
public class RayCast{
    public void caster(int part, int po, Vector3 sun_dir, Vector3 pointPosition, Vector3 sun_color, Vector3 point_color, Vector4 eye, Texture2D pixTex, List<Objectsin> OBJ, float Width, float Height, int row, int col){
        for(int i = 0; i < row; i++){

            float b1 = 2*i*Height/row - Height;
            for(int j = 0; j < col; j++){
                float a1 = 2*j*Width/col - Width;
                float MinT = float.PositiveInfinity;
                Objectsin ObjHit = null;
                Vector4 direction;
                if(po == 1){
                    direction = new Vector4(a1, b1, -0.5f, 0);
                }else{
                    direction = new Vector4(0, 0, -1f, 0);
                }

                Vector3 position_hit = new Vector3(99999, 0, 0);
                for(int k = 0; k < OBJ.Count; k++){
                    float Time_C;
                    bool IsHit;
                    

                    OBJ[k].Hittime(eye, direction, out Time_C, out IsHit);
                    if(Time_C < MinT && IsHit){
                        ObjHit = OBJ[k];
                        MinT = Time_C;
                        position_hit = new Vector3((float)(eye.x + direction.x*Time_C), (float)(eye.y + direction.y*Time_C), (float)(eye.z + direction.z*Time_C));
                        //Debug.Log("Hit"+ Time_C);
                    }


                }
                if(part == 2){
                if(position_hit.x != 99999){
                    Vector3 n = ObjHit.movepoint - position_hit;
                    n.Normalize();
                    Vector3 v = new Vector3(direction.x, direction.y, direction.z);
                    v.Normalize();
                    Vector3 l_sun = sun_dir;
                    l_sun.Normalize();
                    Vector3 l_point = pointPosition -position_hit;
                    Vector3 h_sun = v + l_sun;
                    h_sun.Normalize();
                    Vector3 h_point = v + l_point;
                    h_point.Normalize();
                    l_point.Normalize();
                    Vector3 L_sun =  (Vector3.Scale(ObjHit.diffuse_m, sun_color))*Math.Max(0, (Vector3.Dot(n, l_sun))) + (Vector3.Scale(ObjHit.specular_m, sun_color))*Math.Max(0, (Vector3.Dot(n, h_sun)));
                    Vector3 L_point = (Vector3.Scale(ObjHit.diffuse_m, point_color))*Math.Max(0, (Vector3.Dot(n, l_point))) + (Vector3.Scale(ObjHit.specular_m, point_color))*Math.Max(0, (Vector3.Dot(n, h_point)));
                    Vector3 L = L_sun + L_point;
                    float a = ObjHit.color[0];
                    float b = ObjHit.color[1];
                    float c = ObjHit.color[2];
                    //Vector3 Final_L = new Vector3(ObjHit.color.x + L.x, ObjHit.color.y + L.y, ObjHit.color.z + L.z);
                    pixTex.SetPixel(j, row - i - 1, new Color(a+L.x, b+L.y, c+L.z));
                }else{
                pixTex.SetPixel(j, row - i -1, new Color(0,0,0));
                }
                }else if(part == 1){
                
                if(ObjHit == null){
                    pixTex.SetPixel(j, row - i -1, new Color(0,0,0));
                }else{
                    pixTex.SetPixel(j, row - i - 1, ObjHit.color);
                }
                
                }

            }
        }
        pixTex.Apply();
    }
}




public class code2 : MonoBehaviour
{
    public float Width, Height;
    public int row, col;
    public Texture2D pixTex;
    public Material MAT;
    public Vector4 eye;
    public Renderer rend;
    public Vector3 sun_dir;
    public Vector3 pointPosition;
    public Vector3 sun_color;
    public Vector3 point_color;
    public int part = 1;
    public int po = 1;




   //Create the object list
    public List<Objectsin> Object_list;
    public void createlist(){
    //set the objects (red, green, blue, orange, purple)
    Object_list.Add(new Objectsin{
        scale = 0.05f,
        color = new Color(1, 0, 0),
        movepoint = new Vector3(-0.3f, 0.1f, -0.5f),
        ambient_m = new Vector3(0.5f, 0.5f, 0.1f),
        diffuse_m = new Vector3(0.1f, 0.2f, 0.1f),
        specular_m = new Vector3(0.3f, 0.5f, 0.1f),
        shin_m = 0.3f
    });

    Object_list.Add(new Objectsin{
        scale = 0.15f,
        color = new Color(0, 1, 0),
        movepoint = new Vector3(0.0f, -0.2f, -0.8f),
        ambient_m = new Vector3(0.1f, 0.5f, 0.1f),
        diffuse_m = new Vector3(0.9f, 0.2f, 0.1f),
        specular_m = new Vector3(0.3f, 0.5f, 0.3f),
        shin_m = 0.8f
    });

    Object_list.Add(new Objectsin{
        scale = 0.3f,
        color = new Color(0, 0, 1),
        movepoint = new Vector3(0.3f, 0.3f, -1.1f),
        ambient_m = new Vector3(1f, 0.5f, 0.1f),
        diffuse_m = new Vector3(0.9f, 1f, 0.1f),
        specular_m = new Vector3(0.3f, 0.5f, 0.3f),
        shin_m = 0.2f
    });

    Object_list.Add(new Objectsin{
        scale = 0.075f,
        color = new Color(1, 0.647f, 0),
        movepoint = new Vector3(0.1f, 0.2f, -0.3f),
        ambient_m = new Vector3(0.7f, 0.5f, 0.1f),
        diffuse_m = new Vector3(0.9f, 0f, 0.1f),
        specular_m = new Vector3(0.3f, 0.5f, 0f),
        shin_m = 1f
    });

    Object_list.Add(new Objectsin{
        scale = 0.225f,
        color = new Color(0.5f, 0, 0.5f),
        movepoint = new Vector3(-0.2f, -0.25f, -0.4f),
        ambient_m = new Vector3(0.1f, 0.5f, 1f),
        diffuse_m = new Vector3(0.9f, 0f, 0.1f),
        specular_m = new Vector3(0f, 0.5f, 0.3f),
        shin_m = 0.5f
    });
    }






    void Start(){
    eye = new Vector4(0, 0, 0.5f, 1);
    Height = 0.2f;
    Width = 0.25f;
    col = 750;
    row = 600;
    sun_dir = new Vector3(0f, 0.5f, 0.5f);
    pointPosition = new Vector3(-1f, 1f, 0.25f);
    sun_color = new Vector3(0.8f, 0.8f, 0.2f);
    point_color = new Vector3(0.4f, 0.4f, 0.8f);


    


    //set the material
    MAT = GetComponent<Renderer>().material;
    MAT.mainTexture = new Texture2D(Screen.width, Screen.height);
    MAT.color = new Color(1,1,1);
    Object_list = new List<Objectsin>();


   createlist();

  




    }


    void Update()
    {
        if (Input.GetKey( "1" ))
        {
            part = 1;
        }
        else if (Input.GetKey("2"))
        {
            part = 2;
        }
        else if (Input.GetKey("p"))
        {
            po = 1;
        }else if (Input.GetKey("o")){
            po = 2;
        }
          //Run the code in the class
        pixTex =  new Texture2D(col, row, TextureFormat.RGB24, true);
        RayCast RayCast_M = new RayCast();
        RayCast_M.caster(part, po, sun_dir, pointPosition, sun_color, point_color, eye, pixTex, Object_list, Width, Height, row, col);

    }


        void OnPostRender() {
        GL.LoadIdentity();
        GL.Viewport( new Rect( 0, 0, Screen.width, Screen.height ) );
        Matrix4x4 ortho = Matrix4x4.Ortho( 0f, 1f, 0f, 1f, 1f, -1f );
        GL.LoadProjectionMatrix(ortho);
        MAT.SetPass(0);
        GL.PushMatrix();
        Graphics.DrawTexture( new Rect( 0, 0, 1, 1 ), pixTex);
        GL.PopMatrix();

    }
}
