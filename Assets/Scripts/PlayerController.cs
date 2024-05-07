using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerCOntroller : MonoBehaviour
{
    
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public float maxSpeed;

    private int desiredLane;  // 0 sol 1 orta 2 sağ
    public float laneDistance; // yollar arasındaki mesafe

    public float jumpForce;
    public float gravity=-20;

    public bool isGrounded;
    public LayerMask groundLayer;
    public Transform groundCheck;

    public Animator animator;

    private bool isSliding = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    void Update()
    {
        //increase speed
        if(forwardSpeed < maxSpeed)
        {
            forwardSpeed += 0.1f * Time.deltaTime;
        }
        
        direction.z = forwardSpeed;

        isGrounded = Physics.CheckSphere(groundCheck.position, 0.5f, groundLayer);           
        animator.SetBool("isGameStarted",true);

        animator.SetBool("isGorunded", isGrounded);

        if (controller.isGrounded) 
        {
            //direction.y = -2;
            if (Input.GetKeyDown(KeyCode.UpArrow)) 
              Jump();
        }
        else
        {
            direction.y += gravity * Time.deltaTime;
        }


        if (Input.GetKeyDown(KeyCode.DownArrow) && !isSliding)
        {
            StartCoroutine(Slide());
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane == 3)            
                desiredLane = 2;
            
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if (desiredLane == -1)            
                desiredLane = 0;
            
        }

        Vector3 targetPoisiton = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPoisiton += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPoisiton += Vector3.right * laneDistance;
        }

        transform.position = Vector3.Lerp(transform.position, targetPoisiton, 120);
        controller.center = controller.center;
    }

    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }

    void Jump()
    {
        isGrounded = false;
        direction.y = jumpForce;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
            Manager.gameOver = true;
    }

    private IEnumerator Slide()
    {
        isSliding = true;
        animator.SetBool("isSliding",true);
        controller.center = new Vector3(0, -0.5f, 0);
        controller.height = 1;

        yield return new WaitForSeconds(0.7f);

        controller.center = new Vector3(0, 0, 0);
        controller.height = 2;

        animator.SetBool("isSliding", false);
        isSliding = false;
    }
}
