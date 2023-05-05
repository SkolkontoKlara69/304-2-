using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testRB : MonoBehaviour
{
    public Rigidbody rb;

    public float xforse;
    public float yforse;
    public float zforse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(xforse, yforse, zforse);
    }
}
