using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement parameters")]
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float acceleration = 0.1f;
    [SerializeField] private float deceleration = 0.1f;
    [SerializeField] private float horizontalMovement;
    [SerializeField] private float verticalMovement;
    [SerializeField] private Rigidbody2D playerRb;

    private Vector2 currentVelocity;


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
        Vector2 inputVector = new Vector2(horizontalMovement, verticalMovement);
        return inputVector.normalized;
    }
    
    
}
