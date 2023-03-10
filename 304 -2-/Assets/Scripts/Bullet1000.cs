using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1000 : MonoBehaviour
{

    //   ---TARGET---
    //[HideInInspector]
    public Player304 player;
    public Enemy100 shooter;
    public GameObject target;
    public Transform targetTransform;
    public Collider targetCollider;
    public float hitbox;

    //   ---BULLET---
    public Vector3 force;
    public Rigidbody rb;
    public float damage;
    public float movingSpeed;
    public float despawnRate;
    public bool hit;

    //   ---FLOOR---

    public Transform floorTransform;

    public Vector3 newDirection;
    private Vector3 targetDirection;



    // Start is called before the first frame update
    void Start()
    {
        hit = false;

    }

    // Update is called once per frame
    void Update()
    {
        /*if (targetCollider)
        {
            hit = true;
            if (target != null)
            {
                //target.TakeDamage(20);
            }
           
        }
        else if(!hit)
        {
           
        }
        */


        //   ---DESPAWN---
        if (gameObject.name != "Bullet")
        {
            Destroy(gameObject, despawnRate);
        }

        //force = (- shooter.newDirection.x, - shooter.newDirection.y, - shooter.newDirection.z);
        //force = -newDirection;
        //rb.AddForce(force);

        rb.AddRelativeForce(force);

        HitPlayer();

    }
    void HitPlayer()
    {
        float distanceToTarget = Vector3.Distance(transform.position, targetTransform.position);
        float distanceToFloor = transform.position.y - floorTransform.position.y;

        if (distanceToTarget < hitbox && target.name == "Player304" && hit == false && distanceToFloor > 0.5f)
        {
            player.TakeDamage(damage);
            hit = true;
        }
    }
    void ShootOut()
    {

        
    }
}