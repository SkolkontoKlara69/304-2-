using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class LookAround : MonoBehaviour
{
    public float sensX;
    public float sensY;
    public float fov;
    public float zoomFov;

    public Transform orientation;

    float xRotation;
    float yRotation;

    public PauseManager pauseManager;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (pauseManager.paused == false)
        { 
            // get mouse input

            float mouseX = Input.GetAxisRaw("Mouse X") * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * sensY;

            yRotation += mouseX;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90);

            // rotate cam and orientation
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);

            
        }
    }
    
}