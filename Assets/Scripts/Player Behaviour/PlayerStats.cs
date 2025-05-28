using UnityEngine;
using Soulstead.Interfaces;
public class PlayerStats : MonoBehaviour, IDamageable
{

    [Header("Health")]
    [SerializeField] public int currentHealth;
    [SerializeField] public int maxHealth = 100;

    [Header("Stamina")]
    [SerializeField] public int currentStamina;
    [SerializeField] public int maxStamina = 100;
    void Awake()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;
    }

    void Update()
    {

    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    public void Die()
    {
        Debug.Log("Player died!");
    }
}
