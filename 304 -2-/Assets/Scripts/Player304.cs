using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

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
<<<<<<< Updated upstream
    
    public float sensitivity;

    Vector3 moveDirection;

=======

    public float sensitivity;

    Vector3 moveDirection;

>>>>>>> Stashed changes
    public Transform orientation;

    /*
    public float playerHeight;

    bool readyToJump;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool isGrounded;
    public LayerMask whatIsGround;

    public KeyCode jumpKey = KeyCode.Space;

    public float groundDrag;
    */

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        position = transform.position;
        capsuleCollider = GetComponent<CapsuleCollider>();
        defaultColliderHeight = capsuleCollider.height;
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    public void TakeDamage(float damage)
    {
        healthPoints = -damage;
        Debug.Log("aj");
    }
}
