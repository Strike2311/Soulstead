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
    [SerializeField] private PlayerStatsData playerStats; 
    [SerializeField] private PlayerXP playerXP; 
    private Color flashColor = Color.red;

    void Awake()
    {
        playerXP = gameObject.GetComponent<PlayerXP>();
        playerSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        playerXP.OnLevelUp += HandleLevelUp;
    }

    void HandleLevelUp(int newLevel)
    {
        Debug.Log("Player Level Up");
    }
    void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (isDamageable && collision.CompareTag("Enemy"))
        {
            StartCoroutine(OnDamageTaken(collision.GetComponent<IDamageDealer>().GetDamage()));
            isDamageable = false;
        }

        if (collision.CompareTag("Pickup_XP"))
        {
            Debug.Log("Picked Up");
            playerXP.GainXP(collision.GetComponent<PickupXP>().xp);
            Destroy(collision.gameObject);
        }

        /*if (collision.CompareTag("Pickup_HP"))
        {

            Destroy(collision);
        }*/
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
