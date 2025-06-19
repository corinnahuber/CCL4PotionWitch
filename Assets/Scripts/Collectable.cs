using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    [SerializeField]
    ItemData itemData; // Reference to the item data scriptable object 

    [SerializeField]
    int respawnTime = 10; // Time in seconds before the item respawns

    [SerializeField]
    bool playerInRange = false;


    void Update()
    {
        if (playerInRange && Input.GetKey(KeyCode.E) || playerInRange && Input.GetMouseButtonDown(0))
        {
            Debug.Log($"key pressed: {Input.inputString}");
            bool added = Inventory.instance.AddItem(itemData);
            if (added)
            {
                gameObject.SetActive(false); 
                //StartCoroutine(RespawnAfterDelay());

            }
            else
            {
                Debug.Log("Inventory full for this item. Cannot collect.");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
    

    IEnumerator RespawnAfterDelay()
    {
        yield return new WaitForSeconds(respawnTime);
        gameObject.SetActive(true); 
    }

}


