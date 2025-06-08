using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float movementPerSecond = 4f;
    public float rotationSpeed = 80f;
    public float zoomSpeed = 20f;

    [SerializeField] Transform mainCamera;

    [SerializeField] float minZoom = 3f;
    [SerializeField] float maxZoom = 16f;

    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference cameraMovement;

    /*
    void OnEnable()
    {
        // Ensure the input actions are enabled when the script is enabled
        moveAction.action.Enable();
        cameraMovement.action.Enable();
    }

    void OnDisable()
    {
        // Disable the input actions when the script is disabled
        moveAction.action.Disable();
        cameraMovement.action.Disable();
    }

    void Update()
    {
        HandleMovement();
        HandleCameraMovement();
    }


    void HandleMovement()
    {
        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y).normalized;

        if (moveDirection.magnitude > 0)
        {
            transform.position += moveDirection * movementPerSecond * Time.deltaTime;
        }

        if (moveInput.x != 0)
        {
            float rotation = moveInput.x * rotationSpeed * Time.deltaTime;
            transform.Rotate(0, rotation, 0);
        }
    }
    

    void HandleCameraMovement()
    {
        Vector2 cameraInput = cameraMovement.action.ReadValue<Vector2>();
        Vector3 zoomDirection = mainCamera.transform.forward * cameraInput.y * zoomSpeed * Time.deltaTime;
        Vector3 newCamPos = mainCamera.position + zoomDirection;

        float distance = Vector3.Distance(transform.position, newCamPos);
        if (distance >= minZoom && distance <= maxZoom)
        {
            mainCamera.position = newCamPos;
        }

        if (cameraInput.x != 0)
        {
            mainCamera.RotateAround(transform.position, transform.up, cameraInput.x * rotationSpeed * Time.deltaTime);
        }
    }
}
*/


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
}

