using UnityEngine;

[CreateAssetMenu(fileName = "ArmourIncreaseEffect", menuName = "Perks/Armour Increase")]
public class ArmourIncreaseEffect : PerkEffect
{
    public int bonusValue = 5;

    public override void Apply(PlayerStatsData stats)
    {
        if (stats != null)
        {
            stats.armour += bonusValue;
        }
    }
}
