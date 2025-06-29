using UnityEngine;

[CreateAssetMenu(fileName = "CritChanceIncreaseEffect", menuName = "Perks/Crit Chance Increase")]
public class CritChanceIncreaseEffect : PerkEffect
{
    public float bonusValue = 0.05f;

    public override void Apply(PlayerStatsData stats)
    {
        if (stats != null)
        {
            stats.critChance += bonusValue;
        }
    }
}
