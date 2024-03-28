using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public  class TransformMatrixObject : MonoBehaviour
{
    public MyVector3 position = new MyVector3(0, 0, 0);
    public MyVector3 rotation = new MyVector3(0, 0, 0);
    public MyVector3 scale = new MyVector3(1, 1, 1);


    MyVector3[] ModelSpaceVertices;
    MyVector3 test; 
    float Angle; 

    // Start is called before the first frame update
    void Start()
    {
        MeshFilter mf = GetComponent<MeshFilter>();

        ModelSpaceVertices = MyVector3.ConvertToMyVector3(mf.mesh.vertices);
    }

    // Update is called once per frame
    void Update()
    {
        //Angle += Time.deltaTime; 

        //Quat q  = new Quat(Angle, new MyVector3(0,1,0));

        //MyVector3 p = new MyVector3(1, 2, 3);

        //Quat K = new Quat(p);

        //Quat newK = q * K * q.Inverse();

        //MyVector3 newP = newK.GetAxis(); 

        //transform.position = MyVector3.Convert(newP); 

        

        MyVector3[] transformedVertices = new MyVector3[ModelSpaceVertices.Length];

        Matrix4by4 rollMatrix = new Matrix4by4(
            new MyVector3(Mathf.Cos(rotation.z), Mathf.Sin(rotation.z), 0),
            new MyVector3(-Mathf.Sin(rotation.z), Mathf.Cos(rotation.z), 0),
            new MyVector3(0, 0, 1),
            new MyVector3(0, 0, 0));

        Matrix4by4 pitchMatrix = new Matrix4by4(
            new MyVector3(1, 0, 0),
            new MyVector3(0, Mathf.Cos(rotation.x), Mathf.Sin(rotation.x)),
            new MyVector3(0, -Mathf.Sin(rotation.x), Mathf.Cos(rotation.x)),
            new MyVector3(0, 0, 0));

        Matrix4by4 yawMatrix = new Matrix4by4(new MyVector3(Mathf.Cos(rotation.y), 0, -Mathf.Sin(rotation.y)), new MyVector3(0, 1, 0), new MyVector3(Mathf.Sin(rotation.y), 0, Mathf.Cos(rotation.y)), new MyVector3(0, 0, 0));

        Matrix4by4 scaleMatrix = new Matrix4by4(MyVector3.ScaleVector(new MyVector3(1, 0, 0), scale.x), MyVector3.ScaleVector(new MyVector3(0, 1, 0), scale.y), MyVector3.ScaleVector(new MyVector3(0, 0, 1), scale.z), new MyVector3(0, 0, 0));

        Matrix4by4 translationMatrix = new Matrix4by4(
            new MyVector3(1, 0, 0),
            new MyVector3(0, 1, 0),
            new MyVector3(0, 0, 1),
            new MyVector3(position.x, position.y, position.z)
            );



        Matrix4by4 R = yawMatrix * (pitchMatrix * rollMatrix);
        Matrix4by4 M = translationMatrix * (R * scaleMatrix);

        for (int i = 0; i < transformedVertices.Length; i++)
        {
            //MyVector3 rolledVertex = MyVector4.ConvertToMyVector3(rollMatrix * MyVector3.ConvertToMyVector4(ModelSpaceVertices[i]));
            //MyVector3 pitchedVertex = MyVector4.ConvertToMyVector3(pitchMatrix * MyVector3.ConvertToMyVector4(rolledVertex));
            //MyVector3 yawedVertex = MyVector4.ConvertToMyVector3(yawMatrix * MyVector3.ConvertToMyVector4(pitchedVertex));
            //transformedVertices[i] = yawedVertex;

            //transformedVertices[i] = MyVector4.ConvertToMyVector3(scaleMatrix * MyVector3.ConvertToMyVector4(ModelSpaceVertices[i])); 
            ////transformedVertices[i] = MyVector4.ConvertToMyVector3(translationMatrix * MyVector3.ConvertToMyVector4(ModelSpaceVertices[i]));
            ///
            //transformedVertices[i] = MyVector4.ConvertToMyVector3(R * MyVector3.ConvertToMyVector4(ModelSpaceVertices[i]));
            transformedVertices[i] = MyVector4.ConvertToMyVector3(M * MyVector3.ConvertToMyVector4(ModelSpaceVertices[i]));
        }

       MeshFilter mf = GetComponent<MeshFilter>();

        mf.mesh.vertices = MyVector3.ConvertToVectorArray(transformedVertices); 


        mf.mesh.RecalculateNormals(); 
        mf.mesh.RecalculateBounds(); 
    }
}


