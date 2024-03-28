using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyVector2 
{
    public float x;
    public float y;


    public MyVector2(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public static MyVector2 Add(MyVector2 vector1, MyVector2 vector2)
    {
        MyVector2 result = new MyVector2(0, 0);

        result.x = vector1.x + vector2.x;
        result.y = vector1.y + vector2.y;

        return result;
    }

    public static MyVector2 Subtract(MyVector2 vector1, MyVector2 vector2)
    {
        MyVector2 result = new MyVector2(0, 0);
        result.x = vector1.x - vector2.x;
        result.y = vector1.y - vector2.y;
        return result;
    }

    public static MyVector2 operator +(MyVector2 vector1, MyVector2 vector2)
    {
        return Add(vector1, vector2);
    }

    public float Magnitude()
    {
        float result;
        result = Mathf.Sqrt(x * x + y * y);
        return result;
    }

    public float MagnitudeSqrd()
    {
        float result = 0.0f;
        result = x * x + y * y;
        return result;
    }

    public static Vector2 Convert(MyVector2 vector2)
    {
        Vector2 newVector = new Vector3();
        newVector.x = vector2.x;
        newVector.y = vector2.y;
        return newVector;
    }

    public static MyVector2 ConvertToMyVector2(Vector2 vector2)
    {
        MyVector2 rv = new MyVector2(0, 0);
        rv.x = vector2.x;
        rv.y = vector2.y;
        return rv;
    }

    public static MyVector2 ScaleVector(MyVector2 v, float s) //s for scalar 
    {
        MyVector2 returnValue = new MyVector2(0, 0);

        returnValue.x = v.x * s;
        returnValue.y = v.y * s;

        return returnValue;
    }

    public static MyVector2 DivideVector(MyVector2 v, float d) //d for divisor
    {
        MyVector2 returnValue = new MyVector2(0, 0);

        returnValue.x = v.x / d;
        returnValue.y = v.y / d;

        return returnValue;
    }

    public MyVector2 NormaliseVector()
    {
        MyVector2 rv = new MyVector2(0, 0);
        rv = DivideVector(this, this.Magnitude());

        return rv;
    }

    public static float DotValue(MyVector2 v1, MyVector2 v2, bool shouldNormalise = true)
    {
        float rv = 0.0f;
        if (shouldNormalise == true)
        {
            MyVector2 normV1 = v1.NormaliseVector();
            MyVector2 normV2 = v2.NormaliseVector();
            rv = normV1.x * normV2.x + normV1.y * normV2.y;
        }
        else
        {
            rv = v1.x * v2.x + v1.y * v2.y;
        }

        return rv;
    }
}
