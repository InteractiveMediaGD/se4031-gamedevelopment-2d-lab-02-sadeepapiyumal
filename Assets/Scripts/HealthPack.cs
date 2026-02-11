using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public int healAmount = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();

        if (player != null)
        {
            // Increase health but do not exceed max
            player.currentHealth = Mathf.Min(player.currentHealth + healAmount, player.maxHealth);
            player.SendMessage("UpdateUI"); // Update Health UI
            Destroy(gameObject); // Remove health pack
        }
    }

    void Update()
    {
        // Destroy if it moves off-screen
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}