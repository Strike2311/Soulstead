using UnityEngine;
using System;

public class PlayerXP : MonoBehaviour
{
    public PlayerStatsData stats;
    
    [SerializeField] private AnimationCurve xpGrowthCurve;

    public event Action<int> OnLevelUp;

    private void Start()
    {
        stats.xpToNextLevel = GetXPRequirement(stats.level);
    }

    public void GainXP(int amount)
    {
        stats.xp += amount;

        while (stats.xp >= stats.xpToNextLevel)
        {
            stats.xp -= stats.xpToNextLevel;
            stats.level++;
            stats.xpToNextLevel = GetXPRequirement(stats.level);
            OnLevelUp?.Invoke(stats.level);
        }
    }

    int GetXPRequirement(int level)
    {
        return Mathf.RoundToInt(100 * Mathf.Pow(1.2f, level - 1));
        // Use Unity Curve if you want designer control
        // return Mathf.RoundToInt(xpGrowthCurve.Evaluate(level));
    }
}
