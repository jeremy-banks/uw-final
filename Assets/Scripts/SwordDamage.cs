using UnityEngine;
using System.Collections;

public class SwordDamage : MonoBehaviour
{
    Rigidbody rb;

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collision detected with: " + collision.gameObject.name);

        // Check if the object that collided has a method named "Damage"
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

        if (damageable != null)
        {
            //Debug.Log("Damageable object found: " + collision.gameObject.name);

            // Call the Damage method on the damageable object
            damageable.Damage();

            // Also add a little directional shove for effect
            rb = collision.rigidbody;
            if (rb != null)
            {
                Debug.Log("rb is not null");
                // Calculate direction to push the object away from the player
                Vector3 pushDirection = (collision.transform.position - transform.position).normalized;

                // Apply that force
                rb.AddForce(pushDirection * 300f, ForceMode.Impulse);

                // Stop the force (otherwise object just floats away)
                StartCoroutine(StopVelocityCoroutine());
            }
        }
        else
        {
            Debug.Log("No IDamageable component found on: " + collision.gameObject.name);
        }
    }

    IEnumerator StopVelocityCoroutine()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(0.1f);

        // Stop the object's velocity
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}

// Define an interface for objects that can be damaged
public interface IDamageable
{
    void Damage();
}
