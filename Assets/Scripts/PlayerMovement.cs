using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {



	public float MovementSpeed; //movement speed
	public float jumpHeight; //max jump height

	public float movePlaceholder; //placeholder to store movement speed
	public float jumpPlaceholder; //place holder to store jump height

	private Rigidbody2D mySelf; //reference to rigidbody attached to player


	public bool canJumpAgain;//can player jump again?
	public bool isGrounded; //is the player touching the ground?
	public int jumpCount; //keep track of amount of jumps
	public int maxJumpAmount; //how many times can you jump

	public float positionx;
	public Animator anim;

	public float move;
	public bool facingRight = true;

	public GameObject projSpawn;

	// Use this for initialization
	void Start () {
		mySelf = GetComponent<Rigidbody2D> ();


		movePlaceholder = MovementSpeed;
		jumpPlaceholder = jumpHeight;

		anim = GetComponentInChildren<Animator> ();

		projSpawn = GameObject.FindGameObjectWithTag ("ProjSpawnPoint");
	}
	
	// Update is called once per frame
	void Update () {
		JumpHandler ();//Reset Bools for Jumping
		//Movement(); //Movement Controls


	}
	void FixedUpdate()
	{
		move = Input.GetAxis ("Horizontal");
		
		
		mySelf.velocity = new Vector2 (move * MovementSpeed, mySelf.velocity.y);
		
		if (move > 0 && !facingRight) {
			flip ();

			//transform.eulerAngles = new Vector2(0,180); //to flip character
		} else if (move < 0 && facingRight) {
			flip ();
			//transform.eulerAngles = new Vector2(0,0); //to flip character

			
		}
		anim.SetFloat ("Speed", Mathf.Abs (move));
		Movement ();
	}

	IEnumerator BananaRecover()
	{
		yield return new WaitForSeconds(3); //after X time, reset movement values to normal
		MovementSpeed = movePlaceholder;
		jumpHeight = jumpPlaceholder;
		jumpCount = 0;

	}

	IEnumerator BananaSlip()
	{
		MovementSpeed = 0;
		jumpHeight = 0;
		jumpCount = 4;
		yield return StartCoroutine(BananaRecover());
	}

	public virtual void StartBanana()
	{
		StartCoroutine (BananaSlip ()); //restore movement values
	}


	//Control conditions for jumping
	public virtual void JumpHandler()
	{
		if (isGrounded == true) 
		{
			canJumpAgain = false;

			jumpCount = 0;
		}

	}

	public virtual void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Floor") 
		{
			isGrounded = true;
		}
	}
	//Movement controls including left/right, jump, crouch
	public virtual void Movement()
	{
		//Controls for Jumping
		if (Input.GetKeyDown ("up") && jumpCount < 3) 
		{
			if(isGrounded)
			{
				//mySelf.velocity.y = 0;
				mySelf.velocity = new Vector2(0, jumpHeight); //make the player jump
				mySelf.AddForce(new Vector2(0,jumpHeight));
				canJumpAgain = true;
				isGrounded = false;
				jumpCount++;


			}
			else
			{
				if(canJumpAgain && jumpCount < maxJumpAmount)
				{
					//mySelf.velocity.y = 0;
					//mySelf.AddForce(new Vector2(0,jumpHeight));
					mySelf.velocity = new Vector2(0, jumpHeight); //make the player jump
					jumpCount++;
				}

			}
		}

		/*
		//Controls for Movement
		if(Input.GetKey("down"))
		{
			//transform.Translate(-Vector2.up * MovementSpeed * Time.deltaTime);
		}
		if(Input.GetKey("left"))
		{

			transform.Translate (Vector2.right * MovementSpeed * Time.deltaTime);
			transform.eulerAngles = new Vector2(0,180); //to flip character
			positionx = transform.position.x;

		}
		if(Input.GetKey("right"))
		{
			transform.Translate (Vector2.right * MovementSpeed * Time.deltaTime);
			transform.eulerAngles = new Vector2(0,0); //to flip character
			positionx = transform.position.x;
		}*/

	}

	void flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}


}
