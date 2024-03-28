using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool isClose; 
    public TransformMatrixObject box; 
    TransformMatrixObject pTransform;
    MyVector3 forward;
    MyVector3 direction;
    float speed = 1.0f; 

    // Start is called before the first frame update
    void Start()
    {
        pTransform = GetComponent<TransformMatrixObject>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Direction();
        Move();
        Mouse(); 
    }

    void Direction()
    {
        forward = MyVector3.ConvertToMyVector3(Vector3.forward);
        direction = MathsLib.DegreesToRadians(pTransform.rotation);
        direction = MathsLib.EulerAnglesToDirection(direction);
        MyVector3 normDir = direction.NormaliseVector();
        normDir = MyVector3.ScaleVector(normDir, speed * Time.deltaTime);
        direction = normDir;
        //rightDirection = MathsLib.CrossProduct(up, normDir);
        //vector3RightDirection = MyVector3.Convert(rightDirection);

    }

    void Move()
    {
        if(Input.GetKey(KeyCode.W))
        {
            pTransform.position += direction;
        }
    }

    void Mouse()
    {
        if (Input.GetAxis("Mouse X") < 0)
        {
           pTransform.rotation.y = Input.GetAxis("Mouse X"); 
        }
        if (Input.GetAxis("Mouse X") > 0)
        {
            pTransform.rotation.y = Input.GetAxis("Mouse X");
        }
    }

    void DistanceFromBox()
    {
        
    }
}
