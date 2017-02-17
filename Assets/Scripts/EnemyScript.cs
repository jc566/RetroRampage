using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public GameObject player;
	public Transform PlayerTransform; //reference to player transform
	public float MoveSpeed; //how fast enemy will move
	public float DistanceFromPlayer; //how close it can get to player
	//public Rigidbody2D mySelf; //reference to the enemies own rigidbody

	public float health; //how much HP does this enemy have?



	//Location Nodes Enemy can Move to.
	public Transform[] MovementNode;
	public GameObject EnemyMoveNode;
	public int numOfNodes;
	public int xMin,xMax,yMin,yMax; //for random ranges
	// Use this for initialization
	void Start () {
		//mySelf = GetComponent<Rigidbody2D> ();
		InitializeNodes ();

	}
	
	// Update is called once per frame
	void Update () {
		FollowPlayer ();
	}

	//Initilize movement node locations
	public virtual void InitializeNodes()
	{

		for (int i = 0; i < numOfNodes; i++) 
		{
			Vector2 RandomNodeLoc = new Vector2(Random.Range (xMin,xMax),Random.Range(yMin,yMax));

			Instantiate(EnemyMoveNode,RandomNodeLoc,Quaternion.identity);
		}
	}

	//Follow Player -Look at and Move Towards between distance offset
	public virtual void FollowPlayer()
	{
		//Rotate to look at player
		transform.LookAt (PlayerTransform.position);
		transform.Rotate(new Vector2(0,-90),Space.Self);


		//Move Towards Player
		if (Vector2.Distance (transform.position, PlayerTransform.position) > DistanceFromPlayer) {
			transform.Translate (new Vector3(MoveSpeed * Time.deltaTime,0,0));
			//mySelf.AddForce(new Vector2 (Time.deltaTime * MoveSpeed,Time.deltaTime * MoveSpeed));
		}
	}



}
