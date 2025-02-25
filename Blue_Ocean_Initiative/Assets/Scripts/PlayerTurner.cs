using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurner : MonoBehaviour
{
    public float rotateSpeedX = 400f;
    public float rotateSpeedY = 400f;
    public Transform orientation;

    private float xRotation = 0f;
    private float yRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * rotateSpeedX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * rotateSpeedY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        orientation.rotation = Quaternion.Euler(0f, yRotation, 0f);
    }
}
