using UnityEngine;

[CreateAssetMenu(fileName = "LuckIncreaseEffect", menuName = "Perks/Luck Increase")]
public class LuckIncreaseEffect : PerkEffect
{
    public int bonusValue = 5;
    public override void Apply(PlayerStatsData stats)
    {
        if (stats != null)
        {
            stats.luck += bonusValue;
        }
    }
}
