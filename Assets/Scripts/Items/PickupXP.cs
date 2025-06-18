using UnityEngine;

public class PickupXP : MonoBehaviour
{
    public PickupXPStats stats;
    public int xp { get; private set; }

    void Start()
    {
        xp = stats.xp;
    }
}
