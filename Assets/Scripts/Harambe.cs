using UnityEngine;
using System.Collections;

public class Harambe : EnemyScript {
	public float pushBackDistance; //how far will harambe push the player?

	public Rigidbody2D playerRigid; //get rigidbody2d of the player
	
	public float MeleeAttack; //damage dealt from touching harambe
	public float PushBackAttack; //damage dealth when harambe pushes you back



	public float jumpTimer;
	public float nextJump;
	public float jumpHeight;
	private bool canJump;
	public bool isInAir;
	
	// Use this for initialization
	void Start () {
		canJump = false; //By default harambe cannot jump, only if hes touching the floor!
		playerRigid = player.GetComponent<Rigidbody2D>();//reference to the rigidbody of the player
		MoveSpeed = (player.GetComponent<PlayerMovement> ().MovementSpeed)*1.0001f; //make Harambes movespeed always slightly faster than player
		//Debug.Log (MoveSpeed); //print Harambes movement speed


		//InitializeNodes (); //no need to initialize nodes for harambe


	}
	
	// Update is called once per frame
	void Update () {
		FollowPlayer ();
		//Debug.Log (canJump);

	}

	//Grab the base node to create random location nodes
	public override void InitializeNodes ()
	{
		base.InitializeNodes ();
	}

	//Move Harambe towards the random nodes
	public override void FollowPlayer ()
	{
		//base.FollowPlayer (); //make a much closer gap distance

		//Rotate to look at player
		transform.LookAt (PlayerTransform.position);
		transform.Rotate(new Vector2(0,-90),Space.Self);
		
		
		//Move Towards Player
		if (Vector2.Distance (transform.position, PlayerTransform.position) > DistanceFromPlayer) {
			transform.Translate (new Vector3(MoveSpeed * Time.deltaTime,0,0));
			Jump ();
			//mySelf.AddForce(new Vector2 (Time.deltaTime * MoveSpeed,Time.deltaTime * MoveSpeed));
		}
	}
	
	public virtual void Jump()
	{	

		if (Time.deltaTime > nextJump ) 
		{
			transform.Translate(new Vector3((MoveSpeed/2)*Time.deltaTime,jumpHeight * Time.deltaTime,0));
			isInAir = true;
			nextJump = 0f;
		}

	}
	//When Harambe first hits The Player Push him back
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Floor") //if Harambe is touching the floor hes allowed to jump
		{
			canJump = true;
			isInAir = false;
		}
		if (col.gameObject.tag == "Player") 
		{
			//Debug.Log("Push Back");
			playerRigid.AddForce(transform.right * pushBackDistance ); //move the player based on the player position and direction
			player.GetComponent<PlayerScript>().PlayerHealth -= PushBackAttack; //deal push back attack damage to player
		}
	}
	//When Harambe and Player are touching deal melee damage
	void OnCollisionStay2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			//Debug.Log ("Melee Attacking!");
			player.GetComponent<PlayerScript>().PlayerHealth -= MeleeAttack; //deal melee attack damage to player

		}
	}
	//
	void OnCollisionExit2D(Collision2D col)
	{

	}


}
