using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Stats/Enemy")]
public class EnemyStats : ScriptableObject
{
    public float health;
    public float armor;
    public float speed;
    public float damage;
    public int xpValue;

    public float chargeDelay;
}
