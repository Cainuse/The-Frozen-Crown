using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerControler : MonoBehaviour 

{
    //floats
	public float maxSpeed = 10f;        //how fast he can travel at
    public float jumpForce = 700f;      //how much force he exerts on the ground
    float groundRadius = 0.2f;          //used to check whether he is grounded

    //bools
	bool facingRight = true;					//to check which direction he is facing

	[SerializeField]
	private bool grounded = false;              //true or false on whether character is grounded

    public bool interact = false;

    //stats
	[SerializeField]
	private Stats health;

	[SerializeField]
	private Stats mana;


	private Animator anim;
	private Rigidbody2D rb2d;

		
    //references
	public Transform groundcheck;
	public LayerMask whatIsground;
	public bool onLadder;
    public Transform linestart;
    public Transform lineend;
    public AudioSource hit;


    RaycastHit2D WhatIHit;

	private void Awake()
	{
		health.initialize ();
		mana.initialize ();

		rb2d = GetComponent<Rigidbody2D> ();
	}

	
	void Start ()
	{
		anim = GetComponent<Animator> ();

	}


	void FixedUpdate ()
	{
		
		grounded = Physics2D.OverlapCircle (groundcheck.position, groundRadius, whatIsground);
		anim.SetBool ("Ground", grounded);

		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D>().velocity.y);

		float move = Input.GetAxis ("Horizontal");

		anim.SetFloat ("Speed", Mathf.Abs (move));

		GetComponent<Rigidbody2D>().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();


	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.U)) 
		{
			health.CurrentVal -= 10;
		}

		if (Input.GetKeyDown (KeyCode.I)) 
		{
			health.CurrentVal += 10;
		}

		if (Input.GetKeyDown (KeyCode.J)) 
		{
			mana.CurrentVal -= 10;
		}

		if (Input.GetKeyDown (KeyCode.K)) 
		{
			mana.CurrentVal += 10;
		}


		if (health.CurrentVal <= 0) 
		{
			die ();
		}




        Raycasting();



		if(grounded && Input.GetKeyDown (KeyCode.Space))
		{
			anim.SetBool ("Ground", false);
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
		}

	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}


    void die()
    {
        //Restart
        Application.LoadLevel(Application.loadedLevel);
    }

    void Raycasting()                   // function to allow change of level when we touch the door
    {
        Debug.DrawLine(linestart.position, lineend.position, Color.blue);               //used to debug the game

        if(Physics2D.Linecast(linestart.position, lineend.position, 1<< LayerMask.NameToLayer("Objects")))   //if the line we have made here touches any object of that layer
        {
            WhatIHit = Physics2D.Linecast(linestart.position, lineend.position, 1 << LayerMask.NameToLayer("Objects"));      //we tag that specific object
            interact = true;                    //changing the boolean to true
        }
        else
        {
            interact = false;
        }

        if(Input.GetKeyDown(KeyCode.E) & interact == true)                  //when interact is true and we press E then we enable fading code and also level change
        {
            float fadeTime = GameObject.Find("Main Camera").GetComponent<Fading>().BeginFade(1);
            new WaitForSeconds(fadeTime);
            Application.LoadLevel(Application.loadedLevel + 1);
        }

    }

	public void Damage(int dmg){

		health.CurrentVal -= dmg;
        gameObject.GetComponent<Animation>().Play("Player_RedFlashes");
        hit.Play();


	}

	public IEnumerator Knockback(float knockDuration, float knockPower, Vector3 knockDirection){

		float timer = 0;
		rb2d.velocity = new Vector2 (rb2d.velocity.x, 0);

		while (knockDuration > timer) {

			timer += Time.deltaTime;

				rb2d.AddForce (new Vector3 (knockDirection.x * -100, knockDirection.y * knockPower, transform.position.z));
		}

		yield return 0;

	}

    void OnCollisionEnter2D (Collision2D other)
    {
        if(other.transform.tag == "MovingPlatform")
        {
            transform.parent = other.transform;
        }

    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "MovingPlatform")
        {
            transform.parent = null;
        }

    }

}
