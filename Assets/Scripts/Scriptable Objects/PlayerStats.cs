using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats/Player Stats")]
public class PlayerStatsData : ScriptableObject
{
    [Header("Core Stats")]
    private int baseMaxHealth = 20;
    public int maxHealth;
    public int currentHealth;
    private int baseArmour = 0;
    public int armour;
    private float baseDodge = 0f;
    [Range(0f, 1f)]
    public float dodge;

    [Header("Movement & Speed")]
    private float baseMoveSpeed = 10f;
    public float moveSpeed;

    private float baseCastSpeed = 0f;
    [Range(0f, 10f)]
    public float castSpeed;
    private float baseAttackSpeed = 0f;
    [Range(0f, 10f)]
    public float attackSpeed;

    [Header("Combat Enhancements")]
    private float baseLifeSteal = 0f;
    [Range(0f, 1f)]
    public float lifeSteal;

    [Range(1f, 2f)]
    private float baseDamageModifier = 0f;
    public float damageModifier;

    private float baseRange = 4f;
    public float range;

    [Header("Critical Stats")]
    private float baseCritDamage = 0.15f;
    [Range(0f, 10f)]
    public float critDamage;

    private float baseCritChance = 0.05f;
    [Range(0f, 1f)]
    public float critChance;

    [Header("Weapon Behavior")]
    private int basePierce = 3;
    public int pierce;

    [Header("Utility")]
    private float basePickupRadius = 4f;
    public float pickupRadius;

    private int baseLuck = 0;
    public int luck;

    [Header("Level")]
    private int baseXp = 0;
    public int xp;
    private int baseLevel = 1;
    public int level;
    private int baseXpToNextLevel = 100;
    public int xpToNextLevel;

    public void InitializeStats()
    {
        maxHealth = baseMaxHealth;
        currentHealth = baseMaxHealth;
        armour = baseArmour;
        dodge = baseDodge;

        moveSpeed = baseMoveSpeed;
        castSpeed = baseCastSpeed;
        attackSpeed = baseAttackSpeed;

        lifeSteal = baseLifeSteal;
        damageModifier = baseDamageModifier;
        range = baseRange;

        critDamage = baseCritDamage;
        critChance = baseCritChance;

        pierce = basePierce;
        pickupRadius = basePickupRadius;
        luck = baseLuck;

        xp = baseXp;
        level = baseLevel;
        xpToNextLevel = baseXpToNextLevel;
    }

    public float CalculateDamage(float damage)
    {
        float randomNumber = UnityEngine.Random.Range(0f, 1f);
        if (randomNumber <= critChance)
        {
            damage += damage * critDamage;
        }
        ApplyLifeSteal(damage);

        return damage;
    }

    public void ApplyLifeSteal(float damageDealt)
{
    float lifeStolenRaw = damageDealt * lifeSteal;

    int lifeToHeal = Mathf.FloorToInt(lifeStolenRaw);

    currentHealth += Math.Min(maxHealth - currentHealth, lifeToHeal);
    
}
}
