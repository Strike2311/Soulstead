using UnityEngine;

[CreateAssetMenu(menuName = "Perks/Perk")]
public class Perk : ScriptableObject
{
    public string perkName;
    public string description;
    public Sprite icon;
    public PerkEffect effect;

    public void Apply(PlayerStatsData stats)
    {
        effect.Apply(stats);
    }
}