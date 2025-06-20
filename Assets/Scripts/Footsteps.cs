using UnityEngine;

public class FootstepAudio : MonoBehaviour
{
    public AK.Wwise.Event footstepEvent;
    public float stepInterval = 0.5f;

    private CharacterController controller;
    private float stepTimer = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller != null && controller.isGrounded && controller.velocity.magnitude > 0.1f)
        {
            stepTimer -= Time.deltaTime;
            if (stepTimer <= 0f)
            {
                footstepEvent.Post(gameObject);
                stepTimer = stepInterval;
            }
        }
        else
        {
            stepTimer = 0f;
        }
    }
}
