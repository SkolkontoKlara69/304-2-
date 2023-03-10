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

    ///  ---DAVE'S (?) CODE FOR SHOOTING THE BULLETS---
    private PhysicMaterial physic_mat;


    // -basics-
    [Header("Daves grejer")]
    [Range(0f, 1f)] public float bounciness;
    public bool useGravity;

    // - annat?-
    public GameObject explosion;
    public LayerMask whatIsEnemies;
    public int explosionDamage;
    public float explosionRange;
    public float explosionForce;
    public bool alreadyExploded;



    // Start is called before the first frame update
    void Start()
    {
        hit = false;
        Setup();

    }
    private void Setup()
    {
        //Setup physics material
        physic_mat = new PhysicMaterial();
        physic_mat.bounciness = bounciness;
        physic_mat.frictionCombine = PhysicMaterialCombine.Minimum;
        physic_mat.bounceCombine = PhysicMaterialCombine.Maximum;
        //Apply the physics material to the collider
        GetComponent<CapsuleCollider>().material = physic_mat;

        //Don't use unity's gravity, we made our own (to have more control)
        rb.useGravity = useGravity;
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
    public void Explode()
    {
        //Bug fixing
        if (alreadyExploded) return;
        alreadyExploded = true;

        Debug.Log("Explode");

        //Instantiate explosion if attatched
        if (explosion != null)
            Instantiate(explosion, transform.position, Quaternion.identity);

        //Check for enemies and damage them
        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange, whatIsEnemies);
        for (int i = 0; i < enemies.Length; i++)
        {
            //Damage enemies
            //if (enemies[i].GetComponent<ShootingAi>())
              //  enemies[i].GetComponent<ShootingAi>().TakeDamage(explosionDamage);

            //Add explosion force to enemies
            //if (enemies[i].GetComponent<Rigidbody>())
              //  enemies[i].GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRange, 2f);
        }

        //Pearl(Teleport) to position
        //if (objectToTp != null && tpOnExplosion) Pearl(transform.position);

        ///Instantiate smoke if attatched
        ///if (smokeEffect != null)
        ///  Instantiate(smokeEffect, transform.position, Quaternion.identity);

        //Invoke destruction
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<TrailRenderer>().emitting = false;
        Invoke("Delay", 0.08f);

    }
}