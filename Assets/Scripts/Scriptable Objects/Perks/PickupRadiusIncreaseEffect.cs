using UnityEngine;

[CreateAssetMenu(fileName = "PickupRadiusIncreaseEffect", menuName = "Perks/Pickup Radius Increase")]
public class PickupRadiusIncreaseEffect : PerkEffect
{
    public float bonusValue = 0.05f;
    public override void Apply(PlayerStatsData stats)
    {
        if (stats != null)
        {
            stats.pickupRadius += bonusValue;
        }
    }
}
