using UnityEngine;

[CreateAssetMenu(fileName = "DodgeIncreaseEffect", menuName = "Perks/Dodge Increase")]
public class DodgeIncreaseEffect : PerkEffect
{
    public float bonusValue = 0.05f;
    public override void Apply(PlayerStatsData stats)
    {
        if (stats != null)
        {
            stats.dodge += bonusValue;
        }
    }
}
