using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    // What this script does is to control the gun's firing rate and bullet speed.
    // It also instantiates the bullet prefab and sets its velocity.
    // The bullet prefab is a simple sphere with a rigidbody component.
    // The bullet prefab is also destroyed after a certain amount of time.
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 30.0f;
    public float bulletLife = 2.0f;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Fire();
        }
    }

    public void Fire()
    {
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        // Add Rigidbody component if not already attached
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = bullet.AddComponent<Rigidbody>();
        }

        rb.velocity = bullet.transform.forward * bulletSpeed;

        Destroy(bullet, bulletLife);
    }
}
