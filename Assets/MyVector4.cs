using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyVector4
{
    public float x;
    public float y;
    public float z;
    public float w;


    public MyVector4(float x, float y, float z, float w)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.w = w; 
    }

    public static MyVector4 Add(MyVector4 vector1, MyVector4 vector2)
    {
        MyVector4 result = new MyVector4(0, 0, 0, 0);

        result.x = vector1.x + vector2.x;
        result.y = vector1.y + vector2.y;
        result.z = vector1.z + vector2.z;
        result.w = vector1.w + vector2.w; 

        return result;
    }

    public static MyVector4 Subtract(MyVector4 vector1, MyVector4 vector2)
    {
        MyVector4 result = new MyVector4(0, 0, 0, 0);
        result.x = vector1.x - vector2.x;
        result.y = vector1.y - vector2.y;
        result.z = vector1.z - vector2.z;
        result.w = vector1.w - vector2.w;
        return result;
    }

    public static MyVector4 operator +(MyVector4 vector1, MyVector4 vector2)
    {
        return Add(vector1, vector2);
    }

    public float Magnitude()
    {
        float result;
        result = Mathf.Sqrt(x * x + y * y + z * z + w * w);
        return result;
    }

    public float MagnitudeSqrd()
    {
        float result = 0.0f;
        result = x * x + y * y + z * z + w * w;
        return result;
    }

    public static Vector4 Convert(MyVector4 vector4)
    {
        Vector4 newVector = new Vector4();
        newVector.x = vector4.x;
        newVector.y = vector4.y;
        newVector.z = vector4.z;
        newVector.w = vector4.w;
        return newVector;
    }

    public static MyVector4 ConvertToMyVector4(Vector4 vector4)
    {
        MyVector4 rv = new MyVector4(0, 0, 0, 0);
        rv.x = vector4.x;
        rv.y = vector4.y;
        rv.z = vector4.z;
        rv.w = vector4.w;
        return rv;
    }

    public static MyVector4 ScaleVector(MyVector4 v, float s) //s for scalar 
    {
        MyVector4 returnValue = new MyVector4(0, 0, 0, 0);

        returnValue.x = v.x * s;
        returnValue.y = v.y * s;
        returnValue.z = v.z * s;
        returnValue.w = v.w * s;

        return returnValue;
    }

    public static MyVector4 DivideVector(MyVector4 v, float d) //d for divisor
    {
        MyVector4 returnValue = new MyVector4(0, 0, 0, 0);

        returnValue.x = v.x / d;
        returnValue.y = v.y / d;
        returnValue.z = v.z / d;
        returnValue.w = v.w / d; 

        return returnValue;
    }

    public MyVector4 NormaliseVector()
    {
        MyVector4 rv = new MyVector4(0, 0, 0, 0);
        rv = DivideVector(this, this.Magnitude());

        return rv;
    }

    public static float DotValue(MyVector4 v1, MyVector4 v2, bool shouldNormalise = true)
    {
        float rv = 0.0f;
        if (shouldNormalise == true)
        {
            MyVector4 normV1 = v1.NormaliseVector();
            MyVector4 normV2 = v2.NormaliseVector();
            rv = normV1.x * normV2.x + normV1.y * normV2.y + normV1.z * normV2.z + normV1.w * normV2.w;
        }
        else
        {
            rv = v1.x * v2.x + v1.y * v2.y + v1.z * v2.z + v1.w * v2.w;
        }

        return rv;
    }

    public static MyVector3 ConvertToMyVector3(MyVector4 vector4)
    {
        MyVector3 rv = new MyVector3(0, 0, 0);
        rv.x = vector4.x;
        rv.y = vector4.y;   
        rv.z = vector4.z;

        return rv; 
    }
}
