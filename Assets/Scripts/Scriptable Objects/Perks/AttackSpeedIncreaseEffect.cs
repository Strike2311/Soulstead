using UnityEngine;

[CreateAssetMenu(fileName = "AttackSpeedIncreaseEffect", menuName = "Perks/Attack Speed Increase")]
public class AttackSpeedIncreaseEffect : PerkEffect
{
    public float bonusValue = 0.05f;

    public override void Apply(PlayerStatsData stats)
    {
        if (stats != null)
        {
            stats.attackSpeed += bonusValue;
        }
    }
}
