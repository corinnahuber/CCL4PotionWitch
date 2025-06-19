using UnityEngine;

public class WitchHouseTrigger : MonoBehaviour
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        animator.SetTrigger("OpenDoor");
    }
}