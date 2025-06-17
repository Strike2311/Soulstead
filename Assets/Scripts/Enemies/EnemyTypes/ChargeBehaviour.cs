using System.Collections;
using UnityEngine;

public class ChargerBehaviour : EnemyBase
{
    private bool isCharging;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(ChargeCycle());
    }

    private IEnumerator ChargeCycle()
    {
        while (true)
        {
            isCharging = false;
            yield return new WaitForSeconds(stats.chargeDelay);

            isCharging = true;
            yield return new WaitForSeconds(0.5f); // charge duration
        }
    }

    protected override void HandleBehaviour()
    {
        if (player == null || !isCharging) return;
        Vector2 dir = (player.position - transform.position).normalized;
        transform.position += (Vector3)(dir * speed * Time.deltaTime * 2f);
    }
}