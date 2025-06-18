using UnityEngine;

[CreateAssetMenu(menuName = "Stats/Player Stats")]
public class PlayerStatsData : ScriptableObject
{
    public float maxHealth = 20;
    public float armor = 1;
    public float moveSpeed = 5;
    public float damage = 20;
    public float range = 4;
    public float gathering = 10;
    public int xp = 0;
    public int level = 1;
    public int xpToNextLevel = 100;
}
