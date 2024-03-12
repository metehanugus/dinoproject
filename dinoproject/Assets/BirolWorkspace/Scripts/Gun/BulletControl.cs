using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    // What this script does is to control the bullet's damage and destruction.
    // The bullet prefab is a simple sphere with a collider component.
    // The bullet prefab is also destroyed after a certain amount of time.
    public float damage = 10f;
    public float bulletLife = 2.0f;

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to a target
        TargetControl target = other.gameObject.GetComponent<TargetControl>();

        // If it's a target, apply damage and destroy the bullet
        if (target != null)
        {
            target.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Destroy(gameObject, bulletLife);
    }
}

