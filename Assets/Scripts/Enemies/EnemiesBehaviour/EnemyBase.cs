using System;
using System.Collections.Generic;
using Soulstead.Interfaces;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour, IDamageable, IDamageDealer
{
    [Header("Stats")]
    protected float health;
    protected float armor;
    protected float speed;
    protected float damage;
    protected int xpValue;
    [SerializeField] private Dictionary<string, GameObject> pickupXpDictionary;
    protected Transform player;
    protected Rigidbody2D rb;
    public event Action<int> OnDeath;

    [SerializeField] protected EnemyStats stats;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        health = stats.health;
        armor = stats.armor;
        speed = stats.speed;
        damage = stats.damage;
        xpValue = stats.xpValue;
    }

    protected virtual void Update()
    {
        HandleBehaviour();
    }

    protected abstract void HandleBehaviour();

    public virtual void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            TakeDamage(collision.GetComponent<ProjectileParams>().damage);
            Destroy(collision.gameObject);
        }
    }
    public virtual void TakeDamage(float damage)
    {
        Vector3 direction = (transform.position - player.transform.position).normalized;
        rb.AddForce(direction.normalized * 100, ForceMode2D.Impulse);
        float effectiveDamage = Mathf.Max(0, damage - armor);
        health -= effectiveDamage;
        if (health <= 0) Die();
    }

    public virtual void Die()
    {
        OnDeath?.Invoke(1);
        Destroy(gameObject);
        XPDropper dropper = GetComponent<XPDropper>();
        dropper.DropXP(xpValue);
    }
    
    public float GetDamage()
    {
        return damage;
    }
}