using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [Header("Weapon Stats")]
    [SerializeField] protected float attackRate = 1f;
    [SerializeField] protected float projectileSpeed = 10f;
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected float range = 5f;
    [SerializeField] protected float damage = 5f;

    protected float attackCooldown = 0f;
    protected Transform target;

    // Static list to prevent duplicate targeting
    protected static HashSet<GameObject> targetedEnemies = new HashSet<GameObject>();

    protected virtual void Update()
    {
        attackCooldown -= Time.deltaTime;
        if (attackCooldown < 0f) attackCooldown = 0f;

        if (CanAttack())
        {
            target = GetClosestUntargetedEnemy();

            if (target != null)
            {
                targetedEnemies.Add(target.gameObject);
                FireAt(target);
                ResetCooldown();
            }
        }
    }

    protected virtual bool CanAttack() => attackCooldown <= 0f;

    protected virtual void ResetCooldown()
    {
        attackCooldown = 1f / attackRate;
    }

    protected virtual void FireAt(Transform target)
    {
        if (projectilePrefab == null || target == null) return;

        Vector2 direction = (target.position - transform.position).normalized;
        GameObject bullet = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<ProjectileParams>().damage = damage;
        bullet.GetComponent<Rigidbody2D>().linearVelocity = direction * projectileSpeed;
        AddBulletRotation(bullet, direction);
        // Optionally clear from targeting after shot
        StartCoroutine(ClearTargetAfterDelay(target.gameObject, 0.1f));
    }

    protected virtual void AddBulletRotation(GameObject bullet, Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    protected virtual Transform GetClosestUntargetedEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Transform closest = null;
        float closestDist = range;

        foreach (GameObject enemy in enemies)
        {
            if (targetedEnemies.Contains(enemy)) continue;

            float dist = Vector2.Distance(transform.position, enemy.transform.position);
            if (dist < closestDist)
            {
                closest = enemy.transform;
                closestDist = dist;
            }
        }

        return closest;
    }

    protected System.Collections.IEnumerator ClearTargetAfterDelay(GameObject enemy, float delay)
    {
        yield return new WaitForSeconds(delay);
        targetedEnemies.Remove(enemy);
    }

    public void ClearTargetedEnemies() => targetedEnemies.Clear(); // Call on wave end or death
}
