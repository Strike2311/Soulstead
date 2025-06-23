using UnityEngine;

[CreateAssetMenu(fileName = "LifeStealIncreaseEffect", menuName = "Perks/Life Steal Increase")]
public class LifeStealIncreaseEffect : PerkEffect
{
    public int bonusValue = 5;
    public override void Apply(PlayerStatsData stats)
    {
        if (stats != null)
        {
            stats.lifeSteal += bonusValue;
        }
    }
}
