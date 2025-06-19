using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraIntro : MonoBehaviour
{
    public Transform pivot; // Empty GameObject at center of spin
    public Camera introCam; // The camera that does the spin + drop
    public Camera gameplayCam; // Your regular gameplay camera
    public Transform finalCamPosition; // Where the intro cam should land

    public float spinDuration = 3f;
    public float moveSpeed = 2f;

    private float spinTimer = 0f;
    private bool spinning = true;
    private bool movingDown = false;

    private float totalRotation = 0f;

    void Start()
    {
        introCam.gameObject.SetActive(true);
        gameplayCam.gameObject.SetActive(false);
    }

    void Update()
    {
        if (spinning)
        {
            float rotationThisFrame = 360f / spinDuration * Time.deltaTime;
            pivot.Rotate(Vector3.up, rotationThisFrame);
            totalRotation += rotationThisFrame;
            spinTimer += Time.deltaTime;

            if (totalRotation >= 360f || spinTimer >= spinDuration)
            {
                spinning = false;
                movingDown = true;
            }
        }
        else if (movingDown)
        {
            // Move camera downward toward final position
            introCam.transform.position = Vector3.MoveTowards(
                introCam.transform.position,
                finalCamPosition.position,
                moveSpeed * Time.deltaTime
            );

            // Rotate toward final orientation smoothly
            introCam.transform.rotation = Quaternion.RotateTowards(
                introCam.transform.rotation,
                finalCamPosition.rotation,
                180f * Time.deltaTime
            );

            // When camera reaches destination
            if (Vector3.Distance(introCam.transform.position, finalCamPosition.position) < 0.05f)
            {
                introCam.gameObject.SetActive(false);
                gameplayCam.gameObject.SetActive(true);
                movingDown = false;
                Destroy(this); // Optional: remove script
            }
        }
    }
}
