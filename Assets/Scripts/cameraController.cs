using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform playerTransform;
    public float smoothSpeed = 0.125f;
    public Vector3 locationOffset;

    void Start()
    {
        transform.position = playerTransform.position + locationOffset;
    }

    void FixedUpdate()
    {
        Vector3 targetPosition = playerTransform.position + locationOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
