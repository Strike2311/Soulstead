using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Enemies/Stats")]
public class EnemyStats : ScriptableObject
{
    public float health;
    public float armor;
    public float speed;
    public float damage;

    public float chargeDelay;
}
