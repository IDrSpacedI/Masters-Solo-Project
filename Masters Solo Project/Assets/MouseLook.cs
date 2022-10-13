using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //swaps mouse sensitivity 
    public float MouseSensitvity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    //locks cursor to middle and hides it
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    //allows movement of mouse to look around correctly
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitvity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitvity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
