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

        meshCollider = GetComponent<MeshCollider>();
        //defaultColliderHeight = meshCollider.height;
        capsuleCollider = GetComponent<CapsuleCollider>();
        defaultColliderHeight = capsuleCollider.height;

        isGrounded = true;

         9979cc0 (Hp screen)

 Updated upstream
 c7f9cd0 (Revert "Revert "Hp screen"")
        meshCollider = GetComponent<MeshCollider>();
        //defaultColliderHeight = meshCollider.height;

        capsuleCollider = GetComponent<CapsuleCollider>();
        defaultColliderHeight = capsuleCollider.height;

        isGrounded = true;

 Stashed changes
        meshCollider = GetComponent<MeshCollider>();
        //defaultColliderHeight = meshCollider.height;
    }

    // Update is called once per frame
    void Update()
    {
 HEAD

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

 Updated upstream

 c7f9cd0 (Revert "Revert "Hp screen"")
        

        if (isGrounded == true)
        {
            rigidbody.drag = groundDrag;
        }
        else
        {
            rigidbody.drag = 0;
        }

        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

 HEAD

 Stashed changes
 c7f9cd0 (Revert "Revert "Hp screen"")
        //WASD
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
 9979cc0 (Hp screen)

            isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

            //WASD
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

            movement *= movingSpeed;


 HEAD
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
        


 Updated upstream

 c7f9cd0 (Revert "Revert "Hp screen"")
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

    private void Jump()
    {
        rigidbody.velocity = new Vector3(rigidbody.velocity.x, jumpForce*Time.deltaTime, rigidbody.velocity.z);

        rigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
 HEAD
        9979cc0 (Hp screen)

 Stashed changes
 c7f9cd0 (Revert "Revert "Hp screen"")
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
