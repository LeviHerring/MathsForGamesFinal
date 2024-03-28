using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Rendering;

public class MathsLib
{
  public static float VectorToRadians(MyVector2 v)
    {
        float rv = 0.0f;

        rv = Mathf.Atan(v.y / v.x);

        return rv; 

    }

    public static MyVector2 RadiansToVector(float angle)
    {
        MyVector2 rv = new MyVector2(Mathf.Cos(angle), Mathf.Sin(angle));

        //rv.x = Mathf.Cos(angle);
        //rv.y = Mathf.Sin(angle); 

        return rv; 
    }

    public static MyVector3 EulerAnglesToDirection(MyVector3 Euler)
    {
        MyVector3 rv = new MyVector3(0, 0, 0); 
        rv.z = Mathf.Cos(Euler.y) * Mathf.Cos(-Euler.x);
        rv.y = Mathf.Sin(-Euler.x);
        rv.x = Mathf.Cos(-Euler.x) * Mathf.Sin(Euler.y);

        return rv; 
    }

    public static MyVector3 CrossProduct(MyVector3 v1, MyVector3 v2)
    {
        MyVector3 rv = new MyVector3(0, 0, 0); 

        rv.x = v1.y * v2.z - v1.z * v2.y;
        rv.y = v1.z * v2.x - v1.x * v2.z;
        rv.z = v1.x * v2.y - v1.y * v2.x;

        return rv; 
    }

    public static MyVector3 DegreesToRadians(MyVector3 degrees)
    {
        MyVector3 rv = new MyVector3(0, 0, 0);

        rv.x = degrees.x / (180/ Mathf.PI);
        rv.y = degrees.y / (180 / Mathf.PI);
        rv.z = degrees.z / (180 / Mathf.PI);

        return rv; 
    }

    //2. converting euler into direction
    //3. getting directiion  then using crossproducts for up vector 


    public static MyVector2 InterpolateVector2(MyVector2 a, MyVector2 b, float t)
    {
        MyVector2 c;

        c = MyVector2.ScaleVector(a, 1 - t) + MyVector2.ScaleVector(b, t); 
        return c;
    }

    public static MyVector3 InterpolateVector3(MyVector3 a, MyVector3 b, float t)
    {
        MyVector3 c;
        c = MyVector3.ScaleVector(a, 1 - t) + MyVector3.ScaleVector(b, t); 

        return c; 
    }

    public static MyVector3 RotateVertex(float angle, MyVector3 axis, MyVector3 vertex)
    {
        MyVector3 rv = new MyVector3(0, 0, 0);

        rv = (vertex * Mathf.Cos(angle)) + 
           axis * MyVector3.DotValue(vertex, axis) * (1.0f - Mathf.Cos(angle)) + 
            CrossProduct(axis, vertex) * Mathf.Sin(angle);


        return rv;
    }
}

public class Matrix4by4
{

    public float[,] values;

    public static Matrix4by4 identity
    {
        get
        {
            return new Matrix4by4(
                new MyVector4(1, 0, 0, 0),
                new MyVector4(0, 1, 0, 0),
                new MyVector4(0, 0, 1, 0),
                new MyVector4(0, 0, 0, 1)); 
        }
    }
    public Matrix4by4(MyVector4 column1, MyVector4 column2, MyVector4 column3, MyVector4 column4)
    {
        values = new float[4, 4];

        values[0, 0] = column1.x;
        values[1, 0] = column1.y;
        values[2, 0] = column1.z;
        values[3, 0] = column1.w;

        values[0, 1] = column2.x;
        values[1, 1] = column2.y;
        values[2, 1] = column2.z;
        values[3, 1] = column2.w;

        values[0, 2] = column3.x;
        values[1, 2] = column3.y;
        values[2, 2] = column3.z;
        values[3, 2] = column3.w;

        values[0, 3] = column4.x;
        values[1, 3] = column4.y;
        values[2, 3] = column4.z;
        values[3, 3] = column4.w;

    }

    public Matrix4by4(MyVector3 column1, MyVector3 column2, MyVector3 column3, MyVector3 column4)
    {
        values = new float[4, 4]; 

        values[0, 0] = column1.x;
        values[1, 0] = column1.y;
        values[2, 0] = column1.z;
        values[3, 0] = 0;

        values[0, 1] = column2.x;
        values[1, 1] = column2.y;
        values[2, 1] = column2.z;
        values[3, 1] = 0;

        values[0, 2] = column3.x;
        values[1, 2] = column3.y;
        values[2, 2] = column3.z;
        values[3, 2] = 0;

        values[0, 3] = column4.x;
        values[1, 3] = column4.y;
        values[2, 3] = column4.z;
        values[3, 3] = 1;
    }

    public static MyVector4 operator *(Matrix4by4 lhs, MyVector4 rhs)
    {
        MyVector4 rv = new MyVector4(0,0,0,0);

        rv.x = (lhs.values[0, 0] * rhs.x) + (lhs.values[0, 1] * rhs.y) + (lhs.values[0, 2] * rhs.z) + (lhs.values[0, 3] * rhs.w);
        rv.y = (lhs.values[1, 0] * rhs.x) + (lhs.values[1, 1] * rhs.y) + (lhs.values[1, 2] * rhs.z) + (lhs.values[1, 3] * rhs.w);
        rv.z = (lhs.values[2, 0] * rhs.x) + (lhs.values[2, 1] * rhs.y) + (lhs.values[2, 2] * rhs.z) + (lhs.values[2, 3] * rhs.w);
        rv.w = (lhs.values[3, 0] * rhs.x) + (lhs.values[3, 1] * rhs.y) + (lhs.values[3, 2] * rhs.z) + (lhs.values[3, 3] * rhs.w);

        return rv;
    }

    public static Matrix4by4 operator *(Matrix4by4 lhs, Matrix4by4 rhs)
    {

        Matrix4by4 rv = new Matrix4by4(new MyVector4(0, 0, 0, 0), new MyVector4(0, 0, 0, 0), new MyVector4(0, 0, 0, 0), new MyVector4(0, 0, 0, 0));

        rv.values[0, 0] = (lhs.values[0,0] * rhs.values[0,0]) + (lhs.values[0, 1] * rhs.values[1, 0]) + (lhs.values[0, 2] * rhs.values[2, 0]) + (lhs.values[0, 3] * rhs.values[3, 0]);
        rv.values[1, 0] = (lhs.values[1,0] * rhs.values[0,0]) + (lhs.values[1, 1] * rhs.values[1, 0]) + (lhs.values[1, 2] * rhs.values[2, 0]) + (lhs.values[1, 3] * rhs.values[3, 0]);
        rv.values[2, 0] = (lhs.values[2,0] * rhs.values[0,0]) + (lhs.values[2, 1] * rhs.values[1, 0]) + (lhs.values[2, 2] * rhs.values[2, 0]) + (lhs.values[2, 3] * rhs.values[3, 0]);
        rv.values[3, 0] = (lhs.values[3,0] * rhs.values[0,0]) + (lhs.values[3, 1] * rhs.values[1, 0]) + (lhs.values[3, 2] * rhs.values[2, 0]) + (lhs.values[3, 3] * rhs.values[3, 0]);

        rv.values[0, 1] = (lhs.values[0, 0] * rhs.values[0, 1]) + (lhs.values[0, 1] * rhs.values[1, 1]) + (lhs.values[0, 2] * rhs.values[2, 1]) + (lhs.values[0, 3] * rhs.values[3, 1]);
        rv.values[1, 1] = (lhs.values[1, 0] * rhs.values[0, 1]) + (lhs.values[1, 1] * rhs.values[1, 1]) + (lhs.values[1, 2] * rhs.values[2, 1]) + (lhs.values[1, 3] * rhs.values[3, 1]);
        rv.values[2, 1] = (lhs.values[2, 0] * rhs.values[0, 1]) + (lhs.values[2, 1] * rhs.values[1, 1]) + (lhs.values[2, 2] * rhs.values[2, 1]) + (lhs.values[2, 3] * rhs.values[3, 1]);
        rv.values[3, 1] = (lhs.values[3, 0] * rhs.values[0, 1]) + (lhs.values[3, 1] * rhs.values[1, 1]) + (lhs.values[3, 2] * rhs.values[2, 1]) + (lhs.values[3, 3] * rhs.values[3, 1]);

        rv.values[0, 2] = (lhs.values[0, 0] * rhs.values[0, 2]) + (lhs.values[0, 1] * rhs.values[1, 2]) + (lhs.values[0, 2] * rhs.values[2, 2]) + (lhs.values[0, 3] * rhs.values[3, 2]);
        rv.values[1, 2] = (lhs.values[1, 0] * rhs.values[0, 2]) + (lhs.values[1, 1] * rhs.values[1, 2]) + (lhs.values[1, 2] * rhs.values[2, 2]) + (lhs.values[1, 3] * rhs.values[3, 2]);
        rv.values[2, 2] = (lhs.values[2, 0] * rhs.values[0, 2]) + (lhs.values[2, 1] * rhs.values[1, 2]) + (lhs.values[2, 2] * rhs.values[2, 2]) + (lhs.values[2, 3] * rhs.values[3, 2]);
        rv.values[3, 2] = (lhs.values[3, 0] * rhs.values[0, 2]) + (lhs.values[3, 1] * rhs.values[1, 2]) + (lhs.values[3, 2] * rhs.values[2, 2]) + (lhs.values[3, 3] * rhs.values[3, 2]);

        rv.values[0, 3] = (lhs.values[0, 0] * rhs.values[0, 3]) + (lhs.values[0, 1] * rhs.values[1, 3]) + (lhs.values[0, 2] * rhs.values[2, 3]) + (lhs.values[0, 3] * rhs.values[3, 3]);
        rv.values[1, 3] = (lhs.values[1, 0] * rhs.values[0, 3]) + (lhs.values[1, 1] * rhs.values[1, 3]) + (lhs.values[1, 2] * rhs.values[2, 3]) + (lhs.values[1, 3] * rhs.values[3, 3]);
        rv.values[2, 3] = (lhs.values[2, 0] * rhs.values[0, 3]) + (lhs.values[2, 1] * rhs.values[1, 3]) + (lhs.values[2, 2] * rhs.values[2, 3]) + (lhs.values[2, 3] * rhs.values[3, 3]);
        rv.values[3, 3] = (lhs.values[3, 0] * rhs.values[0, 3]) + (lhs.values[3, 1] * rhs.values[1, 3]) + (lhs.values[3, 2] * rhs.values[2, 3]) + (lhs.values[3, 3] * rhs.values[3, 3]);

        return rv; 
    }

    public Matrix4by4 TranslationInverse()
    {
        Matrix4by4 rv = new Matrix4by4(new MyVector4(0, 0, 0, 0), new MyVector4(0, 0, 0, 0), new MyVector4(0, 0, 0, 0), new MyVector4(0, 0, 0, 0));
        rv.values[0, 3] = -values[0, 3];
        rv.values[1, 3] = -values[1, 3];
        rv.values[2, 3] = -values[2, 3];

        return rv; 
    }

    public Matrix4by4 ScaleInverse()
    {
        Matrix4by4 rv = identity;

        rv.values[0,0] = 1.0f / values[0,0];
        rv.values[1,1] = 1.0f / values[1,1];
        rv.values[2,2] = 1.0f / values[2,2];

        return rv; 
    }

   public Matrix4by4 RotationInverse()
    {
        return new Matrix4by4(GetRow(0), GetRow(1), GetRow(2), GetRow(3)); 
    }

    public static MyVector4 GetRow(int row)
    {
        MyVector4 rv = new MyVector4(0, 0, 0, 0);
        rv.x = Matrix4by4.identity.values[0, row];
        rv.y = Matrix4by4.identity.values[1, row];
        rv.z = Matrix4by4.identity.values[2, row];
        rv.w = Matrix4by4.identity.values[3, row];

        return rv; 
    }
   


}

public class AABB
{
    public AABB(MyVector3 min, MyVector3 max)
    {
        minExtent = min;
        maxExtent = max;
    }

    MyVector3 minExtent;
    MyVector3 maxExtent;


    public float Top
    {
        get { return maxExtent.y; }
    }

    public float Bottom
    {
        get { return minExtent.y; }
    }

    public float Left
    {
        get { return minExtent.x; }
    }

    public float Right
    {
        get { return maxExtent.x; }
    }

    public float Front
    {
        get { return maxExtent.z; }
    }

    public float Back
    {
        get { return minExtent.z; }
    }

    public static bool Intersects(AABB box1, AABB box2)
    {
        return !(box2.Left > box1.Right
            || box2.Right < box1.Left
            || box2.Top < box1.Bottom
            || box2.Bottom > box1.Top
            || box2.Back > box1.Front
            || box2.Front < box1.Back);
    }

    public static bool LineIntersection(AABB box, MyVector3 startPoint, MyVector3 endPoint, out MyVector3 intersectionPoint)
    {
        float lowest = 0.0f;
        float highest = 1.0f;

        intersectionPoint = new MyVector3(0, 0, 0);

        if (!IntersectingAxis(new MyVector3(1, 0, 0), box, startPoint, endPoint, ref lowest, ref highest))
            return false;

        if (!IntersectingAxis(new MyVector3(0, 1, 0), box, startPoint, endPoint, ref lowest, ref highest))
            return false;

        if (!IntersectingAxis(new MyVector3(0, 0, 1), box, startPoint, endPoint, ref lowest, ref highest))
            return false;


        intersectionPoint = MyVector3.ConvertToMyVector3(Vector3.Lerp(MyVector3.Convert(startPoint), MyVector3.Convert(endPoint), lowest));

        return true;

    }

    public static bool IntersectingAxis(MyVector3 axis, AABB box, MyVector3 startPoint, MyVector3 endPoint, ref float lowest, ref float highest)
    {
        float minimum = 0.0f, maximum = 1.0f;
        if (axis == new MyVector3(1, 0, 0))
        {
            minimum = (box.Left - startPoint.x) / (endPoint.x - startPoint.x);
            maximum = (box.Right - startPoint.x) / (endPoint.x - startPoint.x);
        }
        else if (axis == new MyVector3(0, 1, 0))
        {
            minimum = (box.Bottom - startPoint.y) / (endPoint.y - startPoint.y);
            maximum = (box.Front - startPoint.y) / (endPoint.y - startPoint.y);
        }
        else if (axis == new MyVector3(0, 0, 1))
        {
            minimum = (box.Back - startPoint.z) / (endPoint.z - startPoint.z);
            maximum = (box.Front - startPoint.z) / (endPoint.z - startPoint.z);
        }

        if (maximum < minimum)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
        }

        if (maximum < lowest)
            return false;
        if (maximum > highest)
            return false;

        lowest = Mathf.Max(minimum, lowest);
        highest = Mathf.Min(highest, highest);

        if (lowest > highest)
            return false;

        return true;


    }


}

public class Quat
{
    public float w;
    public MyVector3 v; 

    public Quat()
    {
        w = 0.0f;
        v = new MyVector3(0, 0, 0); 
    }
    public Quat(float angle, MyVector3 axis)
    {
        float halfAngle = angle / 2;
        w = Mathf.Cos(halfAngle);

        v = axis * Mathf.Sin(halfAngle); 
    }

    public Quat(MyVector3 position)
    {
        w = 0.0f;
       v = new MyVector3(position.x, position.y, position.z); 
    }

    public static Quat operator *(Quat lhs, Quat rhs)
    {
        Quat rv = new Quat();
        rv.w = ((lhs.w * rhs.w) - MyVector3.DotValue(lhs.v, rhs.v));
        rv.v = rhs.v * lhs.w + lhs.v * rhs.w + MathsLib.CrossProduct(rhs.v, lhs.v);
        //rv = ((lhs.w * rhs.w) - MyVector3.DotValue(lhs.v, rhs.v),  rhs.v * lhs.w + lhs.v * rhs.w + MathsLib.CrossProduct(rhs.v, lhs.v));

        return rv; 
    }

    public Quat Inverse()
    {
        Quat rv = new Quat();

        rv.w = w;

        rv.SetAxis(-GetAxis());

        return rv; 
    }

    public MyVector3 SetAxis(MyVector3 axis)
    {
        MyVector3 rv = new MyVector3(0, 0, 0);

        rv = axis; 

        return rv; 
    }

    public MyVector3 GetAxis()
    {
        MyVector3 rv = new MyVector3(0, 0, 0);

        rv = v; 

        return rv; 
    }

    public MyVector4 GetAxisAngle()
    {
        MyVector4 rv = new MyVector4(0,0,0,0);

        float halfAngle = Mathf.Cos(w);
        rv.w = halfAngle *2;

        rv.x = v.x / Mathf.Sin(halfAngle);
        rv.y = v.y / Mathf.Sin (halfAngle);
        rv.z = v.z / Mathf.Sin (halfAngle);

        return rv; 
    }

    public static Quat SLERP(Quat q, Quat r, float t)
    {
        t = Mathf.Clamp(t, 0.0f, 1.0f);
        Quat d = r * q.Inverse();
        MyVector4 AxisAngle = d.GetAxisAngle();
        Quat dT = new Quat(AxisAngle.w * t, new MyVector3(AxisAngle.x, AxisAngle.y, AxisAngle.z));

        return dT * q; 
    }

    
}
