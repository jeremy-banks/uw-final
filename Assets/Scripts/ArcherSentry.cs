using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherSentry : MonoBehaviour
{
    [SerializeField] GameObject projectileGO;
    Transform playerTransform;
    float shootingForce = 30.0f;
    float shootingCooldown;
    float shootingCooldownInitial = 1.0f;

    private void Start()
    {
        // Find the player in the scene by searching for a GameObject with the "Player" tag
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }

        shootingCooldown = shootingCooldownInitial;
    }

    void Update()
    {
        if (shootingCooldown > 0f)
        {
            shootingCooldown -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        if (shootingCooldown <= 0f)
        {
            shootingCooldown = shootingCooldownInitial;
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        // If player and projectile are valid
        if (playerTransform != null && projectileGO != null)
        {
            // Get the direction from the archer to the player
            Vector3 direction = (playerTransform.position - transform.position).normalized;

            // Calculate the spawn position for the projectile to be between the archer and the player
            Vector3 spawnPosition = transform.position + direction * 2.5f;

            // Instantiate the projectile at the calculated spawn position
            GameObject shotArrow = Instantiate(projectileGO, spawnPosition, Quaternion.identity);

            // Apply force to the projectile's Rigidbody
            Rigidbody rb = shotArrow.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(direction * shootingForce, ForceMode.Impulse);
            }

            Debug.Log($"Applied Force: {direction * shootingForce}");
            Debug.Log($"Initial Velocity: {rb.velocity}");

            // Destroy arrow after 3 seconds
            Destroy(shotArrow, 3.0f);
        }
    }
}
