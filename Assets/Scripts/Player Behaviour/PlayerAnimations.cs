using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Sprite[] playerIdleSprites;
    private PlayerMovement playerMovementObject;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        playerMovementObject = gameObject.GetComponent<PlayerMovement>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        SubscribeToEvents();
    }
    void SubscribeToEvents()
    {
        if (playerMovementObject != null)
            playerMovementObject.OnFacingDirectionChanged += RenderPlayerSprite;
    }

    
    void RenderPlayerSprite(Vector2 newFacingDirection)
    {
        Sprite newSprite;
        if (newFacingDirection == Vector2.right) {
            newSprite = playerIdleSprites[0];
        } else if (newFacingDirection == Vector2.left) {
            newSprite = playerIdleSprites[1];
        } else if (newFacingDirection == Vector2.down) {
            newSprite = playerIdleSprites[2];
        } else { 
            newSprite = playerIdleSprites[3];
        }
        spriteRenderer.sprite = newSprite;
    }
}
