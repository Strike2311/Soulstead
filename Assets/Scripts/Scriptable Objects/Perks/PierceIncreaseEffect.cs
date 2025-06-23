using UnityEngine;

[CreateAssetMenu(fileName = "PierceIncreaseEffect", menuName = "Perks/Pierce Increase")]
public class SpeedInPierceIncreaseEffectcreaseEffect : PerkEffect
{
    public int bonusValue = 5;
    public override void Apply(PlayerStatsData stats)
    {
        if (stats != null)
        {
            stats.pierce += bonusValue;
        }
    }
}
