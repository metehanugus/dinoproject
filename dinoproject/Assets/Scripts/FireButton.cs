using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireButton : MonoBehaviour
{
    //If user press the fire button, the gun will fire a bullet.
    public GunControl gunControl;
    public void Fire()
    {
        gunControl.Fire();
    }
    void Start()
{
    // Try to get GunControl component from the same GameObject first
    gunControl = GetComponent<GunControl>();

    // If gunControl is still null, try getting it from the parent GameObject
    if (gunControl == null)
    {
        gunControl = GetComponentInParent<GunControl>();
    }

    // If gunControl is still null, log a warning
    if (gunControl == null)
    {
        Debug.LogWarning("GunControl component not found in FireButton or its parent.");
    }
}

}
