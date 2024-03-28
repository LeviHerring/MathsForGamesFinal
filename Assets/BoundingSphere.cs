using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundingSphere : MonoBehaviour
{
    public MyVector3 centrePoint;
    public float radius = 1.0f;
    public TransformMatrixObject transformObject; 
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        centrePoint = transformObject.position;

        BoundingSphere[] allSpheresInScene = FindObjectsOfType<BoundingSphere>();
        
        foreach(BoundingSphere c in allSpheresInScene)
        {
            if(c != this)
            {
                if(Intersects(c))
                {
                    Debug.Log(gameObject.name + "Is intersecting with " + c.gameObject.name); 
                }
            }
        }
        

    }

    public bool Intersects(BoundingSphere otherSphere)
    {
        MyVector3 VectorToOtherSphere = MyVector3.Subtract(otherSphere.centrePoint, centrePoint);

        float CombinedRadiusSq = otherSphere.radius + radius;
        CombinedRadiusSq *= CombinedRadiusSq;

        return VectorToOtherSphere.MagnitudeSqrd() <= CombinedRadiusSq; 
    }
}
