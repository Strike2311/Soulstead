using UnityEngine;

[CreateAssetMenu(fileName = "CritDamageIncreaseEffect", menuName = "Perks/Crit Damage Increase")]
public class CritDamageIncreaseEffect : PerkEffect
{
    public int bonusValue = 5;

    public override void Apply(PlayerStatsData stats)
    {
        if (stats != null)
        {
            stats.critDamage += bonusValue;
        }
    }
}
