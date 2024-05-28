using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Unity.VisualScripting;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController Instance { get; private set; }
        [SerializeField] GameObject soruPaneli;
        private CharacterController controller;
        private Vector3 direction;
        public float forwardSpeed = 2;
        public float maxSpeed;

        private int desiredLane = 1; // 0 sol 1 orta 2 sağ
        public float laneDistance = 2; // yollar arasındaki mesafe

        public float jumpForce;
        public float gravity;

        public bool isGrounded;
        public LayerMask groundLayer;
        public Transform groundCheck;

        public Animator animator;

        private bool isSliding = false;
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        private void FixedUpdate()
        {
            controller.Move(direction * Time.fixedDeltaTime);
        }

        void Update()
        {
            animator.SetBool("isJumping", false);
            //increase speed
            if (forwardSpeed < maxSpeed)
            {
                forwardSpeed += 0.3f * Time.deltaTime;
            }

            direction.z = forwardSpeed;

            isGrounded = Physics.CheckSphere(groundCheck.position, 0.5f, groundLayer);
            //  animator.SetBool("isGameStarted", true);

            // animator.SetBool("isGorunded", isGrounded);

            if (controller.isGrounded)
            {
                direction.y = -1;
                if (Input.GetKey(KeyCode.Space))
                {
                    Jump();
                }
            }
            else
            {
                direction.y += gravity * Time.deltaTime; // Yer çekimi etkisi
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                //   animator.SetBool("Right", true);
                MoveLane(true);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                //  animator.SetBool("Left", true);
                MoveLane(false);
            }

            Vector3 targetPoisiton = transform.position.z * Vector3.forward;

            if (desiredLane == 0)
            {
                targetPoisiton += Vector3.left * laneDistance;
            }
            else if (desiredLane == 2)
            {
                targetPoisiton += Vector3.right * laneDistance;
            }

            Vector3 moveVector = Vector3.zero;
            moveVector.x = (targetPoisiton - transform.position).normalized.x * forwardSpeed;
            moveVector.y = -0.1f;
            moveVector.z = forwardSpeed;
            controller.Move(moveVector * Time.deltaTime);

            if (Input.GetKey(KeyCode.DownArrow) && !isSliding)
            {
                StartCoroutine(Slide());
            }
        }

        void MoveLane(bool goingRight)
        {
            desiredLane += goingRight ? 1 : -1;
            desiredLane = Mathf.Clamp(desiredLane, 0, 2);
        }

        void Jump()
        {
            animator.SetBool("isJumping", true);
            isGrounded = false;
            direction.y = jumpForce;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Obstacle"))
            {
                SoruPanelleri.Instance.soruSec();
                SoruPanelleri.secilecekSoru.SetActive(true);
                Time.timeScale = 0;
            }
        }

        private IEnumerator Slide()
        {
            isSliding = true;
            //     animator.SetBool("isSliding",true);
            controller.center = new Vector3(0, -0.5f, 0);
            controller.height = 1;

            yield return new WaitForSeconds(0.7f);

            controller.center = new Vector3(0, 0, 0);
            controller.height = 2;

            // animator.SetBool("isSliding", false);
            isSliding = false;
        }
    }
}