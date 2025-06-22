using System.Collections;
using UnityEngine;

public class Flamethrower : WeaponBase
{
    [Header("Flamethrower Settings")]
    public float flameRange = 5f;
    public float coneAngle = 60f;
    public float damagePerSecond = 10f;
    public float burstDuration = 2f;
    public float cooldownBetweenBursts = 1f;
    public LayerMask enemyLayer;
    private Animator animator;
    private bool isFiring;
    private Transform currentTarget;
    private Vector2 cachedFlameDirection;




    protected override void Update()
    {
        base.Update();
        if (!isFiring)
        {
            Transform target = GetClosestEnemy();
            if (target != null)
            {
                animator = gameObject.GetComponent<Animator>();
                StartCoroutine(FlameBurst(target));
            }
        }
    }

    private IEnumerator FlameBurst(Transform target)
    {
        isFiring = true;
    currentTarget = target;
    animator.SetBool("FlamethrowerBurst", true);

    // Cache direction ONCE
    cachedFlameDirection = ((Vector2)(target.position - player.transform.position)).normalized;

    float time = 0f;
    while (time < burstDuration && target != null)
    {
        FireAt();
        time += Time.deltaTime;
        yield return null;
    }

    animator.SetBool("FlamethrowerBurst", false);
    yield return new WaitForSeconds(cooldownBetweenBursts);
    isFiring = false;
    }

    protected void FireAt()
    {
        Vector2 flameOrigin = player.transform.position;
        float angle = Mathf.Atan2(cachedFlameDirection.y, cachedFlameDirection.x) * Mathf.Rad2Deg;
        animator.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        Collider2D[] hits = Physics2D.OverlapCircleAll(flameOrigin, flameRange, enemyLayer);
        foreach (var hit in hits)
        {
            if (hit.TryGetComponent(out EnemyBase enemy))
            {
                Vector2 toEnemy = ((Vector2)hit.transform.position - flameOrigin).normalized;
                float angleToEnemy = Vector2.Angle(cachedFlameDirection, toEnemy);

                if (angleToEnemy <= coneAngle / 2f)
                {
                    enemy.TakeDamage(damagePerSecond * Time.deltaTime);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (currentTarget == null) return;

        UnityEngine.Vector2 origin = transform.position;
        UnityEngine.Vector2 dir = cachedFlameDirection.normalized;

        float halfAngle = coneAngle / 2f;
        float radius = flameRange;

        Gizmos.color = Color.red;

        // Cone boundaries
        UnityEngine.Vector2 leftDir = UnityEngine.Quaternion.Euler(0, 0, -halfAngle) * dir;
        UnityEngine.Vector2 rightDir = UnityEngine.Quaternion.Euler(0, 0, halfAngle) * dir;

        Gizmos.DrawLine(origin, origin + leftDir * radius);
        Gizmos.DrawLine(origin, origin + rightDir * radius);

        // Optional: draw arc using multiple segments
        int segments = 20;
        UnityEngine.Vector3 tmpVector3 = UnityEngine.Quaternion.Euler(0, 0, -halfAngle) * dir * radius;
        UnityEngine.Vector2 tmpVector2 = new UnityEngine.Vector2 (tmpVector3.x, tmpVector3.y);
        UnityEngine.Vector2 prevPoint = origin + tmpVector2;

        for (int i = 1; i <= segments; i++)
        {
            float angle = -halfAngle + (coneAngle / segments) * i;
            UnityEngine.Vector2 segDir = UnityEngine.Quaternion.Euler(0, 0, angle) * dir;
            UnityEngine.Vector2 point = origin + segDir * radius;

            Gizmos.DrawLine(prevPoint, point);
            prevPoint = point;
        }
    }
}
