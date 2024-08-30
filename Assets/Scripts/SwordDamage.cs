using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has a method named "Damage"
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

        if (damageable != null)
        {
            // Call the Damage method on the damageable object
            damageable.Damage();
        }
    }
}

// Define an interface for objects that can be damaged
public interface IDamageable
{
    void Damage();
}
