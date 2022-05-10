using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysicals1 : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 8f;
    public float gravity = -27f;
    public float jumpHeight = 3f;
    public int maxJumpCount = 1;
    public int jumpRemaning = 0;
    public bool dblJump = false;
    public bool noJump = false;

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
            jumpRemaning = maxJumpCount;
        }
        
        if(!isGrounded && dblJump == false)
        {
            maxJumpCount = 0;
            jumpRemaning = maxJumpCount;
        }
        else
        {
            if(dblJump == false)
            {
                maxJumpCount = 1;
            }
        }

        if(!isGrounded && dblJump == true)
        {
            if(noJump == false)
            {
                maxJumpCount = 1;
                jumpRemaning = maxJumpCount;
                noJump = true;
            }
        }
        else
        {
            if(dblJump == true)
            {
                maxJumpCount = 2;
                noJump = false;
            }
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump"))
        {
            if((jumpRemaning > 0))
            {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            jumpRemaning -= 1;
            }
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = 12f;
        }
        else
        {
            if(isGrounded)
            {
            speed = 8f;
            }
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

    private void OnTriggerEnter(Collider other) {
        
        if(other.CompareTag("BonusJump"))
        {
            maxJumpCount = 2;
            dblJump = true;
        }  
        
    }
    
    
}