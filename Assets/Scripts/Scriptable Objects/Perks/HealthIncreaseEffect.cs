using UnityEngine;

[CreateAssetMenu(fileName = "HealthIncreaseEffect", menuName = "Perks/Health Increase")]
public class HealthIncreaseEffect : PerkEffect
{
    public float bonusValue = 5;
    public override void Apply(PlayerStatsData stats)
    {
        if (stats != null)
        {
            stats.maxHealth += bonusValue;
        }
    }
}
