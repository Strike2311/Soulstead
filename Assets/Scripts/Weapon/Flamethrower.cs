using UnityEngine;

public class Flamethrower : WeaponBase
{
    public float burnDuration = 2f;
    public float coneAngle = 45f;

    protected override void FireAt(Transform target)
    {
        // AoE cone damage implementation instead of projectile
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, range);
        foreach (var hit in hits)
        {
            Vector2 dirToTarget = (hit.transform.position - transform.position).normalized;
            float angle = Vector2.Angle(transform.up, dirToTarget);
            if (angle <= coneAngle / 2 && hit.CompareTag("Enemy"))
            {
                // Apply burn damage logic here
                Debug.Log($"Flamethrower hits {hit.name}");
            }
        }

        ResetCooldown();
    }
}
