using System.Numerics;
using UnityEngine;

public class RushBehaviour : EnemyBase
{
    protected override void Start()
    {
        base.Start(); // this sets the player reference
        health = stats.health;
        armor = stats.armor;
        speed = stats.speed;
        damage = stats.damage;
    }
    protected override void HandleBehaviour()
    {
        UnityEngine.Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }
}