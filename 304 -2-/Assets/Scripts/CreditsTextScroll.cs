using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsTextScroll : MonoBehaviour
{
    public int scrollingSpeed = 1;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 2700)
        {
            transform.position = new Vector3(transform.position.x, -623 , transform.position.z);

        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + scrollingSpeed, transform.position.z);
        }
    }
}
