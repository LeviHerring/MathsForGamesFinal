using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] string name; 
    GameObject otherGameObject; 
    // Start is called before the first frame update
    void Start()
    {
        otherGameObject = GameObject.Find(name); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            MyVector3 otherVector3 = new MyVector3(otherGameObject.transform.position.x, otherGameObject.transform.position.y, otherGameObject.transform.position.z); 
            MyVector3 myVector3 = new MyVector3(transform.position.x, transform.position.y, transform.position.z);
            MyVector3 direction = MyVector3.Subtract(otherVector3, myVector3);
            myVector3 = MyVector3.Add(myVector3, direction);
            transform.position = MyVector3.Convert(myVector3); 
            
        }


    }
}
