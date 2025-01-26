using Unity.VisualScripting;
using UnityEngine;

public class AISIMPLE : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    public float speed = 1.3f;
    public float stopDistance = 2f; // Distance at which the object stops moving
    Animator animator;

    void Start()
    {
        // Optional: Initialization logic here
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Calculate the distance between the current object and the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        // Check if the object is further than the stop distance
        if (distanceToPlayer > stopDistance)
        {
            // Rotate to face the player
            transform.LookAt(player.transform);

            // Move towards the player
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            animator.SetBool("mov", true);
        }
        else
        {

        }
    }
}
