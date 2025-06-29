using UnityEngine;

[CreateAssetMenu(fileName = "CritDamageIncreaseEffect", menuName = "Perks/Crit Damage Increase")]
public class CritDamageIncreaseEffect : PerkEffect
{
    public float bonusValue = 0.05f;

    public override void Apply(PlayerStatsData stats)
    {
        if (stats != null)
        {
            stats.critDamage += bonusValue;
        }
    }
}
