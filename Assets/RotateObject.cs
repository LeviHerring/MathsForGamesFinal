using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    MyVector3 direction;
    Vector3 vector3Direction;
    public float speed;
    MyVector3 rightDirection;
    Vector3 vector3RightDirection; 
    MyVector3 up; 
    private void Update()
    {
        GetDirection();
        Rotate();
        Move();
       
    }

    void Rotate()
    {
        if(Input.GetKey(KeyCode.W)) 
        {

            transform.eulerAngles += new Vector3(1, 0, 0); 
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles -= new Vector3(0, 1, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.eulerAngles -= new Vector3(1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles += new Vector3(0, 1, 0);
        }
    }

    void Move()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += vector3Direction; 
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= vector3Direction;
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += vector3RightDirection;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= vector3RightDirection;
        }
    }

    void GetDirection()
    {
        up = MyVector3.ConvertToMyVector3(Vector3.up); 
        direction = MathsLib.DegreesToRadians(MyVector3.ConvertToMyVector3(transform.eulerAngles));
        direction = MathsLib.EulerAnglesToDirection(direction);
        MyVector3 normDir = direction.NormaliseVector();
        normDir = MyVector3.ScaleVector(normDir, speed * Time.deltaTime); 
        vector3Direction = MyVector3.Convert(normDir);
        rightDirection = MathsLib.CrossProduct(up, normDir); 
        vector3RightDirection = MyVector3.Convert(rightDirection);  
    }
}
