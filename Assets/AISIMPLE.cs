using UnityEngine;
using UnityEngine.AI;

public class AISIMPLE : MonoBehaviour
{
    public GameObject player;
    public float stopDistance = 2f; // Distance at which the enemy stops following
    public float speed = 3.5f; // Adjust speed
    private NavMeshAgent agent;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (agent != null)
        {
            agent.speed = speed; // Set speed
        }
    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distanceToPlayer > stopDistance)
            {
                // Move towards the player using NavMesh
                agent.SetDestination(player.transform.position);
                animator.SetBool("mov", true);
            }
            else
            {
                // Stop moving when close enough
                agent.ResetPath();
                animator.SetBool("mov", false);
            }
        }
    }
}
