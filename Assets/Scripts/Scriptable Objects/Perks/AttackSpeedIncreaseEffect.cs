using UnityEngine;

[CreateAssetMenu(fileName = "AttackSpeedIncreaseEffect", menuName = "Perks/Attack Speed Increase")]
public class AttackSpeedIncreaseEffect : PerkEffect
{
    public int bonusValue = 5;

    public override void Apply(PlayerStatsData stats)
    {
        if (stats != null)
        {
            stats.attackSpeed += bonusValue;
        }
    }
}
