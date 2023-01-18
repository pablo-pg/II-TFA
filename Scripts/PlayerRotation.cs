using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public Transform cam;

    float mouseX;
    float mouseY;
    float yReal = 0.0f;

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        yReal -= mouseY;  // si no gira al revés
        
        yReal = Mathf.Clamp(yReal, -90f, 90f); // limites de rotacion
        cam.localRotation = Quaternion.Euler(yReal, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
