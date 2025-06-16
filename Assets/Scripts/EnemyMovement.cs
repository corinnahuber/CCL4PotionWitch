using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine.AI;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{


    public static EnemyMovement instance;

    [SerializeField]
    GameObject target;

    public int enemyHealth;

    [SerializeField]
    Transform centerPoint; //CHANGE this later when we have a full world!!

    public float chaseRange;
    private float normalSpeed;
    private float chaseSpeed = 10f;
    private float wanderTimer = 0f;
    private float wanderRange = 20f; // Range within which the enemy can wander
    private float wanderDelay = 5f; // How often to pick new random destination
    public NavMeshAgent agent;
    private Vector3 wanderTarget;
    private bool playerCaught = false;
    [SerializeField]
    private Image fightIcon;


    void Start()
    {

        //EnemyBar.instance.SetMaxHealth(enemyHealth); 
        //EnemyBar.instance.EnemyHealth(enemyHealth); 
       // Debug.Log("Enemy Health: " + enemyHealth);
        //Debug.Log("Enemy Bar Initialized");
     
        normalSpeed = agent.speed;
        fightIcon.enabled = false; // Hide the fight icon initially

        SetNewWanderTarget();
    }



    Vector3 GetRandomNavMeshPosition(Transform center, float range)
    {
        for (int i = 0; i < 30; i++) // Try up to 30 times
        {
            // Generate a random position within the specified range
            Vector3 randomDirection = Random.insideUnitSphere * range;
            randomDirection += center.position;

            // Check if the position is valid on the NavMesh
            if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, 2.0f, NavMesh.AllAreas))
                return hit.position;
        }
        return Vector3.zero; // Return zero if no valid position is found after 30 attempts
    }


    void Update()
    {
        float distanceToPlayer = Vector3.Distance(target.transform.position, transform.position);

        if (distanceToPlayer < chaseRange)
        {
            agent.speed = chaseSpeed;
            fightIcon.enabled = true;
            agent.SetDestination(target.transform.position);


            if (playerCaught)
            {
                //for now...later will remove the heart and relocate the player!
                //Quit();
            }
        }
        

        else
        {
            //if not the enemy is not chasing the player anymore it will wander around
            agent.speed = normalSpeed;
            agent.isStopped = false;

            wanderTimer += Time.deltaTime;
            if (wanderTimer >= wanderDelay || agent.remainingDistance < 0.5f)
            {
                SetNewWanderTarget();
                wanderTimer = 0f;

            }

        }
    }



    void OnMouseDown()
    {
        float distanceToPlayer = Vector3.Distance(target.transform.position, transform.position);
        if (distanceToPlayer < chaseRange)
        {
            Debug.Log("Enemy clicked! Player is within chase range.");
            PotionEffects.instance.PotionOnEnemy();
        }
    }
   

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerCaught = true;
    }



    void SetNewWanderTarget()
    {
        wanderTarget = GetRandomNavMeshPosition(centerPoint.transform, wanderRange);
        agent.SetDestination(wanderTarget);
    }


    //remove this later!
    void OnDrawGizmosSelected()
    {
        // Draw chase range in red
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);

        // Draw wander range in blue (if using center point)
        if (centerPoint != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(centerPoint.position, wanderRange);
        }
    }


    public void Quit()
{
    #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}



 
