using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GunControl : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 30.0f;
    public float bulletLife = 2.0f;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;
    private bool isZoomedIn = false;

    void Update()
{
    // For PC
    if (Input.GetMouseButton(0)) // If left mouse button is held down
{
    Vector3 position;

    // Check if it's a touch device
    if (Input.touchSupported)
    {
        // If there's a touch, get the touch position
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            position = touch.position;
        }
        else
        {
            return; // If there's no touch, exit the method
        }
        }
    else
    {
        // If it's not a touch device, get the mouse position
        position = Input.mousePosition;
    }

    // Convert the position to world coordinates
    position = Camera.main.ScreenToWorldPoint(new Vector3(position.x, position.y, Camera.main.transform.position.y));

    // Calculate the direction from the gun to the position
    Vector3 direction = position - transform.position;

    // Calculate the rotation needed to point the gun at the position
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

    // Apply the rotation to the gun
    transform.rotation = Quaternion.Euler(new Vector3(0, -angle, 0));
}

    else if (Input.GetMouseButtonUp(0) && Time.time > nextFire) // If left mouse button is released
    {
        nextFire = Time.time + fireRate;
        Fire();
    }

    // For mobile devices
    if (Input.touchCount > 0)
    {
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
        {
            // Control the direction of guns
        }
        else if (touch.phase == TouchPhase.Ended && Time.time > nextFire)
        {
            // Check if the touch is over a UI element
            if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                // If the touch is over the "Zoom" image, toggle zoom
                if (isZoomedIn)
                {
                    ZoomOut();
                }
                else
                {
                    ZoomIn();
                }
                isZoomedIn = !isZoomedIn;
            }
            else
            {
                // If the touch is not over a UI element, fire
                nextFire = Time.time + fireRate;
                Fire();
            }
        }
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
            rb.useGravity = false;
        }

        rb.velocity = bullet.transform.forward * bulletSpeed;

        Destroy(bullet, bulletLife);
    }

    public void ZoomIn()
    {
        Camera.main.fieldOfView = Mathf.Max(Camera.main.fieldOfView - 5, 20);
    }

    public void ZoomOut()
    {
        Camera.main.fieldOfView = Mathf.Min(Camera.main.fieldOfView + 5, 60);
    }
}
