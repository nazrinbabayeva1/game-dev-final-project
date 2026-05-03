using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Patrol")]
    public Transform[] waypoints;
    public float patrolSpeed = 2f;
    private int index = 0;

    [Header("Chase")]
    public Transform player;
    public float visionRange = 6f;
    public float chaseSpeed = 4f;

    private bool isChasing = false;

    void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);
            isChasing = distance <= visionRange;
        }

        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    // ---------------- PATROL ----------------
    void Patrol()
    {
        if (waypoints == null || waypoints.Length == 0) return;

        Transform target = waypoints[index];

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            patrolSpeed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            index = (index + 1) % waypoints.Length;
        }
    }

    // ---------------- CHASE ----------------
    void ChasePlayer()
    {
        if (player == null) return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            chaseSpeed * Time.deltaTime
        );
    }

    // ---------------- SETUP METHODS ----------------
    public void SetWaypoints(Transform[] wp)
    {
        waypoints = wp;
    }

    public void SetPlayer(Transform p)
    {
        player = p;
    }
}