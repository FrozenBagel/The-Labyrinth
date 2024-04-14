using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 4.0f;
    private Transform player;
    public LayerMask obstacleMask;
    public float raycastDistance = 1.5f;
    public float avoidDistance = 2f;
    public float avoidanceForce = 2f;
    public int damageAmount = 10;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player == null)
        {
            Debug.LogError("Player not found!");
        }
    }

    void Update()
    {
        if (player == null)
        {
            return;
        }

        Vector3 direction = (player.position - transform.position).normalized;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, raycastDistance, obstacleMask);

        if (hit.collider != null && hit.collider.CompareTag("Trap"))
        {
            Vector3 avoidDirection = CalculateAvoidanceDirection(hit.point);
            direction += avoidDirection * avoidanceForce;
        }

        Vector3 movementAmount = direction * speed * Time.deltaTime;
        transform.position += movementAmount;
    }

    Vector3 CalculateAvoidanceDirection(Vector2 obstaclePosition)
    {
        Vector3 avoidDirection = (transform.position - (Vector3)obstaclePosition).normalized;
        float distanceToObstacle = Vector2.Distance(transform.position, obstaclePosition);

        float avoidanceFactor = Mathf.Clamp01(avoidDistance / distanceToObstacle);

        return avoidDirection * avoidanceFactor;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damageAmount);
        }
    }
}