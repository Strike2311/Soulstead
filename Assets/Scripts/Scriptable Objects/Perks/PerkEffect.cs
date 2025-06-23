using UnityEngine;

public abstract class PerkEffect : ScriptableObject
{
    public abstract void Apply(PlayerStatsData stats);
}
