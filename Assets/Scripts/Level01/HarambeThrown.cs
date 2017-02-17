using UnityEngine;
using System.Collections;

public class HarambeThrown : MonoBehaviour {

	public float damage; //how much damage barrel does when hitting player
	public GameObject player;//reference to player
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D col)
	{
		//what happens when it hits the player
		if (col.gameObject.tag == "Player") 
		{
			//Debug.Log("Push Back");
			
			player.GetComponent<PlayerScript>().PlayerHealth -= damage;
			Destroy(this.gameObject);
			
		}

		//what happens when it hits the barrel destroy block
		if (col.gameObject.tag == "DestroyBarrels") 
		{
			Destroy(this.gameObject);
		}

	}
}
