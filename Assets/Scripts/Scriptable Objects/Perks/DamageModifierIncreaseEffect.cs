using UnityEngine;

[CreateAssetMenu(fileName = "DamageModifierIncreaseEffect", menuName = "Perks/Damage Modifier Increase")]
public class DamageModifierIncreaseEffect : PerkEffect
{
    public int bonusValue = 5;

    public override void Apply(PlayerStatsData stats)
    {
        if (stats != null)
        {
            stats.damageModifier += bonusValue;
        }
    }
}
