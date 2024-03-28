using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoAABB : MonoBehaviour
{
    public MyVector3 minExtent;
    public MyVector3 maxExtent;
    TransformMatrixObject transformObject; 

    private void Start()
    {
     transformObject =  GetComponent<TransformMatrixObject>(); 
    }
    public float Top
    {
        get
        {
            return maxExtent.y + transformObject.position.y;
        }
    }

    public float Bottom
    {
        get
        {
            return minExtent.y + transformObject.position.y;
        }
    }

    public float Right
    {
        get
        {
            return maxExtent.x + transformObject.position.x;
        }
    }

    public float Left
    {
        get
        {
            return minExtent.x + transformObject.position.x;
        }
    }
    public float Front
    {
        get
        {
            return maxExtent.z + transformObject.position.z;
        }
    }

    public float Back
    {
        get
        {
            return minExtent.z + transformObject.position.z;
        }
    }


    public static bool Intersects(MonoAABB box1, MonoAABB box2)
    {
        return !(box2.Left > box1.Right
            || box2.Right < box1.Left
            || box2.Top < box1.Bottom
            || box2.Bottom > box1.Top
            || box2.Back > box1.Front
            || box2.Front < box1.Back);
    }

    private void Update()
    {

        MonoAABB[] boxes = FindObjectsOfType<MonoAABB>();

        foreach (MonoAABB box in boxes)
        {
            if (box != this)
            {
                if (Intersects(this, box))
                {
                    Debug.Log(gameObject.name + "Is intersecting with " + box.gameObject.name);
                }
            }
        }

    }

}
