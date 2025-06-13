using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine.AI;
#if UNITY_EDITOR
    using UnityEditor;
#endif
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{

    [SerializeField]
    GameObject target;

    [SerializeField]
    Transform centerPoint; //CHANGE this later when we have a full world!!

    private float chaseRange = 2f;
    private float normalSpeed;
    private float chaseSpeed = 8f;
    private float wanderTimer = 0f;
    private float wanderRange = 20f; // Range within which the enemy can wander
    private float wanderDelay = 5f; // How often to pick new random destination
    private NavMeshAgent agent;
    private Vector3 wanderTarget;
    private bool playerCaught = false;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        normalSpeed = agent.speed;

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
            // chase the player
            agent.speed = chaseSpeed;
            agent.SetDestination(target.transform.position);

            if (playerCaught)
            {
                //for now...later will remove the heart and relocate the player!
                Quit();
                Debug.Log("Player caught!");
            }
        }
        else
        {
            // Wandering behavior
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


 
