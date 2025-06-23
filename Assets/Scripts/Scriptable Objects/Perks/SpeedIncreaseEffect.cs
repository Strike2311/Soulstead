using UnityEngine;

[CreateAssetMenu(fileName = "SpeedIncreaseEffect", menuName = "Perks/Speed Increase")]
public class SpeedIncreaseEffect : PerkEffect
{
    public int bonusValue = 5;
    public override void Apply(PlayerStatsData stats)
    {
        if (stats != null)
        {
            stats.moveSpeed += bonusValue;
        }
    }
}
