using System.Collections;
using System.Collections.Generic;
using Soulstead.Interfaces;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerColliderHandler : MonoBehaviour
{
    private bool isDamageable = true;
    private SpriteRenderer playerSpriteRenderer;
    [SerializeField] private int flashCount = 3;
    [SerializeField] private float flashDuration = 0.1f;
    private Color flashColor = Color.red;

    void Awake()
    {
        playerSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (isDamageable && collision.CompareTag("Enemy"))
        {
            StartCoroutine(OnDamageTaken(collision.GetComponent<IDamageDealer>().GetDamage()));
            isDamageable = false;
        }
    }

    IEnumerator OnDamageTaken(float damage)
    {
        isDamageable = false;
        Color originalColor = playerSpriteRenderer.color;
        gameObject.GetComponent<PlayerStatsRuntime>().TakeDamage(damage);
        for (int i = 0; i < flashCount; i++)
        {
            playerSpriteRenderer.color = flashColor;
            yield return new WaitForSeconds(flashDuration);
            playerSpriteRenderer.color = originalColor;
            yield return new WaitForSeconds(flashDuration);
        }
        isDamageable = true;
    }
}
