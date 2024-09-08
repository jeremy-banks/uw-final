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

            // Calculate the spawn position for the projectile
            Vector3 spawnPosition = transform.position + direction * 2.5f;

            // Calculate the rotation needed to face the direction
            Quaternion rotation = Quaternion.LookRotation(direction);

            // Instantiate the projectile at the calculated spawn position and with the correct rotation
            GameObject shotArrow = Instantiate(projectileGO, spawnPosition, rotation);

            // Apply force to the projectile's Rigidbody
            Rigidbody rb = shotArrow.GetComponent<Rigidbody>();
            rb.AddForce(direction * shootingForce, ForceMode.Impulse);

            // Destroy arrow after 5 seconds
            Destroy(shotArrow, 5.0f);
        }
    }
}
