using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoTowards : MonoBehaviour
{
    public float speed; 
    GameObject otherGameObject;
    // Start is called before the first frame update
    void Start()
    {
        otherGameObject = GameObject.Find("Cylinder");
    }

    // Update is called once per frame
    void Update()
    {
        MyVector3 otherVector3 = new MyVector3(otherGameObject.transform.position.x, otherGameObject.transform.position.y, otherGameObject.transform.position.z);
        MyVector3 myVector3 = new MyVector3(transform.position.x, transform.position.y, transform.position.z);
        MyVector3 direction = MyVector3.Subtract(otherVector3, myVector3);
        float dotProduct = MyVector3.DotValue(direction, otherGameObject.GetComponent<RandomlyMove>().normalisedVector); 
        if(dotProduct > 0.5f)
        {
            MyVector3 normMyVector = direction.NormaliseVector();
            normMyVector = MyVector3.ScaleVector(normMyVector, speed * Time.deltaTime);
            transform.position += MyVector3.Convert(normMyVector);
        }
       
        //direction evader is moving
        //direction from pursuer to evader 
        //dot product from them 
    }
}
