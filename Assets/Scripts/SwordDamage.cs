using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        // Check if the collided object has a method named "Damage"
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

        if (damageable != null)
        {
            Debug.Log("Damageable object found: " + collision.gameObject.name);
            // Call the Damage method on the damageable object
            damageable.Damage();
        }
        else
        {
            Debug.Log("No IDamageable component found on: " + collision.gameObject.name);
        }
    }
}

// Define an interface for objects that can be damaged
public interface IDamageable
{
    void Damage();
}
