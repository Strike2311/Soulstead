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
    }
    void Update()
    {
        playerAnimator.SetFloat("Speed", playerMovementObject.currentVelocity.magnitude);
        RenderPlayerSprite();
    }

    void RenderPlayerSprite()
    {
        if ((playerMovementObject.horizontalMovement == 1 && !isFacingRight) || (playerMovementObject.horizontalMovement == -1 && isFacingRight))
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
