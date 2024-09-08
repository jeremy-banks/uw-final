using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherSentry : MonoBehaviour
{
    [SerializeField] GameObject projectileGO;
    Transform playerTransform;
    float shootingForce = 300f;
    private void Start()
    {
        // Find the player in the scene by searching for a GameObject with the "Player" tag
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }

        ShootProjectile();
    }
    void ShootProjectile()
    {
        // If player and projectile are valid
        if (playerTransform != null && projectileGO != null)
        {
            // Get the direction from the archer to the player
            Vector3 direction = (playerTransform.position - transform.position).normalized;

            // Instantiate the projectile at the archer's position and rotation
            GameObject shotArrow = Instantiate(projectileGO, (transform.position + new Vector3(3f, 0f, 0f)), Quaternion.identity);

            // Apply force to the projectile's Rigidbody
            Rigidbody rb = shotArrow.GetComponent<Rigidbody>();
            rb.AddForce(direction * shootingForce, ForceMode.Impulse);
        }
    }
}
