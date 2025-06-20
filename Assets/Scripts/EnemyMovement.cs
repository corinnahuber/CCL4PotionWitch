using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine.AI;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{

    public static PotionEffects effects; 
    public PlayerMovement player; // Reference to the PlayerMovement script
    public Enemy enemy; // Reference to the Enemy script
    public float chaseRange;
    public NavMeshAgent agent;

    [SerializeField]
    GameObject target;
    
    [SerializeField]
    private Image fightIcon;

    [SerializeField]
    Transform centerPoint; //CHANGE this later when we have a full world!!

    private float normalSpeed;
    private float chaseSpeed = 6f;
    private float wanderTimer = 0f;
    private float wanderRange = 25f; // Range within which the enemy can wander
    private float wanderDelay = 5f; // How often to pick new random destination
    private Vector3 wanderTarget;
    private bool playerCaught = false;

    bool isOnCooldown = false;
    public float chaseCooldownDuration = 5f;



    private void Awake()
    {
        if (effects == null)
            effects = FindObjectOfType<PotionEffects>();

    }
   
    void Start()
    {

        normalSpeed = agent.speed;
        fightIcon.enabled = false; // Hide the fight icon initially
        if (!agent.isOnNavMesh)
{
        NavMeshHit hit;
        if (NavMesh.SamplePosition(transform.position, out hit, 2f, NavMesh.AllAreas))
            agent.Warp(hit.position);
        else
            Debug.LogWarning($"{name} could not find NavMesh and will be disabled.", this);
    }
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
            {
                return hit.position;
            }
        }
        return Vector3.zero; 
    }


    void Update()
    {
        
        float distanceToPlayer = Vector3.Distance(target.transform.position, transform.position);

        if (!isOnCooldown && distanceToPlayer < chaseRange)
        {   
            agent.speed = chaseSpeed;
            fightIcon.enabled = true;
            agent.SetDestination(target.transform.position);


            if (playerCaught)
            {
                isOnCooldown = true;
                enemy.TakeDamageHearts();
                StartCoroutine(ChaseCooldown());

                if (player.heartIcons.Count <= 0)
                {
                    //change to the game over scene!
                }
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



    IEnumerator ChaseCooldown()
    {
        fightIcon.enabled = false; // Hide the fight icon after cooldown
        yield return new WaitForSeconds(chaseCooldownDuration);
        isOnCooldown = false;
        playerCaught = false;
    }

    void OnMouseDown()
    {
        float distanceToPlayer = Vector3.Distance(target.transform.position, transform.position);
        if (!isOnCooldown && distanceToPlayer < chaseRange)
        {
            Debug.Log("Enemy clicked! Player is within chase range.");
            //call on potionon enemy script
            effects.PotionOnEnemy();
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



 
