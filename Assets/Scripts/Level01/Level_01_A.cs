using UnityEngine;
using System.Collections;

public class Level_01_A : MonoBehaviour {
	public GameObject player; //reference to player on stage to modify settings based on level
	public GameObject endOfLevel; //reference to when player crosses finish line
	private PlayerShoot pShoot;//reference to the player on stages ability to shoot
	private PlayerScript PHeath;
	
	public GameOverScript gameover;
	// Use this for initialization
	void Start () {
		endOfLevel = GameObject.FindGameObjectWithTag ("endOfLevel");
		player = GameObject.FindGameObjectWithTag ("Player");

		pShoot = player.GetComponent<PlayerShoot> ();
		pShoot.enabled = false;

		PHeath = player.GetComponent<PlayerScript>();


		gameover.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		LevelFinish ();
		didYoudie ();
	}

	public virtual void didYoudie()
	{
		if (PHeath.isDead == true) {
			Destroy(player.gameObject);
			gameover.enabled = true;
		}
	}

	public virtual void LevelFinish()
	{
		if (endOfLevel.GetComponent<EndLevel> ().ReachedEnd == true) 
		{
			Application.LoadLevel("Level02");
		}
	}
}
