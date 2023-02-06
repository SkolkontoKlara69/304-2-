using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy100 : MonoBehaviour
{

    public float movingSpeed;
    public Transform targetTransform;
    public float stopDistance;
    public float damage;
    public GameObject bulletPrefab;
    public Rigidbody bulletRb;
    private float nextFire;
    public float fireRate;

    private Vector3 newDirection;
    private Vector3 targetDirection;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
     void Update()
    {
        
        float distanceToTarget = Vector3.Distance(transform.position, targetTransform.position);


        //Om den är tillräckligt nära så ska den sluta gå
        if (distanceToTarget >= stopDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, movingSpeed * Time.deltaTime);

        }
        else if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }

        RotateToTarget();
        
        
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(newDirection));
        damage = bullet.GetComponent<Bullet1000>().damage;
    }
    void RotateToTarget()
    {
        float singleStep = movingSpeed * Time.deltaTime;
        targetDirection = targetTransform.position- transform.position;

        newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDirection);

        //Debug line so that you are able to see where the enemy is looking
        Debug.DrawRay(transform.position, newDirection, Color.red);

    }
}


