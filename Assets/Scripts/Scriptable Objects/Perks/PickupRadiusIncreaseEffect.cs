using UnityEngine;

[CreateAssetMenu(fileName = "PickupRadiusIncreaseEffect", menuName = "Perks/Pickup Radius Increase")]
public class PickupRadiusIncreaseEffect : PerkEffect
{
    public int bonusValue = 5;
    public override void Apply(PlayerStatsData stats)
    {
        if (stats != null)
        {
            stats.pickupRadius += bonusValue;
        }
    }
}
