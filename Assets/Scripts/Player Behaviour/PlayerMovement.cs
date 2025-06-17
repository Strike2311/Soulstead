using System;
using UnityEngine;
using Soulstead.Enums;
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement parameters")]
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float acceleration = 0.1f;
    [SerializeField] private float deceleration = 0.1f;
    [SerializeField] public float horizontalMovement { get; private set; }
    [SerializeField] public float verticalMovement { get; private set; }
    private Rigidbody2D playerRb;
    public event Action<Vector2> OnFacingDirectionChanged;
    public Vector2 movementDirectionVector { get; private set; }

    public Vector2 currentVelocity { get; private set; }

    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 normalizedMovementVector = GetMovementVector();
        Vector2 targetVelocity = normalizedMovementVector * movementSpeed;
        float accelerationRate = (normalizedMovementVector.magnitude > 0.1f) ? acceleration : deceleration;

        currentVelocity = Vector2.MoveTowards(currentVelocity, targetVelocity, accelerationRate * Time.fixedDeltaTime);
        playerRb.linearVelocity = currentVelocity;
    }

    Vector2 GetMovementVector()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
        movementDirectionVector = new Vector2(horizontalMovement, verticalMovement);

        if ((movementDirectionVector.x == 0) ^ (movementDirectionVector.y == 0))
        {
            OnFacingDirectionChanged?.Invoke(movementDirectionVector.normalized);
        }
        return movementDirectionVector.normalized;
    }
    
}
