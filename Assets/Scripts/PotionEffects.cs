using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


public class PotionEffects : MonoBehaviour
{


    public static PotionEffects instance;

    public NavMeshAgent enemy;

    private float stunDuration = 3f;
    private Coroutine stunCoroutine;
    private int damage = 10;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }



    public void PotionOnEnemy()
    {

        if (PotionsInventoryUI.instance.selectedIndex >= 0)
        {
            // Get the selected potion data
            PotionData PotionSelected = PotionInventory.instance.potionsMade[PotionsInventoryUI.instance.selectedIndex];

            if (PotionSelected.potionType != PotionData.PotionType.Health &&
                PotionSelected.potionType != PotionData.PotionType.Speed)
            {

                switch (PotionSelected.potionType)
                {
                    case PotionData.PotionType.Damage:
                        //DealDamage(); // Deal damage to the enemy
                        Debug.Log("Potion of Damage used on enemy: " + enemy.name);
                        break;

                    case PotionData.PotionType.Destruction:
                        Debug.Log("Potion of Destruction used on enemy: " + enemy.name);
                        Destroy(enemy.gameObject);
                        break;


                    case PotionData.PotionType.Stun:
                        Debug.Log("Potion of Stun used on enemy: " + enemy.name);
                        /*
                        if (stunCoroutine != null) //in case we already used a stun potion on the enemy
                            StopCoroutine(stunCoroutine);

                        stunCoroutine = StartCoroutine(StunEnemy(enemy));*/
                        break;
                }

                PotionInventory.instance.RemovePotion(PotionSelected); // Remove the potion from inventory
                PotionsInventoryUI.instance.PotionInventoryUIUpdate(); // Update the UI
                PotionsInventoryUI.instance.selectedIndex = -1; // Reset the selected index
            }

        }

    }


    private IEnumerator StunEnemy(NavMeshAgent enemy)
    {
        if (enemy == null)
            yield break;

        enemy.enabled = false; // Disable the NavMeshAgent to stop movement

        yield return new WaitForSeconds(stunDuration);

        if (enemy != null)
            enemy.enabled = true;
    }


    public void DealDamage()
    {
       
        EnemyMovement.instance.enemyHealth -= damage; // Reduce enemy health by damage amount
        EnemyBar.instance.EnemyHealth(EnemyMovement.instance.enemyHealth); 

        if (EnemyBar.instance.slider.value == 0)
        {
            Destroy(enemy); 
        }
    }
}

// Uncomment the following code if you want to apply potion effects on the player
/*
    void PotionOnPlayer(GameObject player)
    {
        if (PotionSelected.potionType == PotionData.PotionType.Health)
        {
            // Apply health potion effect
            // Example: player.GetComponent<PlayerHealth>().Heal(20);
        }
        else if (PotionSelected.potionType == PotionData.PotionType.Speed)
        {
            // Apply speed potion effect
            // Example: player.GetComponent<PlayerMovement>().IncreaseSpeed(2f, 5f);
        }
    }

    void Update()
    {
        //if the player selected a potion and clicked on itself call the PotionOnPlayer method
        if (PotionSelected != null && Input.GetMouseButtonDown(0))
        {
            PotionOnPlayer(gameObject);
        }
        
    }
}
*/