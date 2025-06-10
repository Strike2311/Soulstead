using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Sprite[] playerIdleSprites;
    private PlayerMovement playerMovementObject;
    private SpriteRenderer spriteRenderer;
    public Animator playerAnimator;
    private bool spriteVerticalRight = true;

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
        if (newFacingDirection == Vector2.right)
        {
            if (!spriteVerticalRight)
            {   playerAnimator.SetFloat
                _ = spriteRenderer.flipX;
            }
        }
        else if (newFacingDirection == Vector2.left)
        {
            if (spriteVerticalRight) {
                _ = spriteRenderer.flipX;
            }
        }
        /*else if (newFacingDirection == Vector2.down)
        {
        }
        else
        {
        }*/
    }
}
