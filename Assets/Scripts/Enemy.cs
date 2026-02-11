using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();

        if (player != null)
        {
            player.TakeDamage(damage); // Reduce player health
            Destroy(gameObject); // Remove enemy
        }
    }

    void Update()
    {
        // Destroy if off-screen
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}