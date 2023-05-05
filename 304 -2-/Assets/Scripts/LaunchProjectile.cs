using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    public GameObject projectile;
    public float launchVelocity;

    public GameObject shooter;

    public Rigidbody rb;

    private float nextFire;
    public float fireRate;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject ball = Instantiate(projectile, transform.position, transform.rotation);
            damage = ball.GetComponent<BulletPfbScript>().damage;

            //rb.AddRelativeForce(launchVelocity, 0, 0);

            ball.GetComponent<Rigidbody>().AddRelativeForce(0, 0, launchVelocity);
        }

        
    }
}
