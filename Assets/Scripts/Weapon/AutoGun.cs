using Unity.VisualScripting;
using UnityEngine;

public class AutoGun : WeaponBase
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
   
    protected override void Update()
    {
        base.Update();

        GameObject target = GetClosestEnemy();
        if (target != null && CanAttack())
        {
            FireAt(target.transform);
            ResetCooldown();
        }
    }

    void FireAt(Transform target)
    {
        Vector2 direction = (target.position - transform.position).normalized;

        GameObject bullet = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().linearVelocity = direction * projectileSpeed;
    }

    GameObject GetClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float closestDist = gameObject.GetComponentInParent<PlayerStatsRuntime>().range;

        foreach (GameObject enemy in enemies)
        {
            float dist = Vector2.Distance(transform.position, enemy.transform.position);
            if (dist < closestDist)
            {
                closest = enemy;
                closestDist = dist;
            }
        }

        return closest;
    }
}