using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public float mouseSens = 100f;
    public Transform player;
    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   
    }

    // Update is called once per frame
    void Update()
    {
        MouseLook();
    }
    private void MouseLook()
    {
        float mouseX = Input.GetAxisRaw(InputMovement.MOUSE_X) * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxisRaw(InputMovement.MOUSE_Y) * mouseSens * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    }
}
