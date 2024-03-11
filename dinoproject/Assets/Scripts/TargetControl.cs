using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetControl : MonoBehaviour
{
    // What this script does is to control the target's health and destruction.
    // The target prefab is a simple cube with a collider component.
    // The target prefab is also destroyed after a certain amount of time.
    public float health = 50f;
    public void TakeDamage(float amount)
    {
        // Ensure damage is non-negative
        if (amount < 0)
        {
            Debug.LogWarning("Negative damage value applied. Make sure to use non-negative damage values.");
            return;
        }

        health = health - amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
