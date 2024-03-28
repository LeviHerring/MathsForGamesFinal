using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundingCapsule
{
    public MyVector3 A;
    public MyVector2 B;
    public float radius; 

    public BoundingCapsule(MyVector3 a, MyVector2 b, float radius)
    {
        this.A = a;
        this.B = b;
        this.radius = radius;
    }

    //public bool Intersects(BoundingSphere otherSphere)
    //{

    //}
}
