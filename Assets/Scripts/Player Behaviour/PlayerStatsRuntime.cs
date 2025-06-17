using UnityEngine;

public class PlayerStatsRuntime : MonoBehaviour
{
    [Header("Base Stats")]
    public PlayerStatsData baseStats;

    [Header("Runtime Stats")]
    public float currentHealth { get; private set; }
    public float armor => baseStats.armor;
    public float moveSpeed => baseStats.moveSpeed;
    public float damage => baseStats.damage;
    public float range => baseStats.range;

    [Header("External Objects")]
    public GameManager gameManagerObject;

    void Start()
    {
        gameManagerObject = GameObject.Find("Game Manager").GetComponent<GameManager>();
        currentHealth = baseStats.maxHealth;
    }

    public void TakeDamage(float amount)
    {
        float effectiveDamage = Mathf.Max(0, amount - armor);
        currentHealth -= effectiveDamage;
        Debug.Log($"Player took {effectiveDamage} damage. Health now: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, baseStats.maxHealth);
    }

    private void Die()
    {
        gameManagerObject.GameOver();
    }
}
