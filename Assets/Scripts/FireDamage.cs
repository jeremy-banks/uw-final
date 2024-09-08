using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamage : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Check if the object that collided has a method named "Damage"
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

        // If object is player and damageable
        if (collision.gameObject.CompareTag("Player") && damageable != null)
        {
            // Call the Damage method on the damageable object
            damageable.Damage();
        }
    }
}
