using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;

    public List<Image> heartIcons = new List<Image>();
    public List<Image> allHeartIcons = new List<Image>();

    public static PotionEffects effects;
    public float movementPerSecond = 4f;
    public float rotationSpeed = 80f;
    public float zoomSpeed = 20f;

    [SerializeField] Transform mainCamera;

    [SerializeField] float minZoom = 3f;
    [SerializeField] float maxZoom = 16f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float groundCheckDistance = 0.1f;

    private bool isJumping = false;
    private bool isGrounded = false;


    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component missing from player!");
        }
    }

    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
        bool isWalking = false;

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * movementPerSecond * Time.deltaTime;
            isWalking = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * movementPerSecond * Time.deltaTime;
            isWalking = true;
        }

        if (Input.GetKey(KeyCode.A))
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJumping = true;
            animator.SetBool("Jumping", true);
            // Add upward force for jump if you want physics jump:
            rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }

        if (isJumping && isGrounded)
        {
            isJumping = false;
            animator.SetBool("Jumping", false);
        }

        animator.SetBool("Walking", isWalking);
        animator.SetBool("Idle", !isWalking && !isJumping);

        Debug.Log($"Walking: {isWalking}, Jumping: {isJumping}, Idle: {!isWalking && !isJumping}");



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
    
    
     private void OnCollisionEnter(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isGrounded = true;
            isJumping = false;
            animator.SetBool("Jumping", false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isGrounded = false;
        }
    }
}



 