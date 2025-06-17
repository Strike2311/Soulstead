using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public float attackRate = 1f; // shots per second
    protected float attackCooldown = 0f;

    protected virtual void Update()
    {
        attackCooldown -= Time.deltaTime;
        if (attackCooldown <= 0f)
        {
            attackCooldown = 0f;
        }
    }

    protected bool CanAttack() => attackCooldown <= 0f;

    protected void ResetCooldown()
    {
        attackCooldown = 1f / attackRate;
    }
}