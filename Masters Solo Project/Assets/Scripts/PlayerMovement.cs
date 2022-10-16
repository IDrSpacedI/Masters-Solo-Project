using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region
    public static Transform instance;

    private void Awake()
    {
        instance = this.transform;
    }
    #endregion

    //character controller
    public CharacterController controller;

    //player changable stats
    public float speed = 12f;
    public float gravity = -9.81f;

    //ground check for jumping
    public Transform groundcheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    //sets up player movement
    [System.Obsolete]
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
}
