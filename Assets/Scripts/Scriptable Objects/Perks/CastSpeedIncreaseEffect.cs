using UnityEngine;

[CreateAssetMenu(fileName = "CastSpeedIncreaseEffect", menuName = "Perks/Cast Speed Increase")]
public class CastSpeedIncreaseEffect : PerkEffect
{
    public int bonusValue = 5;

    public override void Apply(PlayerStatsData stats)
    {
        if (stats != null)
        {
            stats.castSpeed += bonusValue;
        }
    }
}
