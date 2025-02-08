using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 400f;

    public Transform playerBody;
    public Transform flameShooter;


    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        flameShooter.transform.rotation = Quaternion.Euler(new Vector3(180, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        flameShooter.transform.localRotation = Quaternion.Euler(xRotation + 180, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}