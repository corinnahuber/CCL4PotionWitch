using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour
{
    public string sceneToLoad;
    public WitchHouseTrigger houseController;
    public float doorOpenDelay = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (houseController != null)
            {
                houseController.OpenDoor();
            }
            StartCoroutine(SwitchSceneAfterDelay());
        }
    }

    private IEnumerator SwitchSceneAfterDelay()
    {
        yield return new WaitForSeconds(doorOpenDelay);
        WorldSceneManager.Instance.LoadScene(sceneToLoad);
    }
}