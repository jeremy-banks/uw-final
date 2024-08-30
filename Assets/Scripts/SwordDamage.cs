using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Trigger detected with: " + other.gameObject.name);

        // Check if the object that entered the trigger has a method named "Damage"
        IDamageable damageable = other.gameObject.GetComponent<IDamageable>();

        if (damageable != null)
        {
            //Debug.Log("Damageable object found: " + other.gameObject.name);
            // Call the Damage method on the damageable object
            damageable.Damage();
        }
        //else
        //{
        //    Debug.Log("No IDamageable component found on: " + other.gameObject.name);
        //}
    }
}

// Define an interface for objects that can be damaged
public interface IDamageable
{
    void Damage();
}
