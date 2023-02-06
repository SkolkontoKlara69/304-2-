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
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        movement *= movingSpeed;

        rigidbody.MovePosition(transform.position + movement * Time.deltaTime);


    }

    public void TakeDamage(float damage)
    {
        healthPoints =- damage;
        Debug.Log("aj");
    }
}
