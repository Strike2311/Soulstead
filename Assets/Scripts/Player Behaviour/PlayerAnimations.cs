using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Sprite[] playerIdleSprites;
    private PlayerMovement playerMovementObject;
    private SpriteRenderer spriteRenderer;
    public Animator playerAnimator;
    [SerializeField] private bool isFacingRight = true;
    void Start()
    {
        playerMovementObject = gameObject.GetComponent<PlayerMovement>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        playerAnimator = gameObject.GetComponent<Animator>();
        SubscribeToEvents();
    }
    void SubscribeToEvents()
    {
        if (playerMovementObject != null)
            playerMovementObject.OnFacingDirectionChanged += RenderPlayerSprite;
    }


    void RenderPlayerSprite(Vector2 newFacingDirection)
    {
        Debug.Log(newFacingDirection);
        if (newFacingDirection == Vector2.right)
        {
            if (!isFacingRight)
                Flip();
        }
        else if (newFacingDirection == Vector2.left)
        {
            if (isFacingRight)
                Flip();
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x = -1f * localScale.x;
        transform.localScale = localScale;
    }
}
