using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlee : MonoBehaviour
{
    Transform player;          // Reference to the player's transform
    float moveSpeed = 3.0f;    // Speed at which the enemy moves
    float detectionRadius = 5.0f; // We run away if player gets closer than this
    bool playerIsClose = false;

    void Start()
    {
        // Find the player in the scene by searching for a GameObject with the "Player" tag
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if player is x close to them
        if (Vector3.Distance(transform.position, player.position) < detectionRadius)
        {
            // Player is close
            playerIsClose = true;
        }
    }

    void FixedUpdate()
    {
        if (playerIsClose) // If player is close
        {
            MoveAwayFromPlayer(); // Move away from the player
        }
    }

    void MoveAwayFromPlayer()
    {
        // Calculate the direction away from the player
        Vector3 direction = (transform.position - player.position).normalized;

        // Move the enemy in that direction
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
