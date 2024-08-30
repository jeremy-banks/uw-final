using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    Rigidbody rb;
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Trigger detected with: " + other.gameObject.name);

        // Check if the object that entered the trigger has a method named "Damage"
        IDamageable damageable = other.gameObject.GetComponent<IDamageable>();

        if (damageable != null)
        {
            //Debug.Log("Damageable object found: " + other.gameObject.name);

            // Call the Damage method on the damageable object
            damageable.Damage();

            // Also add a little directional shove for effect
            rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Debug.Log("rb is not null");
                // Calculate direction to push the object away from the player
                Vector3 pushDirection = (other.transform.position - transform.position).normalized;

                // Apply that force
                rb.AddForce(pushDirection * 2f, ForceMode.Impulse);

                // Stop velocity after 1s otherwise enemy floats until acted upon by another force
                Invoke("StopVelocity", 0.5f);
            }
        }
        //else
        //{
        //    Debug.Log("No IDamageable component found on: " + other.gameObject.name);
        //}
    }

    void StopVelocity()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}

// Define an interface for objects that can be damaged
public interface IDamageable
{
    void Damage();
}
