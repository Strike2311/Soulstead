using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private PlayerMovement playerMovementObject;
    public Animator playerAnimator;
    [SerializeField] private bool isFacingRight = true;
    void Start()
    {
        playerMovementObject = gameObject.GetComponent<PlayerMovement>();
        playerAnimator = gameObject.GetComponent<Animator>();
        SubscribeToEvents();
    }
    void Update()
    {
        playerAnimator.SetFloat("Speed", playerMovementObject.currentVelocity.magnitude);
    }
    void SubscribeToEvents()
    {
        if (playerMovementObject != null)
            playerMovementObject.OnFacingDirectionChanged += RenderPlayerSprite;
    }


    void RenderPlayerSprite(Vector2 newFacingDirection)
    {
        bool playerTurnedRight = newFacingDirection == Vector2.right;
        bool playerTurnedLeft = newFacingDirection == Vector2.left;
        if ((playerTurnedRight && !isFacingRight) || (playerTurnedLeft && isFacingRight))
            Flip();
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x = -1f * localScale.x;
        transform.localScale = localScale;
    }
}
