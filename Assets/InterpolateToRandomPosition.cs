using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterpolateToRandomPosition : MonoBehaviour
{
    MyVector3 targetPosition;
    MyVector3 currentPosition; 
    // Start is called before the first frame update
    void Start()
    {
        currentPosition = MyVector3.ConvertToMyVector3(transform.position);
        targetPosition = new MyVector3(currentPosition.x + 10, currentPosition.y, currentPosition.z);

    }

    // Update is called once per frame
    void Update()
    {
        InterpolateTo();
    }

    void InterpolateTo()
    {
        currentPosition = MyVector3.ConvertToMyVector3(transform.position);
      
        MyVector3 position = new MyVector3(Random.Range(-100, 100), Random.Range(-100, 100), Random.Range(-100, 100));
        
        MyVector3 interpolatedValue = MathsLib.InterpolateVector3(currentPosition, targetPosition, Time.deltaTime);

        transform.position = MyVector3.Convert(interpolatedValue); 
    }
}
