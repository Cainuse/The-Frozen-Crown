using UnityEngine;
using System.Collections;

public class TurretAi : MonoBehaviour {

    //Integers
    public int currentHealth;
    public int maxHealth;

    //floats
    public float distance;
    public float wakeRange;
    public float shootInterval;
    public float bulletSpeed;
    public float bulletTimer;

    //Bools
    public bool awake = false;
    public bool lookingRight = true;

    //reference
    public GameObject bullet;
    public Transform target;
    public Animator anim;
    public Transform shootpointright;
    public Transform shootpointleft;
    public AudioSource clank;
    public AudioSource explosion;
    public AudioSource gunshot;


    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();

    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {

        anim.SetBool("Awake", awake);
        anim.SetBool ("LookingRight", lookingRight);

        RangeCheck();


        if (target.transform.position.x > transform.position.x)
        {
            lookingRight = true;
        }


        if (target.transform.position.x < transform.position.x)
        {
            lookingRight = false;
        }


        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            explosion.Play();
        }

    }

    void RangeCheck()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance < wakeRange)
        {
            awake = true;

        }

        if (distance > wakeRange)
        {
            awake = false;
        }

    }

    public void Attack(bool attackingRight)
    {
        bulletTimer += Time.deltaTime;

        if (bulletTimer >= shootInterval)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();

            if (!attackingRight)
            {
                GameObject bulletClone;
                gunshot.Play();
                bulletClone = Instantiate(bullet, shootpointleft.transform.position, shootpointleft.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

                bulletTimer = 0;
            }

            if (attackingRight)
            {
                GameObject bulletClone;
                gunshot.Play();
                bulletClone = Instantiate(bullet, shootpointright.transform.position, shootpointright.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

                bulletTimer = 0;
            }
        }
    }


    public void Damage(int damage)
    {
        currentHealth -= damage;
        clank.Play();
        gameObject.GetComponent<Animation>().Play("Player_RedFlashes");
    }

}
