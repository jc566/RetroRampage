using UnityEngine;
using System.Collections;

public class InstaKill : MonoBehaviour {
	public GameObject player; //reference to player on stage to modify settings based on level
	private PlayerScript PHeath;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		PHeath = player.GetComponent<PlayerScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") {
			PHeath.PlayerHealth = 0;
			PHeath.isDead = true;
		}
	}
}
