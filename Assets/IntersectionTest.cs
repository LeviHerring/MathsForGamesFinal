using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {



        AABB thebox = new AABB(new MyVector3(0, 0, 0), new MyVector3(3, 3, 3));

        MyVector3 lineStart = new MyVector3(-2, -2, -2);
        MyVector3 lineEnd = new MyVector3(3, 4, 5);

        MyVector3 i;
        if (AABB.LineIntersection(thebox, lineStart, lineEnd, out i))
        {
            Debug.Log("Intersecting! Intersection Point: " + i);
        }
        else
        {
            Debug.Log("Did not intersect! i is unitialised, so don't do anything with it!");
        }

        //AABB theBox = new AABB(new MyVector3(0, 0, 0), new MyVector3(3, 3, 3));
        //MyVector3 globalStart = new MyVector3(-2, -2, -2);
        //MyVector3 globalEnd = new MyVector3(3, 4, 5);

        

    }

    void TransformStuff()
    {



    }
}
