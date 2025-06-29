using UnityEngine;

[CreateAssetMenu(fileName = "CastSpeedIncreaseEffect", menuName = "Perks/Cast Speed Increase")]
public class CastSpeedIncreaseEffect : PerkEffect
{
    public float bonusValue = 0.05f;

    public override void Apply(PlayerStatsData stats)
    {
        if (stats != null)
        {
            stats.castSpeed += bonusValue;
        }
    }
}
