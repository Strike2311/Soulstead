using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private GameObject player;

    [Header("Movement")]
    [SerializeField] private float speed = 2f;
    private Rigidbody2D rb;
    private Vector2 direction;

    [Header("Chase Logic")]
    [SerializeField] private float chaseLimit = 5f;      // How far the enemy can chase
    [SerializeField] private float chaseResetZone = 1f;  // When enemy gets back to this area, it can chase again
    private Vector3 startingPosition;
    private bool canChase = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPosition = transform.position;
    }

    void FixedUpdate()
    {
        HandleChase();
        CheckResetZone();
    }

    void HandleChase()
    {
        // If player is within chase limit and allowed to chase
        if (canChase && GetDistanceFromStart() < chaseLimit && isPlayerInChaseZone())
        {
            direction = (player.transform.position - transform.position).normalized;
        }
        else
        {
            // Return to start position
            canChase = false;
            direction = (startingPosition - transform.position).normalized;
        }

        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    void CheckResetZone()
    {
        Vector2 pos = transform.position;
        bool insideResetX = pos.x > startingPosition.x - chaseResetZone && pos.x < startingPosition.x + chaseResetZone;
        bool insideResetY = pos.y > startingPosition.y - chaseResetZone && pos.y < startingPosition.y + chaseResetZone;

        if (insideResetX && insideResetY)
            canChase = true;
    }

    bool isPlayerInChaseZone()
    {  

        return Vector2.Distance(rb.position, new Vector2(player.transform.position.x, player.transform.position.y)) <= chaseLimit;
    }

    float GetDistanceFromStart()
    {
        return Vector2.Distance(startingPosition, rb.position);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(startingPosition, chaseLimit);
    }
}
