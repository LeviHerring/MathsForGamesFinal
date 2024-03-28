using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class MyVector3
{
    public float x;
    public float y;
    public float z;


    public MyVector3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public static MyVector3 Add(MyVector3 vector1, MyVector3 vector2)
    {
        MyVector3 result = new MyVector3(0, 0, 0); 

        result.x = vector1.x + vector2.x;
        result.y = vector1.y + vector2.y;
        result.z = vector1.z + vector2.z;

        return result; 
    }

    public static MyVector3 Subtract(MyVector3 vector1, MyVector3 vector2)
    {
        MyVector3 result = new MyVector3(0,0,0);
        result.x = vector1.x - vector2.x;
        result.y = vector1.y - vector2.y;
        result.z = vector1.z - vector2.z;
        return result;
    }

    public static MyVector3 operator +(MyVector3 vector1, MyVector3 vector2)
    {
        return Add(vector1, vector2); 
    }

    public float Magnitude()
    {
        float result;
        result = Mathf.Sqrt(x * x + y * y + z * z);
        return result;
    }

    public float MagnitudeSqrd()
    {
        float result = 0.0f ;
        result = x * x + y * y + z * z;
        return result;
    }

    public static Vector3 Convert(MyVector3 vector3)
    {
        Vector3 newVector = new Vector3();
        newVector.x = vector3.x; 
        newVector.y = vector3.y;
        newVector.z = vector3.z;
        return newVector; 
    }

    public static MyVector3 ConvertToMyVector3(Vector3 vector3)
    {
        MyVector3 rv = new MyVector3(0,0,0);
        rv.x = vector3.x;
        rv.y = vector3.y;   
        rv.z = vector3.z;
        return rv; 
    }

    public static MyVector3 ScaleVector(MyVector3 v, float s) //s for scalar 
    {
        MyVector3 returnValue = new MyVector3(0, 0, 0);

        returnValue.x = v.x * s;
        returnValue.y = v.y * s;
        returnValue.z = v.z * s;

        return returnValue; 
    }

    public static MyVector3 DivideVector(MyVector3 v, float d) //d for divisor
    {
        MyVector3 returnValue = new MyVector3(0, 0, 0);

        returnValue.x = v.x /d;
        returnValue.y = v.y /d;
        returnValue.z = v.z /d;

        return returnValue;
    }

    public MyVector3 NormaliseVector()
    {
        MyVector3 rv = new MyVector3(0,0,0);
        rv = DivideVector(this, this.Magnitude()); 

        return rv; 
    }

    public static float DotValue(MyVector3 v1, MyVector3 v2, bool shouldNormalise = true)
    {
        float rv = 0.0f;
        if(shouldNormalise == true)
        {
            MyVector3 normV1 = v1.NormaliseVector(); 
            MyVector3 normV2 = v2.NormaliseVector();
            rv = normV1.x * normV2.x + normV1.y * normV2.y + normV1.z * normV2.z;
        }
        else
        {
            rv = v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
        }
       
        return rv; 
    }

    public static float threedDotValue(MyVector3 a, MyVector3 b, bool normalise = true)
    {
        if(normalise)
        {
            a.NormaliseVector(); 
            b.NormaliseVector();
        }
        return a.x * b.x + a.y * b.y + a.z * b.z; 
    }

    public static MyVector3[] ConvertToMyVector3(Vector3[] vector3)
    {
       MyVector3[] rv = new MyVector3[vector3.Length];

        for(int i = 0; i < vector3.Length; i++)
        {
            rv[i] = ConvertToMyVector3(vector3[i]); 
        }

        return rv; 
    }

    public static MyVector4 ConvertToMyVector4(MyVector3 vector3)
    {
        MyVector4 rv = new MyVector4(0, 0, 0, 0);

        rv.x = vector3.x; 
        rv.y = vector3.y;
        rv.z = vector3.z;
        rv.w = 1; 

        return rv; 
    }

    public static Vector3[] ConvertToVectorArray(MyVector3[] vector3)
    {
        Vector3[] rv = new Vector3[vector3.Length];

        for (int i = 0; i < vector3.Length; i++)
        {
            rv[i] = Convert(vector3[i]);
        }

        return rv;
    }

    public static MyVector3 operator *(MyVector3 v, float scalar)
    {
        return ScaleVector(v, scalar); 
    }

    public static MyVector3 operator -(MyVector3 v)
    {
        MyVector3 rv = new MyVector3(0, 0, 0);

        rv.x = v.x * -1; 
        rv.y = v.y * -1;
        rv.z = v.z * -1; 

        return rv;  
    }

}
