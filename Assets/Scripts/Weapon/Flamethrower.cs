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

    private bool isFiring;

    protected override void Update()
    {
        if (!isFiring)
        {
            Transform target = GetClosestEnemy();
            if (target != null)
            {
                StartCoroutine(FlameBurst(target));
            }
        }
    }

    private IEnumerator FlameBurst(Transform target)
    {
        isFiring = true;
        float time = 0f;

        while (time < burstDuration && target != null)
        {
            FireConeAt(target);
            time += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(cooldownBetweenBursts);
        isFiring = false;
    }

    private void FireConeAt(Transform target)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, flameRange, enemyLayer);

        Vector2 flameOrigin = transform.position;
        Vector2 flameDir = (new Vector2 (target.position.x, target.position.y) - flameOrigin).normalized;
        foreach (var hit in hits)
        {
            Debug.Log("Hit: " + hit.name);
            if (hit.TryGetComponent(out EnemyBase enemy))
            {
                Vector2 toEnemy = ((Vector2)hit.transform.position - flameOrigin).normalized;
                float angle = Vector2.Angle(flameDir, toEnemy);
                Debug.Log("Angle " + angle);
                if (angle < coneAngle / 2f)
                {
                    enemy.TakeDamage(damagePerSecond * Time.deltaTime);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, flameRange);
    }
}
