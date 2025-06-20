using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{

    private static GameObject[] persistentObjects = new GameObject[5];
    public int objectIndex;

    private void Awake()
    {
        if (persistentObjects[objectIndex] == null)
        {
            persistentObjects[objectIndex] = gameObject; // Store the reference to this GameObject
            DontDestroyOnLoad(gameObject); // Prevent this GameObject from being destroyed when loading a new scene
        }
        else if (persistentObjects[objectIndex] != gameObject)
        {
            Destroy(gameObject); // Destroy this GameObject if another instance already exists
        }

    }
}
