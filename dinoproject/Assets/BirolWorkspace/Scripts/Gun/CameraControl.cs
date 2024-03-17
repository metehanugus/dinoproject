using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // This script is used to control the camera's rotation.
    // The camera's rotation is controlled by the player's mouse or touch input.
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    public float lookYLimit = 45.0f;

    float rotationX = 0;
    float rotationY = 0;

    void Update()
    {
        // Player and Camera rotation for PC
        if (Input.GetMouseButton(0))
        {
            rotationX = rotationX + (-Input.GetAxis("Mouse Y") * lookSpeed);
            rotationY = rotationY + (Input.GetAxis("Mouse X") * lookSpeed);
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            rotationY = Mathf.Clamp(rotationY, -lookYLimit, lookYLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0);
        }
        // Player and Camera rotation for mobile devices
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                rotationX = rotationX + (-touch.deltaPosition.y * lookSpeed);
                rotationY = rotationY + (touch.deltaPosition.x * lookSpeed);
                rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
                rotationY = Mathf.Clamp(rotationY, -lookYLimit, lookYLimit);
                playerCamera.transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0);
            }
        }
    }
}
