using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public List<Image> heartIcons = new List<Image>();
    public List<Image> allHeartIcons = new List<Image>();

    public static PotionEffects effects;
    public float movementPerSecond = 4f;
    public float rotationSpeed = 80f;
    public float zoomSpeed = 20f;

    [SerializeField] Transform mainCamera;

    [SerializeField] float minZoom = 3f;
    [SerializeField] float maxZoom = 16f;



    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * movementPerSecond;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * Time.deltaTime * movementPerSecond;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += Vector3.up * Time.deltaTime * movementPerSecond;
        }



        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            //here the zoom needs to follow the camera orientation not the player or the zoom goes wrong
            Vector3 zoomDirection = mainCamera.transform.forward * scroll * Time.deltaTime * zoomSpeed;
            Vector3 newCamPos = mainCamera.position + zoomDirection;

            float distance = Vector3.Distance(transform.position, newCamPos);
            if (distance >= minZoom && distance <= maxZoom)
            {
                mainCamera.position = newCamPos;
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Rotate the camera around the player but not the player around the camera
            mainCamera.transform.RotateAround(transform.position, transform.up, rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Rotate the camera around the player but not the player around the camera
            mainCamera.transform.RotateAround(transform.position, transform.up, -rotationSpeed * Time.deltaTime);
        }

    }


    void OnMouseDown()
    {
        effects.PotionOnPlayer();
    }
    
}



 