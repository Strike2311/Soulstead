using UnityEngine;

[CreateAssetMenu(fileName = "DodgeIncreaseEffect", menuName = "Perks/Dodge Increase")]
public class DodgeIncreaseEffect : PerkEffect
{
    public int bonusValue = 5;
    public override void Apply(PlayerStatsData stats)
    {
        if (stats != null)
        {
            stats.dodge += bonusValue;
        }
    }
}
