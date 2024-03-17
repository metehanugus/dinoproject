using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f; // Yatay rotasyon limiti
    public float lookYLimit = 45.0f; // Dikey rotasyon limiti

    private float rotationX = 0;
    private float rotationY = 0;
    private float initialRotationY; // Başlangıç Y rotasyonu

    void Start()
    {
        // Objeyi yerleştirdiğimiz başlangıç rotasyonunu kaydet
        initialRotationY = transform.eulerAngles.y;
        rotationY = initialRotationY; // Başlangıç rotasyonunu kullanarak rotasyonY'yi ayarla
    }

    void Update()
    {
        // Player ve Kamera rotasyonu için PC
        if (Input.GetMouseButton(0))
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationY += Input.GetAxis("Mouse X") * lookSpeed;

            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);

            // Yatay rotasyon limitlerini dinamik olarak ayarla
            float adjustedRotationY = Mathf.Clamp(rotationY - initialRotationY, -lookYLimit, lookYLimit) + initialRotationY;
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, adjustedRotationY, 0);
        }

        // Player ve Kamera rotasyonu için mobil cihazlar
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                rotationX += -touch.deltaPosition.y * lookSpeed;
                rotationY += touch.deltaPosition.x * lookSpeed;

                rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);

                // Yatay rotasyon limitlerini dinamik olarak ayarla
                float adjustedRotationY = Mathf.Clamp(rotationY - initialRotationY, -lookYLimit, lookYLimit) + initialRotationY;
                playerCamera.transform.localRotation = Quaternion.Euler(rotationX, adjustedRotationY, 0);
            }
        }
    }
}
