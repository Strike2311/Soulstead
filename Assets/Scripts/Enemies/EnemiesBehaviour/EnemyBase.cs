using Soulstead.Interfaces;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour, IDamageable, IDamageDealer
{
    [Header("Stats")]
    protected float health;
    protected float armor;
    protected float speed;
    protected float damage;
    protected Transform player;
    protected Rigidbody2D rb;

    [SerializeField] protected EnemyStats stats;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        health = stats.health;
        armor = stats.armor;
        speed = stats.speed;
        damage = stats.damage;
    }

    protected virtual void Update()
    {
        HandleBehaviour();
    }

    protected abstract void HandleBehaviour();

    public virtual void TakeDamage(float damage)
    {
        float effectiveDamage = Mathf.Max(0, damage - armor);
        health -= effectiveDamage;
        if (health <= 0) Die();
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
    
    public float GetDamage()
    {
        return damage;
    }
}