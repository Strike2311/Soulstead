using UnityEngine;

public class HandGun : WeaponBase
{
    protected override void Update()
    {
        base.Update();
        attackCooldown -= Time.deltaTime;
        if (attackCooldown < 0f) attackCooldown = 0f;
        if (CanAttack())
        {
            target = GetClosestEnemy();

            if (target != null)
            {
                FireAt(target);
                ResetCooldown();
            }
        }
    }
    protected override void FireAt(Transform target)
    {
        base.FireAt(target);
    }
}
