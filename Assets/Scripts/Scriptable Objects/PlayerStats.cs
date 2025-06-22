using UnityEngine;

[CreateAssetMenu(menuName = "Stats/Player Stats")]
public class PlayerStatsData : ScriptableObject
{


    [Header("Core Stats")]
    public int maxHealth = 20;
    public int armor = 0;
    [Range(0f, 1f)]
    public float dodge = 0f;

    [Header("Movement & Speed")]
    public float moveSpeed = 10f;
    [Range(0f, 2f)]
    public float castSpeed = 0f;
    [Range(0f, 2f)]
    public float attackSpeed = 0f;

    [Header("Combat Enhancements")]
    [Range(0f, 1f)]
    public float lifeSteal = 0f;
    [Range(1f, 2f)]
    public float damageModifier = 1f;
    public float range = 4;

    [Header("Critical Stats")]
    [Range(1f, 5f)]
    public float critDamage = 1.2f;
    [Range(0f, 1f)]
    public float critChance = 0f;

    [Header("Weapon Behavior")]
    public int pierce = 3;

    [Header("Utility")]
    public float pickupRadius = 1.5f;
    public int luck = 0;

    [Header("Level")]

    public float gathering = 10;
    public int xp = 0;
    public int level = 1;
    public int xpToNextLevel = 100;
}
