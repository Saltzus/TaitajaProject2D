using UnityEngine;

public class swing : MonoBehaviour
{
    public int damageAmount = 10; // Adjust this value as needed

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision is with an enemy (you might need to adjust the tag)
        if (collision.gameObject.CompareTag("Player")) return;
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            Debug.Log("Collision with Enemy detected");

            // Apply damage to the enemy
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();

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
