using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookToggle : MonoBehaviour
{
    //different way of doing the same toggle as the InventoryToggle script

    public static BookToggle bookToggleInstance = null;
    [SerializeField]
    private GameObject bookUI;
    public bool isOpen = false;


    void Awake()
    {
        if (bookToggleInstance == null)
        {
            bookToggleInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (bookToggleInstance != this)
        {
            Destroy(gameObject); // Prevent duplicate
            return;
        }


    }

    private void Start()
    {
        if (bookUI != null)
        {
            bookUI.SetActive(isOpen); // Ensure the book UI is initially hidden
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (bookUI != null)
            {
                isOpen = !isOpen;
                bookUI.SetActive(isOpen);
            }
        }
    }
}

