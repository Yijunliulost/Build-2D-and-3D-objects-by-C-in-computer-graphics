using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class code2 : MonoBehaviour
{
    
    // Start is called before the first frame update
    List<int> stop = new List<int>();
    List<int> load = new List<int>();
    List<int> color = new List<int>();

    List<float> array1 = new List<float>();
    List<float> array2 = new List<float>();




    int count = 0;
    int indicate = 999;
    int index = 999;
    private bool mousePress = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if( Input.GetMouseButtonDown( 0 ) ) mousePress = true;
        else if( Input.GetMouseButtonUp( 0 ) ) mousePress = false;

        if (mousePress)
        {
            Vector2 mousePos = new Vector2();
            Debug.Log("mouse at: x:" + Input.mousePosition.x + " and y:" + Input.mousePosition.y);

            mousePos.y = /*Camera.main.pixelHeight -*/ Input.mousePosition.y;
            Debug.Log("new mouse at: x:" + Input.mousePosition.x + " and y:" + mousePos.y);

            Vector3 WorldPoint = new Vector3();
            WorldPoint= Camera.main.
            ScreenToWorldPoint(new Vector3(Input.mousePosition.x, mousePos.y, Camera.main.nearClipPlane));
            Debug.Log("world pt at: x:" + WorldPoint.x + " and y:" + WorldPoint.y);
            array1.Add(WorldPoint.x);
            array2.Add(WorldPoint.y);
            load.Add(indicate);
            color.Add(index);
            count++;
            if(WorldPoint.x >= 3 && WorldPoint.x <= 3.5f && WorldPoint.y>= 2 && WorldPoint.y <= 2.5f){
             indicate = 1;
            }else if(WorldPoint.x >= 3 && WorldPoint.x  <= 4 && WorldPoint.y>= 3 && WorldPoint.y <= 4){
             index = 1;
            }else if(WorldPoint.x >= 4.5f && WorldPoint.x <= 5.5f && WorldPoint.y>= 3 && WorldPoint.y <= 4){
             index = 2;
            }else if(WorldPoint.x >= 6f && WorldPoint.x <= 7f && WorldPoint.y>= 3 && WorldPoint.y <= 4){
             index = 3;
            }else if(WorldPoint.x >= 3 && WorldPoint.x <= 3.75f && WorldPoint.y >= 0 && WorldPoint.y <= 0.75f){
             indicate = 2;
            }else if(WorldPoint.x >= 3 && WorldPoint.x <= 4 && WorldPoint.y >= -2.5f && WorldPoint.y  <= -1.5f){
             indicate = 3;
            }else if(WorldPoint.x >= 4.8f && WorldPoint.x <= 5.2f && WorldPoint.y >= 1.8f && WorldPoint.y <= 2.2f){
             indicate = 4;
            }else if(WorldPoint.x >= 4.8f && WorldPoint.x <= 5.2f && WorldPoint.y >= 0.2f && WorldPoint.y <= 0.8f){
             indicate = 5;
            }else if(WorldPoint.x >= 4.5f && WorldPoint.x <= 5.5f && WorldPoint.y >= -2.5f && WorldPoint.y <= -1.5f){
             indicate = 6;
            }else if(WorldPoint.x >= 6 && WorldPoint.x <= 7 && WorldPoint.y >= 2 && WorldPoint.y <= 2.5f){
             indicate = 7;
            }else if(WorldPoint.x >= 6 && WorldPoint.x <= 7 && WorldPoint.y >= 0 && WorldPoint.y <= 1.25f){
             indicate = 8;
            }else if(WorldPoint.x >= 6 && WorldPoint.x <= 7 && WorldPoint.y >= -2.5 && WorldPoint.y <= -1.5f){
             indicate = 9;
            }else if(WorldPoint.x >= 3.5f && WorldPoint.x <= 6.5f && WorldPoint.y >= -4 && WorldPoint.y <= -3f){
             indicate = 10;
             index = 4;
            }else if(WorldPoint.x >= 3.75f && WorldPoint.x <= 6 && WorldPoint.y >= -1.25f && WorldPoint.y <= 0){
             indicate = 11;
            }
        }else if(!mousePress){
            stop.Add(count);
        }

        //Once we click on right of mouse, we can delete the lines we draw
        if( Input.GetMouseButtonDown(1) ) { 
                array1.Clear();
                array2.Clear();
                load.Clear();
                color.Clear();
                stop.Clear();
                count = 0;
                indicate = 999;
                index = 999;

                return;
            }


 
    }


    public Material myMat;
    void OnPostRender()
    {
        GL.Clear(false, true, Color.white, 0.0f);
        myMat = GetComponent<Renderer>().material;
        //GL.LoadIdentity();
        GL.PushMatrix();

        myMat.SetPass(0);
        //Here is my toolbar
        // draw the circle
        for( int i = 0; i <= 360; i++ ) {
        GL.Begin( GL.TRIANGLES );
        float radius1 = 0.2f;
        GL.Color(new Color(0, 0, 0));
        
        float x1 = radius1 * (float)Math.Cos( Math.PI / 180 * (float)i );
        float y1 = radius1 * (float)Math.Sin( Math.PI / 180 * (float)i );
        float x2 = radius1 * (float)Math.Cos( Math.PI / 180 * (float)(i+1) );
        float y2 = radius1 * (float)Math.Sin( Math.PI / 180 * (float)(i+1) );


        GL.Vertex3(5, 2, 0);
        GL.Vertex3( (float)x1+5, (float)y1+2, 0 );
        GL.Vertex3( (float)x2+5, (float)y2+2, 0 );

        GL.End();
        }
        
        for( int i = 0; i <= 360; i++ ) {
        GL.Begin( GL.TRIANGLES );
        float radius2 = 0.4f;
        GL.Color(new Color(0, 0, 0));
        
        float x3 = radius2 * (float)Math.Cos( Math.PI / 180 * (float)i );
        float y3 = radius2 * (float)Math.Sin( Math.PI / 180 * (float)i );
        float x4 = radius2 * (float)Math.Cos( Math.PI / 180 * (float)(i+1) );
        float y4 = radius2 * (float)Math.Sin( Math.PI / 180 * (float)(i+1) );


        GL.Vertex3(5, 0.5f, 0);
        GL.Vertex3( (float)x3+5, (float)y3+0.5f, 0 );
        GL.Vertex3( (float)x4+5, (float)y4+0.5f, 0 );

        GL.End();
        }


        for( int i = 0; i <= 360; i++ ) {
        GL.Begin( GL.TRIANGLES );
        float radius3 = 0.6f;
        GL.Color(new Color(0, 0, 0));
        
        float x5 = radius3 * (float)Math.Cos( Math.PI / 180 * (float)i );
        float y5 = radius3 * (float)Math.Sin( Math.PI / 180 * (float)i );
        float x6 = radius3 * (float)Math.Cos( Math.PI / 180 * (float)(i+1) );
        float y6 = radius3 * (float)Math.Sin( Math.PI / 180 * (float)(i+1) );


        GL.Vertex3(5, -2.5f, 0);
        GL.Vertex3( (float)x5+5, (float)y5-2f, 0 );
        GL.Vertex3( (float)x6+5, (float)y6-2f, 0 );

        GL.End();
        }

        // draw the triangle
        GL.Begin(GL.TRIANGLES);
        GL.Color(new Color(0, 0, 0));
        GL.Vertex3(6, 2, 0);
        GL.Vertex3(6.5f, 2, 0);
        GL.Vertex3(6.5f, 2.5f, 0);
        GL.End();

        GL.Begin(GL.TRIANGLES);
        GL.Color(new Color(0, 0, 0));
        GL.Vertex3(6, 0.25f, 0);
        GL.Vertex3(6.75f, 0.25f, 0);
        GL.Vertex3(6.75f, 1f, 0);
        GL.End();

        GL.Begin(GL.TRIANGLES);
        GL.Color(new Color(0, 0, 0));
        GL.Vertex3(6, -2.5f, 0);
        GL.Vertex3(7, -2.5f, 0);
        GL.Vertex3(7, -1.5f, 0);
        GL.End();

        // draw the square
        GL.Begin(GL.QUADS);
        GL.Color(new Color(0, 0, 0));
        GL.Vertex3(3, 2, 0);
        GL.Vertex3(3.5f, 2, 0);
        GL.Vertex3(3.5f, 2.5f, 0);
        GL.Vertex3(3, 2.5f, 0);
        GL.End();

        GL.Begin(GL.QUADS);
        GL.Color(new Color(0, 0, 0));
        GL.Vertex3(3, 0, 0);
        GL.Vertex3(3.75f,0, 0);
        GL.Vertex3(3.75f, 0.75f, 0);
        GL.Vertex3(3f, 0.75f, 0);
        GL.End();

        GL.Begin(GL.QUADS);
        GL.Color(new Color(0, 0, 0));
        GL.Vertex3(3, -2.5f, 0);
        GL.Vertex3(4, -2.5f, 0);
        GL.Vertex3(4, -1.5f, 0);
        GL.Vertex3(3, -1.5f, 0);
        GL.End();

        //color toolbar
        GL.Begin(GL.QUADS);
        GL.Color(new Color(1, 0, 0));
        GL.Vertex3(3, 3, 0);
        GL.Vertex3(4, 3, 0);
        GL.Vertex3(4, 4, 0);
        GL.Vertex3(3, 4, 0);
        GL.End();


        GL.Begin(GL.QUADS);
        GL.Color(new Color(0, 1, 0));
        GL.Vertex3(4.5f, 3, 0);
        GL.Vertex3(5.5f, 3, 0);
        GL.Vertex3(5.5f, 4, 0);
        GL.Vertex3(4.5f, 4, 0);
        GL.End();


        GL.Begin(GL.QUADS);
        GL.Color(new Color(0, 0, 1));
        GL.Vertex3(6, 3, 0);
        GL.Vertex3(7, 3, 0);
        GL.Vertex3(7, 4, 0);
        GL.Vertex3(6, 4, 0);
        GL.End();
 
        //draw the divide line
        GL.Begin(GL.LINES);       
        GL.Color(new Color(0, 0, 0));
        GL.Vertex3(2.5f ,-6, 0);
        GL.Vertex3(2.5f, 6, 0);
        GL.End();

        //draw a rectangular region
        GL.Begin(GL.LINES);
        GL.Color(new Color(0, 0, 0));
        GL.Vertex3(3.5f, -4, 0);
        GL.Vertex3(6.5f, -4, 0);

        GL.Vertex3(6.5f, -4, 0);
        GL.Vertex3(6.5f, -3, 0);

        GL.Vertex3(6.5f, -3, 0);
        GL.Vertex3(3.5f, -3, 0);

        GL.Vertex3(3.5f, -3, 0);
        GL.Vertex3(3.5f, -4, 0);
        GL.End();

        //draw a another stamp tool of a complex shape which are consisted of triangels and quads
        GL.Begin(GL.TRIANGLES);
        GL.Color(new Color(0, 0, 0));
        GL.Vertex3(3.75f, -0.5f, 0);
        GL.Vertex3(4.5f, -0.5f, 0);
        GL.Vertex3(4.5f, -1.25f, 0);
        GL.End();

        GL.Begin(GL.QUADS);
        GL.Color(new Color(0, 0, 0));
        GL.Vertex3(4.5f, -1.25f, 0);
        GL.Vertex3(4.5f,-0.75f, 0);
        GL.Vertex3(5.5f,-0.75f, 0);
        GL.Vertex3(5.5f, -1.25f, 0);
        GL.End();

        GL.Begin(GL.TRIANGLES);
        GL.Color(new Color(0, 0, 0));
        GL.Vertex3(5.5f, -0.5f, 0);
        GL.Vertex3(5.5f, -1.25f, 0);
        GL.Vertex3(6.25f, -0.5f, 0);
        GL.End();

        GL.Begin(GL.QUADS);
        GL.Color(new Color(0, 0, 0));
        GL.Vertex3(5.75f, -0.5f, 0);
        GL.Vertex3(6f,-0.5f, 0);
        GL.Vertex3(6f,-0.25f, 0);
        GL.Vertex3(5.75f, -0.25f, 0);
        GL.End();


        if(count>1){
        for(int j = 0; j<count-1; j++){
        if(array1[j] < 2.5f && array1[j+1] < 2.5f){
            if(load[j] == 999 && color[j] == 999){  
                if(stop.Contains(j+1)){
                GL.Begin(GL.LINE_STRIP);       
                GL.Color(new Color(1, 1, 1));
                GL.Vertex3(array1[j], array2[j], 0);
                GL.Vertex3(array1[j+1], array2[j+1], 0);
                GL.End();
                }else{
                GL.Begin(GL.LINES);       
                GL.Color(new Color(0, 0, 0));
                GL.Vertex3(array1[j], array2[j], 0);
                GL.Vertex3(array1[j+1], array2[j+1], 0);
                GL.End();
                }

            }
        }
        }
        }





        //draw the line with mouse
        if(count>1){
        for(int j = 0; j<count-1;j++){

        if(array1[j] < 2.5f && array1[j+1] < 2.5f){
                if(load[j] == 1){
                if(color[j] == 1){
                GL.Begin(GL.QUADS);
                GL.Color(new Color(1, 0, 0));
                GL.Vertex3(array1[j]-0.25f, array2[j]-0.25f, 0);
                GL.Vertex3(array1[j]-0.25f, array2[j]+0.25f, 0);
                GL.Vertex3(array1[j]+0.25f, array2[j]+0.25f, 0);
                GL.Vertex3(array1[j]+0.25f, array2[j]-0.25f, 0);
                GL.End();
                }else if(color[j] == 2){
                GL.Begin(GL.QUADS);
                GL.Color(new Color(0, 1, 0));
                GL.Vertex3(array1[j]-0.25f, array2[j]-0.25f, 0);
                GL.Vertex3(array1[j]-0.25f, array2[j]+0.25f, 0);
                GL.Vertex3(array1[j]+0.25f, array2[j]+0.25f, 0);
                GL.Vertex3(array1[j]+0.25f, array2[j]-0.25f, 0);
                GL.End();
                }else if(color[j] == 3){
                GL.Begin(GL.QUADS);
                GL.Color(new Color(0, 0, 1));
                GL.Vertex3(array1[j]-0.25f, array2[j]-0.25f, 0);
                GL.Vertex3(array1[j]-0.25f, array2[j]+0.25f, 0);
                GL.Vertex3(array1[j]+0.25f, array2[j]+0.25f, 0);
                GL.Vertex3(array1[j]+0.25f, array2[j]-0.25f, 0);
                GL.End();
                }
            }else if(load[j] == 2){
                if(color[j] == 1){
                GL.Begin(GL.QUADS);
                GL.Color(new Color(1, 0, 0));
                GL.Vertex3(array1[j]-0.375f, array2[j]-0.375f, 0);
                GL.Vertex3(array1[j]-0.375f, array2[j]+0.375f, 0);
                GL.Vertex3(array1[j]+0.375f, array2[j]+0.375f, 0);
                GL.Vertex3(array1[j]+0.375f, array2[j]-0.375f, 0);
                GL.End();
                }else if(color[j] == 2){
                GL.Begin(GL.QUADS);
                GL.Color(new Color(0, 1, 0));
                GL.Vertex3(array1[j]-0.375f, array2[j]-0.375f, 0);
                GL.Vertex3(array1[j]-0.375f, array2[j]+0.375f, 0);
                GL.Vertex3(array1[j]+0.375f, array2[j]+0.375f, 0);
                GL.Vertex3(array1[j]+0.375f, array2[j]-0.375f, 0);
                GL.End();
                }else if(color[j] == 3){
                GL.Begin(GL.QUADS);
                GL.Color(new Color(0, 0, 1));
                GL.Vertex3(array1[j]-0.375f, array2[j]-0.375f, 0);
                GL.Vertex3(array1[j]-0.375f, array2[j]+0.375f, 0);
                GL.Vertex3(array1[j]+0.375f, array2[j]+0.375f, 0);
                GL.Vertex3(array1[j]+0.375f, array2[j]-0.375f, 0);
                GL.End();
                }
            }else if(load[j] == 3){
                if(color[j] == 1){
                GL.Begin(GL.QUADS);
                GL.Color(new Color(1, 0, 0));
                GL.Vertex3(array1[j]-0.5f, array2[j]-0.5f, 0);
                GL.Vertex3(array1[j]-0.5f, array2[j]+0.5f, 0);
                GL.Vertex3(array1[j]+0.5f, array2[j]+0.5f, 0);
                GL.Vertex3(array1[j]+0.5f, array2[j]-0.5f, 0);
                GL.End();
                }else if(color[j] == 2){
                GL.Begin(GL.QUADS);
                GL.Color(new Color(0, 1, 0));
                GL.Vertex3(array1[j]-0.5f, array2[j]-0.5f, 0);
                GL.Vertex3(array1[j]-0.5f, array2[j]+0.5f, 0);
                GL.Vertex3(array1[j]+0.5f, array2[j]+0.5f, 0);
                GL.Vertex3(array1[j]+0.5f, array2[j]-0.5f, 0);
                GL.End();
                }else if(color[j] == 3){
                GL.Begin(GL.QUADS);
                GL.Color(new Color(0, 0, 1));
                GL.Vertex3(array1[j]-0.5f, array2[j]-0.5f, 0);
                GL.Vertex3(array1[j]-0.5f, array2[j]+0.5f, 0);
                GL.Vertex3(array1[j]+0.5f, array2[j]+0.5f, 0);
                GL.Vertex3(array1[j]+0.5f, array2[j]-0.5f, 0);
                GL.End();  
                }
            }else if(load[j] == 4){
                if(color[j] == 1){
                    for( int k = 0; k <= 360; k++ ) {
                    GL.Begin( GL.TRIANGLES );
                    float radius1 = 0.2f;
                    GL.Color(new Color(1, 0, 0));
        
                    float x1 = radius1 * (float)Math.Cos( Math.PI / 180 * (float)k );
                    float y1 = radius1 * (float)Math.Sin( Math.PI / 180 * (float)k );
                    float x2 = radius1 * (float)Math.Cos( Math.PI / 180 * (float)(k+1) );
                    float y2 = radius1 * (float)Math.Sin( Math.PI / 180 * (float)(k+1) );


                    GL.Vertex3(array1[j], array2[j], 0);
                    GL.Vertex3( (float)x1+array1[j], (float)y1+array2[j], 0 );
                    GL.Vertex3( (float)x2+array1[j], (float)y2+array2[j], 0 );

                    GL.End();
                    }
                }else if(color[j] == 2){
                    for( int k = 0; k <= 360; k++ ) {
                    GL.Begin( GL.TRIANGLES );
                    float radius1 = 0.2f;
                    GL.Color(new Color(0, 1, 0));
        
                    float x1 = radius1 * (float)Math.Cos( Math.PI / 180 * (float)k );
                    float y1 = radius1 * (float)Math.Sin( Math.PI / 180 * (float)k );
                    float x2 = radius1 * (float)Math.Cos( Math.PI / 180 * (float)(k+1) );
                    float y2 = radius1 * (float)Math.Sin( Math.PI / 180 * (float)(k+1) );


                    GL.Vertex3(array1[j], array2[j], 0);
                    GL.Vertex3( (float)x1+array1[j], (float)y1+array2[j], 0 );
                    GL.Vertex3( (float)x2+array1[j], (float)y2+array2[j], 0 );

                    GL.End();
                }
                }else if(color[j] == 3){
                    for( int k = 0; k <= 360; k++ ) {
                    GL.Begin( GL.TRIANGLES );
                    float radius1 = 0.2f;
                    GL.Color(new Color(0, 0, 1));
        
                    float x1 = radius1 * (float)Math.Cos( Math.PI / 180 * (float)k );
                    float y1 = radius1 * (float)Math.Sin( Math.PI / 180 * (float)k );
                    float x2 = radius1 * (float)Math.Cos( Math.PI / 180 * (float)(k+1) );
                    float y2 = radius1 * (float)Math.Sin( Math.PI / 180 * (float)(k+1) );


                    GL.Vertex3(array1[j], array2[j], 0);
                    GL.Vertex3( (float)x1+array1[j], (float)y1+array2[j], 0 );
                    GL.Vertex3( (float)x2+array1[j], (float)y2+array2[j], 0 );

                    GL.End();
                }  
                }

            }else if(load[j] == 5){
                    if(color[j] == 1){
                    for( int k = 0; k <= 360; k++ ) {
                    GL.Begin( GL.TRIANGLES );
                    float radius1 = 0.4f;
                    GL.Color(new Color(1, 0, 0));
        
                    float x1 = radius1 * (float)Math.Cos( Math.PI / 180 * (float)k );
                    float y1 = radius1 * (float)Math.Sin( Math.PI / 180 * (float)k );
                    float x2 = radius1 * (float)Math.Cos( Math.PI / 180 * (float)(k+1) );
                    float y2 = radius1 * (float)Math.Sin( Math.PI / 180 * (float)(k+1) );


                    GL.Vertex3(array1[j], array2[j], 0);
                    GL.Vertex3( (float)x1+array1[j], (float)y1+array2[j], 0 );
                    GL.Vertex3( (float)x2+array1[j], (float)y2+array2[j], 0 );

                    GL.End();
                    }
                }else if(color[j] == 2){
                    for( int k = 0; k <= 360; k++ ) {
                    GL.Begin( GL.TRIANGLES );
                    float radius1 = 0.4f;
                    GL.Color(new Color(0, 1, 0));
        
                    float x1 = radius1 * (float)Math.Cos( Math.PI / 180 * (float)k );
                    float y1 = radius1 * (float)Math.Sin( Math.PI / 180 * (float)k );
                    float x2 = radius1 * (float)Math.Cos( Math.PI / 180 * (float)(k+1) );
                    float y2 = radius1 * (float)Math.Sin( Math.PI / 180 * (float)(k+1) );


                    GL.Vertex3(array1[j], array2[j], 0);
                    GL.Vertex3( (float)x1+array1[j], (float)y1+array2[j], 0 );
                    GL.Vertex3( (float)x2+array1[j], (float)y2+array2[j], 0 );

                    GL.End();
                    }  
                }else if (color[j] == 3){
                    for( int k = 0; k <= 360; k++ ) {
                    GL.Begin( GL.TRIANGLES );
                    float radius1 = 0.4f;
                    GL.Color(new Color(0, 0, 1));
        
                    float x1 = radius1 * (float)Math.Cos( Math.PI / 180 * (float)k );
                    float y1 = radius1 * (float)Math.Sin( Math.PI / 180 * (float)k );
                    float x2 = radius1 * (float)Math.Cos( Math.PI / 180 * (float)(k+1) );
                    float y2 = radius1 * (float)Math.Sin( Math.PI / 180 * (float)(k+1) );


                    GL.Vertex3(array1[j], array2[j], 0);
                    GL.Vertex3( (float)x1+array1[j], (float)y1+array2[j], 0 );
                    GL.Vertex3( (float)x2+array1[j], (float)y2+array2[j], 0 );

                    GL.End();
                    }
                }
            }else if(load[j] == 6){
                if(color[j] == 1){
                    for( int k = 0; k <= 360; k++ ) {
                    GL.Begin( GL.TRIANGLES );
                    float radius1 = 0.6f;
                    GL.Color(new Color(1, 0, 0));
        
                    float x1 = radius1 * (float)Math.Cos( Math.PI / 180 * (float)k );
                    float y1 = radius1 * (float)Math.Sin( Math.PI / 180 * (float)k );
                    float x2 = radius1 * (float)Math.Cos( Math.PI / 180 * (float)(k+1) );
                    float y2 = radius1 * (float)Math.Sin( Math.PI / 180 * (float)(k+1) );


                    GL.Vertex3(array1[j], array2[j], 0);
                    GL.Vertex3( (float)x1+array1[j], (float)y1+array2[j], 0 );
                    GL.Vertex3( (float)x2+array1[j], (float)y2+array2[j], 0 );

                    GL.End();
                    }  
                }else if(color[j] == 2){
                    for( int k = 0; k <= 360; k++ ) {
                    GL.Begin( GL.TRIANGLES );
                    float radius1 = 0.6f;
                    GL.Color(new Color(0, 1, 0));
        
                    float x1 = radius1 * (float)Math.Cos( Math.PI / 180 * (float)k );
                    float y1 = radius1 * (float)Math.Sin( Math.PI / 180 * (float)k );
                    float x2 = radius1 * (float)Math.Cos( Math.PI / 180 * (float)(k+1) );
                    float y2 = radius1 * (float)Math.Sin( Math.PI / 180 * (float)(k+1) );


                    GL.Vertex3(array1[j], array2[j], 0);
                    GL.Vertex3( (float)x1+array1[j], (float)y1+array2[j], 0 );
                    GL.Vertex3( (float)x2+array1[j], (float)y2+array2[j], 0 );

                    GL.End();
                    } 
                }else if(color[j] == 3){
                    for( int k = 0; k <= 360; k++ ) {
                    GL.Begin( GL.TRIANGLES );
                    float radius1 = 0.6f;
                    GL.Color(new Color(0, 0, 1));
        
                    float x1 = radius1 * (float)Math.Cos( Math.PI / 180 * (float)k );
                    float y1 = radius1 * (float)Math.Sin( Math.PI / 180 * (float)k );
                    float x2 = radius1 * (float)Math.Cos( Math.PI / 180 * (float)(k+1) );
                    float y2 = radius1 * (float)Math.Sin( Math.PI / 180 * (float)(k+1) );


                    GL.Vertex3(array1[j], array2[j], 0);
                    GL.Vertex3( (float)x1+array1[j], (float)y1+array2[j], 0 );
                    GL.Vertex3( (float)x2+array1[j], (float)y2+array2[j], 0 );

                    GL.End();
                    }  
                }

            }else if(load[j] == 7){
                if(color[j] == 1){
                    GL.Begin(GL.TRIANGLES);
                    GL.Color(new Color(1, 0, 0));
                    GL.Vertex3(array1[j]-0.5f, array2[j], 0);
                    GL.Vertex3(array1[j], array2[j], 0);
                    GL.Vertex3(array1[j], array2[j]+0.5f, 0);
                    GL.End();
                }else if(color[j] == 2){
                    GL.Begin(GL.TRIANGLES);
                    GL.Color(new Color(0, 1, 0));
                    GL.Vertex3(array1[j]-0.5f, array2[j], 0);
                    GL.Vertex3(array1[j], array2[j], 0);
                    GL.Vertex3(array1[j], array2[j]+0.5f, 0);
                    GL.End();
                }else if(color[j] == 3){
                    GL.Begin(GL.TRIANGLES);
                    GL.Color(new Color(0, 0, 1));
                    GL.Vertex3(array1[j]-0.5f, array2[j], 0);
                    GL.Vertex3(array1[j], array2[j], 0);
                    GL.Vertex3(array1[j], array2[j]+0.5f, 0);
                    GL.End();
                }
            }else if(load[j] == 8){
                if(color[j] == 1){
                    GL.Begin(GL.TRIANGLES);
                    GL.Color(new Color(1, 0, 0));
                    GL.Vertex3(array1[j]-0.75f, array2[j], 0);
                    GL.Vertex3(array1[j], array2[j], 0);
                    GL.Vertex3(array1[j], array2[j]+0.75f, 0);
                    GL.End();
                }else if(color[j] == 2){
                    GL.Begin(GL.TRIANGLES);
                    GL.Color(new Color(0, 1, 0));
                    GL.Vertex3(array1[j]-0.75f, array2[j], 0);
                    GL.Vertex3(array1[j], array2[j], 0);
                    GL.Vertex3(array1[j], array2[j]+0.75f, 0);
                    GL.End();
                }else if(color[j] == 3){
                    GL.Begin(GL.TRIANGLES);
                    GL.Color(new Color(0, 0, 1));
                    GL.Vertex3(array1[j]-0.75f, array2[j], 0);
                    GL.Vertex3(array1[j], array2[j], 0);
                    GL.Vertex3(array1[j], array2[j]+0.75f, 0);
                    GL.End();
                }
            }else if(load[j] == 9){
                if(color[j] == 1){
                    GL.Begin(GL.TRIANGLES);
                    GL.Color(new Color(1, 0, 0));
                    GL.Vertex3(array1[j]-1, array2[j], 0);
                    GL.Vertex3(array1[j], array2[j], 0);
                    GL.Vertex3(array1[j], array2[j]+1, 0);
                    GL.End();
                }else if(color[j] == 2){
                    GL.Begin(GL.TRIANGLES);
                    GL.Color(new Color(0, 1, 0));
                    GL.Vertex3(array1[j]-1, array2[j], 0);
                    GL.Vertex3(array1[j], array2[j], 0);
                    GL.Vertex3(array1[j], array2[j]+1, 0);
                    GL.End();
                }else if(color[j] == 3){
                    GL.Begin(GL.TRIANGLES);
                    GL.Color(new Color(0, 0, 1));
                    GL.Vertex3(array1[j]-1, array2[j], 0);
                    GL.Vertex3(array1[j], array2[j], 0);
                    GL.Vertex3(array1[j], array2[j]+1, 0);
                    GL.End();
                }
            }else if(load[j] == 10 && color[j] == 4){
                if(array1[j]<1.5f){
                GL.Begin(GL.QUADS);
                GL.Color(new Color(1, 1, 1));
                GL.Vertex3(array1[j]-1.5f, array2[j]-0.5f, 0);
                GL.Vertex3(array1[j]-1.5f, array2[j]+0.5f, 0);
                GL.Vertex3(array1[j]+1.5f, array2[j]+0.5f, 0);
                GL.Vertex3(array1[j]+1.5f, array2[j]-0.5f, 0);
                GL.End();
                } 
            }else if(load[j] == 11&& array1[j] < 1f){
                if(color[j] == 1){
                    GL.Begin(GL.TRIANGLES);
                    GL.Color(new Color(1, 0, 0));
                    GL.Vertex3(array1[j], array2[j], 0);
                    GL.Vertex3(array1[j]+0.75f, array2[j], 0);
                    GL.Vertex3(array1[j]+0.75f, array2[j]-0.75f, 0);
                    GL.End();

                    GL.Begin(GL.QUADS);
                    GL.Color(new Color(1, 0, 0));
                    GL.Vertex3(array1[j]+0.75f, array2[j]-0.75f, 0);
                    GL.Vertex3(array1[j]+0.75f, array2[j]-0.25f, 0);
                    GL.Vertex3(array1[j]+1.75f, array2[j]-0.25f, 0);
                    GL.Vertex3(array1[j]+1.75f, array2[j]-0.75f, 0);
                    GL.End();

                    GL.Begin(GL.TRIANGLES);
                    GL.Color(new Color(1, 0, 0));
                    GL.Vertex3(array1[j]+1.75f, array2[j], 0);
                    GL.Vertex3(array1[j]+1.75f, array2[j]-0.75f, 0);
                    GL.Vertex3(array1[j]+2.5f, array2[j], 0);
                    GL.End();

                    GL.Begin(GL.QUADS);
                    GL.Color(new Color(1, 0, 0));
                    GL.Vertex3(array1[j]+2f, array2[j], 0);
                    GL.Vertex3(array1[j]+2.25f, array2[j], 0);
                    GL.Vertex3(array1[j]+2.25f, array2[j]+0.25f, 0);
                    GL.Vertex3(array1[j]+2f, array2[j]+0.25f, 0);
                    GL.End();
                }else if(color[j] == 2 ){
                    GL.Begin(GL.TRIANGLES);
                    GL.Color(new Color(0, 1, 0));
                    GL.Vertex3(array1[j], array2[j], 0);
                    GL.Vertex3(array1[j]+0.75f, array2[j], 0);
                    GL.Vertex3(array1[j]+0.75f, array2[j]-0.75f, 0);
                    GL.End();

                    GL.Begin(GL.QUADS);
                    GL.Color(new Color(0, 1, 0));
                    GL.Vertex3(array1[j]+0.75f, array2[j]-0.75f, 0);
                    GL.Vertex3(array1[j]+0.75f, array2[j]-0.25f, 0);
                    GL.Vertex3(array1[j]+1.75f, array2[j]-0.25f, 0);
                    GL.Vertex3(array1[j]+1.75f, array2[j]-0.75f, 0);
                    GL.End();

                    GL.Begin(GL.TRIANGLES);
                    GL.Color(new Color(0, 1, 0));
                    GL.Vertex3(array1[j]+1.75f, array2[j], 0);
                    GL.Vertex3(array1[j]+1.75f, array2[j]-0.75f, 0);
                    GL.Vertex3(array1[j]+2.5f, array2[j], 0);
                    GL.End();

                    GL.Begin(GL.QUADS);
                    GL.Color(new Color(0, 1, 0));
                    GL.Vertex3(array1[j]+2f, array2[j], 0);
                    GL.Vertex3(array1[j]+2.25f, array2[j], 0);
                    GL.Vertex3(array1[j]+2.25f, array2[j]+0.25f, 0);
                    GL.Vertex3(array1[j]+2f, array2[j]+0.25f, 0);
                    GL.End();
                }else if(color[j] == 3){
                    GL.Begin(GL.TRIANGLES);
                    GL.Color(new Color(0, 0, 1));
                    GL.Vertex3(array1[j], array2[j], 0);
                    GL.Vertex3(array1[j]+0.75f, array2[j], 0);
                    GL.Vertex3(array1[j]+0.75f, array2[j]-0.75f, 0);
                    GL.End();

                    GL.Begin(GL.QUADS);
                    GL.Color(new Color(0, 0, 1));
                    GL.Vertex3(array1[j]+0.75f, array2[j]-0.75f, 0);
                    GL.Vertex3(array1[j]+0.75f, array2[j]-0.25f, 0);
                    GL.Vertex3(array1[j]+1.75f, array2[j]-0.25f, 0);
                    GL.Vertex3(array1[j]+1.75f, array2[j]-0.75f, 0);
                    GL.End();

                    GL.Begin(GL.TRIANGLES);
                    GL.Color(new Color(0, 0, 1));
                    GL.Vertex3(array1[j]+1.75f, array2[j], 0);
                    GL.Vertex3(array1[j]+1.75f, array2[j]-0.75f, 0);
                    GL.Vertex3(array1[j]+2.5f, array2[j], 0);
                    GL.End();

                    GL.Begin(GL.QUADS);
                    GL.Color(new Color(0, 0, 1));
                    GL.Vertex3(array1[j]+2f, array2[j], 0);
                    GL.Vertex3(array1[j]+2.25f, array2[j], 0);
                    GL.Vertex3(array1[j]+2.25f, array2[j]+0.25f, 0);
                    GL.Vertex3(array1[j]+2f, array2[j]+0.25f, 0);
                    GL.End();  
                }
            }
        }

        }   
        }













        GL.PopMatrix();

    }


}