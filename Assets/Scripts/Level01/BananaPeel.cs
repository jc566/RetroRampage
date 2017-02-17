using UnityEngine;
using System.Collections;

public class BananaPeel : MonoBehaviour {
	public GameObject player;
	public float playerMovSpeed; //save the players movement speed before touching peel
	public float playerJumpAmount;//save the players jump height before touching peel
	public Rigidbody2D playerRigid; //get rigidbody2d of the player


	private Transform newPosition; //hold position of new player position after "slipping"
	// Use this for initialization
	void Start () {


		playerMovSpeed = player.GetComponent<PlayerMovement> ().MovementSpeed;
		playerJumpAmount = player.GetComponent<PlayerMovement> ().jumpHeight;
		playerRigid = player.GetComponent<Rigidbody2D>();//reference to the rigidbody of the player
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D col)
	{

		if (col.gameObject.tag == "Player") 
		{
			//Debug.Log("Push Back");

			player.GetComponent<PlayerMovement>().StartBanana(); //start banana interaction coroutines
			Destroy(this.gameObject);


		}
	}
	/*
	void OnCollisionStay2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			if(player.GetComponent<PlayerMovement>().MovementSpeed == 0)
			{

				disabledTime+=1;
				if(disabledTime > releaseTime)
				{
					
					player.GetComponent<PlayerMovement>().MovementSpeed = playerMovSpeed;
					player.GetComponent<PlayerMovement>().jumpHeight = playerJumpAmount;
					Destroy(this.gameObject);
				}
			}
		
		}
	}
	void OnCollisionExit2D(Collision2D col)
	{

		if (col.gameObject.tag == "Player") 
		{
			Debug.Log ("Exiting Banana Peel");
			if(player.GetComponent<PlayerMovement>().MovementSpeed < playerMovSpeed)
			{

				disabledTime+=1;
				if(disabledTime > releaseTime)
				{
					
					player.GetComponent<PlayerMovement>().MovementSpeed = playerMovSpeed;
					player.GetComponent<PlayerMovement>().jumpHeight = playerJumpAmount;
					Destroy(this.gameObject);
				}
			}
			
		}
	}*/
}
