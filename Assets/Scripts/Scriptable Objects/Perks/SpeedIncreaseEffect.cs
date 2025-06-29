using UnityEngine;

[CreateAssetMenu(fileName = "SpeedIncreaseEffect", menuName = "Perks/Speed Increase")]
public class SpeedIncreaseEffect : PerkEffect
{
    public float bonusValue = 0.05f;
    public override void Apply(PlayerStatsData stats)
    {
        if (stats != null)
        {
            stats.moveSpeed += bonusValue;
        }
    }
}
