using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player304 : MonoBehaviour
{

    public float movingSpeed = 10f;
    public Vector3 position;

    //public Transform transform;
    public Rigidbody rigidbody;
    private MeshCollider meshCollider;
    public float defaultColliderHeight;
    public float healthPoints;

   



    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        position = transform.position;
<<<<<<< Updated upstream
        meshCollider = GetComponent<MeshCollider>();
        //defaultColliderHeight = meshCollider.height;
=======
        capsuleCollider = GetComponent<CapsuleCollider>();
        defaultColliderHeight = capsuleCollider.height;

        isGrounded = true;

>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
=======
        

        if (isGrounded == true)
        {
            rigidbody.drag = groundDrag;
        }
        else
        {
            rigidbody.drag = 0;
        }

        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

>>>>>>> Stashed changes
        //WASD
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        movement *= movingSpeed;

        rigidbody.MovePosition(transform.position + movement * Time.deltaTime);


<<<<<<< Updated upstream
=======
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
>>>>>>> Stashed changes
    }

    public void TakeDamage(float damage)
    {
        healthPoints =- damage;
        Debug.Log("aj");
    }
}
