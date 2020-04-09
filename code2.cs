using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Globalization;



public class code3 : MonoBehaviour
{
    public Material MAT;
    public float FOV;
    public float aspect;
    public float near;
    public float far;
    public Vector3 cEye;
    public Vector3 lookAt;
    public Vector3 upV;
    public Vector4 uVectorDx;
    
    public Vector3 uVec;
    public Vector3 vVec;
    public Vector3 nVec;

    public Vector4 uDx;
    public Vector4 vDy;
    public Vector4 nDz;

    public float[] x;
    public float[] y;

    public float angle_r;
    public float angle_p;
    public float angle_y;
    public float slide_n;
    public float slide_u;
    public float slide_v;

    public float t1 = 0.5f;
    public float t2 = 0.5f;
    public int count1 = 0;
    public int CU_1 = 1;
    public int CY_1 = 1;
    public int CZ_1 = 1;

    public float rotate_angel = 0;
    public float moveCount = 0;
    public float moveStep;

    public List<Vector3> vecstore = new List<Vector3>();





//These are the function I build which need to be used

    public void cube1(){
        GL.PushMatrix();
        UnityEngine.Matrix4x4 matrixMove = UnityEngine.Matrix4x4.Translate( new Vector3( -15 + moveStep, 0, 0) );
        GL.modelview =  GL.modelview*matrixMove;
        GL.Begin(GL.LINES);
        GL.Color(Color.cyan);

        GL.Vertex3(0, 0, 0);
        GL.Vertex3(5, 0, 0);

        GL.Vertex3(5, 0, 0);
        GL.Vertex3(5, 5, 0);

        GL.Vertex3(5, 5, 0);
        GL.Vertex3(0, 5, 0);

        GL.Vertex3(0, 5, 0);
        GL.Vertex3(0, 0, 0);

        GL.Vertex3(0, 5, 0);
        GL.Vertex3(0, 5, 5);

        GL.Vertex3(0, 5, 5);
        GL.Vertex3(0, 0, 5);

        GL.Vertex3(0, 0, 5);
        GL.Vertex3(0, 0, 0);

        GL.Vertex3(5, 5, 0);
        GL.Vertex3(5, 5, 5);

        GL.Vertex3(5, 5, 5);
        GL.Vertex3(5, 0, 5);

        GL.Vertex3(5, 0, 5);
        GL.Vertex3(5, 0, 0);

        GL.Vertex3(0, 5, 5);
        GL.Vertex3(5, 5, 5);

        GL.Vertex3(0, 0, 5);
        GL.Vertex3(5, 0, 5);
        GL.End();
        GL.PopMatrix();
    }


        public void cube2(){
        GL.PushMatrix();
        UnityEngine.Matrix4x4 matrixMove = UnityEngine.Matrix4x4.Translate( new Vector3(10, 0, 0) );
        GL.modelview =  GL.modelview*matrixMove;
        GL.Begin(GL.LINES);
        GL.Color(Color.cyan);

        GL.Vertex3(0, 0, 0);
        GL.Vertex3(5, 0, 0);

        GL.Vertex3(5, 0, 0);
        GL.Vertex3(5, 5, 0);

        GL.Vertex3(5, 5, 0);
        GL.Vertex3(0, 5, 0);

        GL.Vertex3(0, 5, 0);
        GL.Vertex3(0, 0, 0);

        GL.Vertex3(0, 5, 0);
        GL.Vertex3(0, 5, 5);

        GL.Vertex3(0, 5, 5);
        GL.Vertex3(0, 0, 5);

        GL.Vertex3(0, 0, 5);
        GL.Vertex3(0, 0, 0);

        GL.Vertex3(5, 5, 0);
        GL.Vertex3(5, 5, 5);

        GL.Vertex3(5, 5, 5);
        GL.Vertex3(5, 0, 5);

        GL.Vertex3(5, 0, 5);
        GL.Vertex3(5, 0, 0);

        GL.Vertex3(0, 5, 5);
        GL.Vertex3(5, 5, 5);

        GL.Vertex3(0, 0, 5);
        GL.Vertex3(5, 0, 5);
        GL.End();
        GL.PopMatrix();
    }

    public void defineXY()
    {
        x = new float[10];
        y = new float[10];
        //simple mesh
        x[0] = 0;
        y[0] = 0;

        x[1] = 1f;
        y[1] = 1f;

        x[2] = 2f;
        y[2] = 2f;

        x[3] = 4f;
        y[3] = 3f;

        x[4] = 4f;
        y[4] = 4f;

        x[5] = 3f;
        y[5] = 5f;

        x[6] = 2f;
        y[6] = 6f;


        x[7] = 1f;
        y[7] = 7f;

        x[8] = 0;
        y[8] = 1f;

    }


    public void SofRev()
    {
        GL.PushMatrix();
        Quaternion rotation = Quaternion.Euler(0,0,rotate_angel);
        UnityEngine.Matrix4x4 rotateM = UnityEngine.Matrix4x4.Rotate(rotation) * GL.modelview;
        GL.modelview = rotateM;
        defineXY();
        int i, j, numValsU = 20, numValsV = 20;// set these
        double u, v, uMin = (-3.14f / 2), vMin = -2 * 3.14f, uMax = 3.14f / 2, vMax = 2 * 3.14f;
        double delU = (uMax - uMin) / (numValsU - 1);
        double delV = (vMax - vMin) / (numValsV - 1);
        {
            for (j = 0, v = vMin; j < numValsV; j++, v += delV)
            {
                GL.Begin(GL.LINE_STRIP);
                GL.Color(new Color(1, 1, 1));
                for (int index = 0; index < 8; index++)
                {
                    GL.Vertex3((float)(x[index] * Math.Cos(v)), y[index], (float)Math.Sin(v));
                }

                GL.End();
            }

        }
        GL.PopMatrix();
 
    }

        //draw the circle
        public void circle(float x, float y, float z, float r){
        for( int i = 0; i <= 360; i++ ) {
        GL.Begin( GL.LINES );
        float radius1 = r;
        GL.Color(new Color(1, 1, 1));
        
        float x1 = radius1 * (float)Math.Cos( Math.PI / 180 * (float)i );
        float y1 = radius1 * (float)Math.Sin( Math.PI / 180 * (float)i );
        float x2 = radius1 * (float)Math.Cos( Math.PI / 180 * (float)(i+1) );
        float y2 = radius1 * (float)Math.Sin( Math.PI / 180 * (float)(i+1) );


        GL.Vertex3( x, (float)x1+y, (float)y1+z);
        GL.Vertex3( x, (float)x2+y, (float)y2+z);


        GL.End();
        }
        }

        //draw the cylinder
        public void cylinder(float x, float y, float z, float h){
        GL.PushMatrix();
        UnityEngine.Matrix4x4 matrixMove1 = UnityEngine.Matrix4x4.Translate( new Vector3(0, -5, 0) );
        GL.modelview =  GL.modelview*matrixMove1;
        float r = 5;
        for(int i = 0; i <= h; i++){
            circle(x+i, y, z, r);
            r = r - 1;
        }
        for( int i = 0; i <= 6; i++ ) {
        GL.Begin( GL.LINES );
        float radius1 = 5f;
        GL.Color(new Color(1, 1, 1));
        
        float x1 = radius1 * (float)Math.Cos( Math.PI / 3 * (float)i );
        float y1 = radius1 * (float)Math.Sin( Math.PI / 3 * (float)i );


        GL.Vertex3(x, x1, y1);
        GL.Vertex3(x+h, 0, 0);

        GL.End();
        
        }


        GL.PopMatrix();
        
        }
    
    public double distance(Vector3 m, Vector3 n)
    {
    double a = Math.Sqrt((m[0]-n[0])*(m[0]-n[0]) + (m[1]-n[1])*(m[1]-n[1]) + (m[2]-n[2])*(m[2]-n[2]));
    return a;
    }


    public Tuple<Vector3, Vector3>  roll(float angle, Vector3 u, Vector3 v)
    { // roll the camera through angle degrees
    float cs = (float)Math.Cos(3.14159265/180 * angle);
    //convert degrees to radians
    float sn = (float)Math.Sin(3.14159265/180 * angle);
    Vector3 t = u; // remember old u
    u = new Vector3(cs*t.x - sn*v.x, cs*t.y - sn*v.y, cs*t.z - sn*v.z);
    v = new Vector3(sn*t.x + cs*v.x, sn*t.y + cs*v.y, sn*t.z + cs*v.z);
    Tuple<Vector3, Vector3> tup = new Tuple<Vector3, Vector3>(u, v);
    return tup;
    }

    public Tuple<Vector3, Vector3>  pitch(float angle, Vector3 n, Vector3 v)
    { // roll the camera through angle degrees
    float cs = (float)Math.Cos(3.14159265/180 * angle);
    //convert degrees to radians
    float sn = (float)Math.Sin(3.14159265/180 * angle);
    Vector3 t = n; // remember old n
    n = new Vector3(cs*t.x - sn*v.x, cs*t.y - sn*v.y, cs*t.z - sn*v.z);
    v = new Vector3(sn*t.x + cs*v.x, sn*t.y + cs*v.y, sn*t.z + cs*v.z);
    Tuple<Vector3, Vector3> tup = new Tuple<Vector3, Vector3>(n, v);
    return tup;
    }

    
    public Tuple<Vector3, Vector3>  yaw(float angle, Vector3 u, Vector3 n)
    { // roll the camera through angle degrees
    float cs = (float)Math.Cos(3.14159265/180 * angle);
    //convert degrees to radians
    float sn = (float)Math.Sin(3.14159265/180 * angle);
    Vector3 t = u; // remember old u
    u = new Vector3(cs*t.x - sn*n.x, cs*t.y - sn*n.y, cs*t.z - sn*n.z);
    n = new Vector3(sn*t.x + cs*n.x, sn*t.y + cs*n.y, sn*t.z + cs*n.z);
    Tuple<Vector3, Vector3> tup = new Tuple<Vector3, Vector3>(u, n);
    return tup;
    }


    
    public Vector3 slide(float delU, float delV, float delN, Vector3 u, Vector3 v, Vector3 n)
    {
    cEye.x += delU*u.x + delV*v.x + delN*n.x;
    cEye.y += delU*u.y + delV*v.y + delN*n.y;
    cEye.z += delU*u.z + delV*v.z + delN*n.z;
    return cEye;
    }

    public void loadfile()
    {
        StreamReader reader = new StreamReader("Mug.obj");
        string line;
        while (!string.IsNullOrEmpty(line = reader.ReadLine()))
            {
                string[] spearator = {" "}; 

                string[] stringlist = line.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                if(stringlist[0] == "v"){
                    float x = float.Parse(stringlist[1], CultureInfo.InvariantCulture.NumberFormat);
                    float y = float.Parse(stringlist[2], CultureInfo.InvariantCulture.NumberFormat);
                    float z = float.Parse(stringlist[3], CultureInfo.InvariantCulture.NumberFormat);
                    Vector3 vec = new Vector3(x,y,z);
                    vecstore.Add(vec);
                }
        
            }
    }

    public void drawloader(){
        GL.PushMatrix();
        GL.Begin(GL.LINE_STRIP);
        for(int i = 0; i < vecstore.Count; i++){
            GL.Vertex3(vecstore[i].x, vecstore[i].y, vecstore[i].z);
        }
        GL.End();
        GL.PopMatrix();
    }


    // Start is called before the first frame update
    void Start()
    {

        FOV = 60;
        aspect = (float)3 / 4;
        near = 0.3f;
        far = 100;
        cEye = new Vector3(0, 0, -50f);
        lookAt = new Vector3(0, 0, 0);
        upV = new Vector3(0, 1, 0);
        


        nVec = lookAt - cEye;
        nVec.Normalize();

        uVec = Vector3.Cross(upV, nVec);
        uVec.Normalize();
        vVec = Vector3.Cross(nVec, uVec);
        vVec.Normalize();



    }

    // Update is called once per frame
    void Update()
    {
        

        rotate_angel = rotate_angel + 30;
        moveCount = moveCount + 1;
        if(moveCount%2 == 0){
            moveStep = 0;
        }else{
            moveStep = 0.3f;
        }
        //rotate the camera with keyboard
        slide_n = 0f;
        slide_u = 0f;
        slide_v = 0f;
        angle_r = 0;
        angle_p = 0;
        angle_y = 0;






        if (Input.GetKey( "5" ))
        {
            slide_n += t1;
            Debug.Log("slide_n" + slide_n);
        }
        else if (Input.GetKey("1"))
        {
            slide_n -= t1;
        }
        else if (Input.GetKey("4"))
        {
            slide_u += t1;
        }
        else if (Input.GetKey("6"))
        {
            slide_u -= t1;
        }
        else if (Input.GetKey("8"))
        {
            slide_v += t1;
        }
        else if (Input.GetKey("2"))
        {
            slide_v -= t1;
        }
        else if(Input.GetKey("a"))
        {
            angle_y += t2;
        }
        else if (Input.GetKey("d"))
        {
            angle_y -= t2;
        }
        else if (Input.GetKey("w"))
        {
            angle_p += t2;
        }
        else if (Input.GetKey("s"))
        {
            angle_p -= t2;
        }
        else if (Input.GetKey("q"))
        {
            angle_r += t2;
        }
        else if (Input.GetKey("e"))
        {
            angle_r -= t2;
        }

        //we should update the nVector, uVector and vVector based on the order from keyboard.


        Tuple<Vector3, Vector3> tup1 = roll(angle_r, uVec, vVec); 
        uVec = tup1.Item1;
        vVec = tup1.Item2;

    
        Tuple<Vector3, Vector3> tup2 = pitch(angle_p, nVec, vVec); 
        nVec = tup2.Item1;
        vVec = tup2.Item2;


        Tuple<Vector3, Vector3> tup3 = yaw(angle_y, uVec, nVec); 
        uVec = tup3.Item1;
        nVec = tup3.Item2;


        cEye = slide(slide_u, slide_v, slide_n, uVec, vVec, nVec);

        float dx = Vector3.Dot(cEye, uVec);
        float dy = Vector3.Dot(cEye, vVec);
        float dz = Vector3.Dot(cEye, nVec);
 
        uDx = new Vector4(uVec.x, uVec.y, uVec.z, dx);
        vDy = new Vector4(vVec.x, vVec.y, vVec.z, dy);
        nDz = new Vector4(nVec.x, nVec.y, nVec.z, dz);


        //build the game
        Debug.Log("cEye:" + cEye);

        if(cEye.x <= 15 && cEye.x >= 5 && cEye.y >= -10 && cEye.y <= 0 && cEye.z <= 0 && cEye.z >= -10 && count1 == 0){
            CU_1 = 2;
            count1 = count1 + 1;
        }
        if(cEye.x <= -5 && cEye.x >= -15 && cEye.y >= -10 && cEye.y <= 0 && cEye.z <= 0 && cEye.z >= -10 && count1 == 1){
            CU_1 = 3;
        }

        Vector3 Original = new Vector3(0, 0, 0);
        if(distance(cEye, Original) <= 5){
            CY_1 = 2;
        }

        Vector3 locate = new Vector3(3, 5, 0);
        if(distance(cEye, locate) <= 5){
            CZ_1 = 2;
        }

    }


    void OnPostRender()
    {
        GL.Clear(false, true, Color.white, 0.0f);
        MAT = GetComponent<Renderer>().material;
        GL.LoadIdentity();
        GL.PushMatrix();
        MAT.SetPass(0);
        //UnityEngine.Matrix4x4 upd = UnityEngine.Matrix4x4.Ortho(0, 5, 0, 5, 0.3f, 100);

        UnityEngine.Matrix4x4 upd = UnityEngine.Matrix4x4.Perspective(FOV, aspect, near, far);
        //Use the function to set up the look at function
        UnityEngine.Matrix4x4 cameraM = UnityEngine.Matrix4x4.LookAt(cEye, lookAt, upV);
        //GL.modelview = cameraM;

       

        UnityEngine.Matrix4x4 ownM;
        ownM = UnityEngine.Matrix4x4.identity;
 
        ownM.SetRow(0, uDx);
        ownM.SetRow(1, vDy);
        ownM.SetRow(2, nDz);
        GL.modelview = ownM; 

      //make the object hard to get
        GL.LoadProjectionMatrix(upd);
        if(CU_1 == 1){
        cube1();
        }else if(CU_1 == 2){
        cube2();
        }

        if(CZ_1 == 1){
        cylinder(0, 0, 0, 5);
        }

        if(CY_1 == 1){
        SofRev();
        }

        loadfile();
        drawloader();

        GL.PopMatrix();

 

        


        


    }
}