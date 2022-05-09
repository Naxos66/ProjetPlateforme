using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysicals1 : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 8f;
    public float gravity = -27f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask GroundMask;

    Vector3 velocity;
    bool isGrounded;
    void Start()
    {
        
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, GroundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = 12f;
        }
        else
        {
            speed = 8f;
        }

        if(Input.GetKey(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(1,0.6f,1);
            if(isGrounded)
            {
            speed = 4f;
            }
        }
        else
        {
            transform.localScale = new Vector3(1,1,1);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
    
    
}