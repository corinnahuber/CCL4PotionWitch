using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement: MonoBehaviour
{
    
    public Transform target;
    public Vector3 offset;
    public float followSpeed;
    public float rotationSpeed;

    void Update()
    {
        // Desired camera position (behind and above the player)
        Vector3 desiredPosition = target.position + target.rotation * offset;

      
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
    }
}

