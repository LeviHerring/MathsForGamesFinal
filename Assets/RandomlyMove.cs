using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;

public class RandomlyMove : MonoBehaviour
{
    public MyVector3 normalisedVector = new MyVector3(0,0,0);
    public float speed; 
    bool canRepeat = true; 
    public float scale = 1f; 
    // Start is called before the first frame update
    void Start()
    {
        canRepeat = true;
        InvokeRepeating("RandomMoveFunction", 1f, 1f); 
    }

    // Update is called once per frame
    void RandomMoveFunction()
    {
        //if (canRepeat == true)
        //{
        //    StartCoroutine(RandomMove());
        //}
        MyVector3 myVector = new MyVector3(Random.Range(-500, 500), Random.Range(-500, 500), Random.Range(-500, 500));
        normalisedVector = myVector.NormaliseVector();
        //times it by a speed and time.deltatime
        normalisedVector = MyVector3.ScaleVector(normalisedVector, speed * Time.deltaTime); 
        MyVector3 position = MyVector3.ConvertToMyVector3(transform.position);
        //MyVector3 direction = MyVector3.Subtract(myVector, position);
        //MyVector3 normMyVector = direction.NormaliseVector();
        //normMyVector = MyVector3.ScaleVector(normMyVector, scale);
        

    }

    private void Update()
    {
        transform.position += MyVector3.Convert(normalisedVector);
    }

    //IEnumerator RandomMove()
    //{
    //canRepeat = false;
    //int num = Random.Range(0, 1);
    //Debug.Log(num);
    //if(num == 0)
    //{
    //MyVector3 myVector = new MyVector3(Random.Range(-500, 500), Random.Range(-500, 500), Random.Range(-500, 500));
    //MyVector3 position = MyVector3.ConvertToMyVector3(transform.position);
    //MyVector3 direction = MyVector3.Subtract(myVector, position);
    //MyVector3 normMyVector = direction.NormaliseVector();
    //normMyVector = MyVector3.ScaleVector(normMyVector, scale);
    //transform.position += MyVector3.Convert(normMyVector);
    //}
    //yield return new WaitForSeconds(5f); 
    //canRepeat  = true; 
    //}
}
