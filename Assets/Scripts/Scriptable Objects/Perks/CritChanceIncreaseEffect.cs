using UnityEngine;

[CreateAssetMenu(fileName = "CritChanceIncreaseEffect", menuName = "Perks/Crit Chance Increase")]
public class CritChanceIncreaseEffect : PerkEffect
{
    public int bonusValue = 5;

    public override void Apply(PlayerStatsData stats)
    {
        if (stats != null)
        {
            stats.critChance += bonusValue;
        }
    }
}
