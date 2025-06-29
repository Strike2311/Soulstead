using UnityEngine;

[CreateAssetMenu(fileName = "LifeStealIncreaseEffect", menuName = "Perks/Life Steal Increase")]
public class LifeStealIncreaseEffect : PerkEffect
{
    public float bonusValue = 0.01f;
    public override void Apply(PlayerStatsData stats)
    {
        if (stats != null)
        {
            stats.lifeSteal += bonusValue;
        }
    }
}
