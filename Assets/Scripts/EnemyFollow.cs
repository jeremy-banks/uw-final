using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;          // Reference to the player's transform
    public float moveSpeed = 3.0f;    // Speed at which the enemy moves
    public float rotationSpeed = 5.0f; // Speed at which the enemy rotates

    void Start()
    {
        // Find the player in the scene by searching for a GameObject with the "Player" tag
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("Player object with tag 'Player' not found.");
        }
    }

    void FixedUpdate()
    {
        // Move towards the player
        MoveTowardsPlayer();

        // Rotate to face the player
        FacePlayer();
    }

    void MoveTowardsPlayer()
    {
        // Calculate the direction to the player
        Vector3 direction = (player.position - transform.position).normalized;

        // Move the enemy in that direction
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    void FacePlayer()
    {
        // Calculate the direction to the player
        Vector3 direction = (player.position - transform.position).normalized;

        // Create a rotation that looks in the direction of the player
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        // Smoothly rotate towards the player
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
    }
}
