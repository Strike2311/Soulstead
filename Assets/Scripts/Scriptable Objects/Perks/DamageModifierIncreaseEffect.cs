using UnityEngine;

[CreateAssetMenu(fileName = "DamageModifierIncreaseEffect", menuName = "Perks/Damage Modifier Increase")]
public class DamageModifierIncreaseEffect : PerkEffect
{
    public float bonusValue = 0.05f;

    public override void Apply(PlayerStatsData stats)
    {
        if (stats != null)
        {
            stats.damageModifier += bonusValue;
        }
    }
}
