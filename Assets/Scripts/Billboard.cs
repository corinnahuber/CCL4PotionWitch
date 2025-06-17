using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{

    public Camera mainCamera;


    void LateUpdate()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        // Make the object face the camera
        transform.LookAt(transform.position + mainCamera.transform.forward);
    }
}

