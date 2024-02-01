using UnityEngine;

public class Swing : MonoBehaviour
{
    public int damageAmount = 10; // Adjust this value as needed

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision detected");

        // Check if the collision is with an enemy (you might need to adjust the tag)
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collision with Enemy detected");

            // Apply damage to the enemy
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageAmount);
                Debug.Log("Dealing damage to enemy.");
            }
            else
            {
                Debug.LogWarning("Enemy does not have EnemyHealth script.");
            }
        }
        else
        {
            Debug.Log("Collision with non-enemy object. Destroying gameObject.");
            Destroy(gameObject);
        }
    }
}
