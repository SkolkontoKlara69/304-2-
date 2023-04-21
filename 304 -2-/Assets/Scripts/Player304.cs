using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
public class Player304 : MonoBehaviour
{
    public float movingSpeed = 10f;
    public Vector3 position;

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

    bool readyToJump;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;

    bool isGrounded;
    public LayerMask whatIsGround;

    public KeyCode jumpKey = KeyCode.Space;

    public float groundDrag;

    public PauseManager pauseManager;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        position = transform.position;
        capsuleCollider = GetComponent<CapsuleCollider>();
        defaultColliderHeight = capsuleCollider.height;

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
            else
            {
                rigidbody.drag = 0;
            }

            isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

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

            if (Input.GetKey(jumpKey) && readyToJump == true /*&& isGrounded*/)
            {
                Jump();

                readyToJump = false;

                Invoke(nameof(ResetJump), jumpCooldown);
            }
        }
        
    }

    private void Jump()
    {
        rigidbody.velocity = new Vector3(rigidbody.velocity.x, jumpForce*Time.deltaTime, rigidbody.velocity.z);

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
