using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
public class Player304 : MonoBehaviour
{
    public float movingSpeed = 10f;
    public Vector3 position;
    public Vector3 jump;

    //public Transform transform;
    public Rigidbody rigidbody;
    private CapsuleCollider capsuleCollider;
    private float defaultColliderHeight;
    public float healthPoints;

    float rotationX = -90f;
    float rotationY = 0f;

    public float sensitivity;

    Vector3 moveDirection;

    public Transform orientation;

    public float playerHeight;

    public float speed;

    bool readyToJump;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public bool isJumping = false;

    bool isGrounded;
    public LayerMask whatIsGround;

    public KeyCode jumpKey = KeyCode.Space;

    public float groundDrag;

    public float sprintSpeed;
    public float sprintMultiplier;
    public float normalSpeed;
    public PauseManager pauseManager;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        position = transform.position;
        capsuleCollider = GetComponent<CapsuleCollider>();
        defaultColliderHeight = capsuleCollider.height;

        Physics.gravity = new Vector3(0, -30f, 0);

        //isGrounded = true;
        jump = new Vector3(0.0f, 2.0f, 0.0f);

        sprintSpeed = movingSpeed + sprintMultiplier;
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseManager.paused == false)
        {
            if (isGrounded == true)
            {
                rigidbody.drag = groundDrag;
            }
            /*else
            {
                rigidbody.drag = 0;
            }*/
            //isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rigidbody.AddForce(jump * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }

            //WASD
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

            movement *= movingSpeed;

            rigidbody.MovePosition(transform.position + movement * Time.deltaTime);

            rotationY += Input.GetAxis("Mouse X") * sensitivity;
            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);

            Vector3 playerDirection = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);

            moveDirection = orientation.forward.normalized * verticalInput + orientation.right * horizontalInput;

            rigidbody.AddForce(moveDirection.normalized * movingSpeed * 10f, ForceMode.Force);

            if (isGrounded == true)
            {
                rigidbody.AddForce(moveDirection.normalized * movingSpeed * 10f, ForceMode.Force);
            }
            else if (isGrounded == false)
            {
                rigidbody.AddForce(moveDirection.normalized * movingSpeed * 10f * airMultiplier, ForceMode.Force);
            }

            if(Input.GetKey(KeyCode.LeftShift) && isGrounded)
            {
                movingSpeed = sprintSpeed;
            }
            else
            {
                movingSpeed = normalSpeed;
            }

            /*if (Input.GetKey(jumpKey) && readyToJump == true && isGrounded)
            {
                Jump();

                readyToJump = false;

                Invoke(nameof(ResetJump), jumpCooldown);
            }*/
        }
    }
        
    private void Jump()
    {
        if (isJumping && Time.deltaTime >= jumpCooldown)
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, 5f, rigidbody.velocity.z);
            isJumping = true;
            //StartCoroutine(ResetJump());
        }

        rigidbody.velocity = new Vector3(rigidbody.velocity.x, jumpForce * Time.deltaTime, rigidbody.velocity.z);

        rigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    public void TakeDamage(float damage)
    { 
        healthPoints = -damage;
        Debug.Log("aj");
    }

    private void OnTriggerEnter(Collider other)
    {
        isGrounded = true;
    }
}
