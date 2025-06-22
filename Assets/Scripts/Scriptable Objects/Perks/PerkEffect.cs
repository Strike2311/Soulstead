using UnityEngine;

public abstract class PerkEffect : ScriptableObject
{
    public PlayerStatsData stats;
    public abstract void Apply(PlayerStatsData stats);
}
