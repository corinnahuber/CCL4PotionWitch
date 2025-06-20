using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


public class PotionEffects : MonoBehaviour
{

    public PlayerMovement player; 
    public Enemy enemyHealth;
    public EnemyBar enemyBar; 
    public NavMeshAgent enemy;
    public bool used = false; // To check if a potion has been used

    private float stunDuration = 10f;
    private Coroutine stunCoroutine;


    public void PotionOnEnemy()
    {

        if (PotionsInventoryUI.instance.selectedIndex >= 0)
        {
            // Get the selected potion data
            PotionData PotionSelected = PotionInventory.instance.potionsMade[PotionsInventoryUI.instance.selectedIndex];
            Debug.Log("Potion selected: " + PotionSelected.potionType);


            if (PotionSelected.potionType != PotionData.PotionType.Health &&
                PotionSelected.potionType != PotionData.PotionType.Speed)
            {

                switch (PotionSelected.potionType)
                {
                    case PotionData.PotionType.Damage:
                        DealDamage(enemyHealth.enemyDamage);
                        used = true;
                        break;

                    case PotionData.PotionType.Destruction:
                        Destroy(enemy.gameObject);
                        used = true;
                        break;


                    case PotionData.PotionType.Stun:
                        
                        if (stunCoroutine != null) //in case we already used a stun potion on the enemy
                            StopCoroutine(stunCoroutine);

                        stunCoroutine = StartCoroutine(StunEnemy(enemy));
                        break;
                }

                if (used)
                {
                    PotionInventory.instance.RemovePotion(PotionSelected);
                    PotionsInventoryUI.instance.PotionInventoryUIUpdate();
                    //PotionsInventoryUI.instance.SelectedPotion(PotionsInventoryUI.instance.selectedIndex-1); 
                    used = false; // Reset the used flag
                }
            }

        }

    }


    private IEnumerator StunEnemy(NavMeshAgent enemy)
    {
        enemy.enabled = false; // Disable the NavMeshAgent to stop movement

        yield return new WaitForSeconds(stunDuration);

        if (enemy != null)
            enemy.enabled = true;
    }



    private IEnumerator RevertSpeedBoost()
    {
        yield return new WaitForSeconds(6f); // Wait for 6 seconds before reverting speed
        player.movementPerSecond = 5f; // Revert the speed boost
    }



    void DealDamage(int enemyDamage)
    {

        enemyHealth.currentHealth -= enemyDamage;
        enemyBar.EnemyHealth(enemyHealth.currentHealth); // Update the enemy's health bar UI

        if (enemyHealth.currentHealth <= 0)
        {
            Destroy(enemy.gameObject); // Destroy the enemy object
        }
    }




    public void PotionOnPlayer()
    {

        // Check if a potion is selected
        if (PotionsInventoryUI.instance.selectedIndex >= 0)
        {

            PotionData PotionSelected = PotionInventory.instance.potionsMade[PotionsInventoryUI.instance.selectedIndex];

            switch (PotionSelected.potionType)
            {
                case PotionData.PotionType.Health:
                    if (player.heartIcons.Count < player.allHeartIcons.Count)
                    {
                        RestoreHeart();
                        used = true;
                    }
                    else 
                    {
                        Debug.Log("Cannot restore heart, maximum hearts reached.");
                    }
                    break;

                case PotionData.PotionType.Speed:
                    player.movementPerSecond += 3f;
                    StartCoroutine(RevertSpeedBoost());
                    used = true;
                    break;
            }

            if (used)
            {
                PotionInventory.instance.RemovePotion(PotionSelected);
                PotionsInventoryUI.instance.PotionInventoryUIUpdate();
                used = false; // Reset the used flag
            }
        }
    }

    public void RestoreHeart()
    {
        
            int indexToEnable = player.heartIcons.Count;
            player.allHeartIcons[indexToEnable].enabled = true;
            player.heartIcons.Add(player.allHeartIcons[indexToEnable]);

            Debug.Log("Heart restored! Total hearts: " + player.heartIcons.Count);

    }
}
