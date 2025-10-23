using UnityEngine;

public class SimpleEnemyAI : MonoBehaviour
{
    [Header("AI Settings")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float detectionRange = 5f;
    [SerializeField] private float attackRange = 1f;

    [Header("Patrol Settings")]
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private float waitTime = 2f;

    private Transform player;
    private int currentPatrolIndex = 0;
    private float waitTimer = 0f;
    private bool isWaiting = false;

    private enum AIState
    {
        Patrolling,
        Chasing,
        Attacking
    }

    private AIState currentState = AIState.Patrolling;

    void Start()
    {
        // Find player
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (player == null)
        {
            Debug.LogWarning("No player found! Enemy will only patrol.");
        }

        Debug.Log("Simple Enemy AI started!");
    }

    void Update()
    {
        // Update AI state
        UpdateAIState();

        // Execute current state
        switch (currentState)
        {
            case AIState.Patrolling:
                Patrol();
                break;
            case AIState.Chasing:
                ChasePlayer();
                break;
            case AIState.Attacking:
                AttackPlayer();
                break;
        }
    }

    void UpdateAIState()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            currentState = AIState.Attacking;
        }
        else if (distanceToPlayer <= detectionRange)
        {
            currentState = AIState.Chasing;
        }
        else
        {
            currentState = AIState.Patrolling;
        }
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        Transform targetPoint = patrolPoints[currentPatrolIndex];

        if (isWaiting)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= waitTime)
            {
                isWaiting = false;
                waitTimer = 0f;
                currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
            }
        }
        else
        {
            // Move towards patrol point
            Vector2 direction = (targetPoint.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);

            // Check if reached patrol point
            if (Vector2.Distance(transform.position, targetPoint.position) < 0.5f)
            {
                isWaiting = true;
            }
        }
    }

    void ChasePlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * moveSpeed * 1.5f * Time.deltaTime);

        Debug.Log("Chasing player!");
    }

    void AttackPlayer()
    {
        // Stop moving and attack
        Debug.Log("Attacking player!");

        // Simple attack - could be expanded
        if (player != null)
        {
            // Deal damage, play animation, etc.
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw detection range
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        // Draw attack range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        // Draw patrol path
        if (patrolPoints != null && patrolPoints.Length > 1)
        {
            Gizmos.color = Color.blue;
            for (int i = 0; i < patrolPoints.Length; i++)
            {
                if (patrolPoints[i] != null)
                {
                    Gizmos.DrawWireSphere(patrolPoints[i].position, 0.5f);

                    int nextIndex = (i + 1) % patrolPoints.Length;
                    if (patrolPoints[nextIndex] != null)
                    {
                        Gizmos.DrawLine(patrolPoints[i].position, patrolPoints[nextIndex].position);
                    }
                }
            }
        }
    }
}
