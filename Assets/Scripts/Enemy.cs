using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 30;
    public int enemyDamage = 10;

    public PlayerMovement player;

    public int currentHealth;

    public EnemyBar healthBar;



    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    public void TakeDamageHearts()
    {
        if (player.heartIcons.Count > 0)
        {
            int lastIndex = player.heartIcons.Count - 1;
            // Remove the last heart icon from the player's heart icons list
            player.heartIcons[lastIndex].enabled = false;
            player.heartIcons.RemoveAt(lastIndex);
        }

    }
}