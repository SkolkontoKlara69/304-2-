using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    public GameObject projectile;
    public float launchVelocity = 700f;

    public GameObject shooter;

    private float nextFire;
    public float fireRate;
    public float damage;

    public PauseManager pauseManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > nextFire && pauseManager.paused == false)
        {
            nextFire = Time.time + fireRate;
            GameObject ball = Instantiate(projectile, transform.position, transform.rotation);
            damage = ball.GetComponent<BulletPfbScript>().damage;

            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3 (0, 0, launchVelocity));
        }


        
    }
}
