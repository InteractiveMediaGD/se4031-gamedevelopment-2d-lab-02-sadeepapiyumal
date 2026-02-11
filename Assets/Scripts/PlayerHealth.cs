using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public TMP_Text healthText;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateUI();
    }

    // This method allows Enemy.cs to damage the player
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth < 0)
            currentHealth = 0;

        UpdateUI();

        if (currentHealth == 0)
            Time.timeScale = 0f; // Stop game when player dies
    }

    void UpdateUI()
    {
        if (healthText != null)
            healthText.text = "Health: " + currentHealth;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            TakeDamage(10); // Use the same method
        }
    }
}