using UnityEngine;

public class HandGun : WeaponBase
{
    protected override void FireAt(Transform target)
    {
        base.FireAt(target);
        // Could add custom recoil or animation here
    }
}
