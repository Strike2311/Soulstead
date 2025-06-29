using System;
using UnityEngine;

public class PlayerStatsRuntime : MonoBehaviour
{
    [Header("Base Stats")]
    public PlayerStatsData baseStats;



    [Header("External Objects")]
    public GameManager gameManagerObject;

    void Start()
    {
        gameManagerObject = GameObject.Find("Game Manager").GetComponent<GameManager>();
        baseStats.currentHealth = baseStats.maxHealth;
    }
    public void DealDamage(EnemyBase enemy, int damage)
    {
        enemy.TakeDamage(damage * baseStats.damageModifier);
    }

    public void TakeDamage(float amount)
    {
        float randomNumber = UnityEngine.Random.Range(0f, 1f);
        if (randomNumber <= baseStats.dodge)
        {
            float effectiveDamage = Mathf.Max(0, amount - baseStats.armour);
            baseStats.currentHealth -= effectiveDamage;
            Debug.Log($"Player took {effectiveDamage} damage. Health now: {baseStats.currentHealth}");
        }
        else
        {
            Debug.Log($"Player dodged!");
        }


        if (baseStats.currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        baseStats.currentHealth = Mathf.Min(baseStats.currentHealth + amount, baseStats.maxHealth);
    }

    private void Die()
    {
        gameManagerObject.GameOver();
    }
    
    public float CalculateDamage(float damage)
    {
        float randomNumber = UnityEngine.Random.Range(0f, 1f);
        if (randomNumber <= baseStats.critChance)
        {
            damage += damage * baseStats.critDamage;
        }
        ApplyLifeSteal(damage);

        return damage;
    }

    public void ApplyLifeSteal(float damageDealt)
    {
        float lifeStolen = damageDealt * baseStats.lifeSteal;

        baseStats.currentHealth += Math.Min(baseStats.maxHealth - baseStats.currentHealth, lifeStolen);
        
    }
}
