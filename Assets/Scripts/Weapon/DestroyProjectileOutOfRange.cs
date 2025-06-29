using System;
using UnityEngine;

public class DestroyProjectileOutOfRange : MonoBehaviour
{
    private GameObject player;
    private float range = 30f;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        Vector2 playerLocation = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 bulletLocation = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        if (Math.Abs(Vector2.Distance(bulletLocation, playerLocation)) > range) {
            Destroy(gameObject);
        }
    }
}
