using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public TransformMatrixObject player;
    TransformMatrixObject cameraTransform;
    public MyVector3 offset;
    private void Start()
    {
        cameraTransform = GetComponent<TransformMatrixObject>();
    }

    private void Update()
    {
        cameraTransform.position = player.position + offset;
    }
}
