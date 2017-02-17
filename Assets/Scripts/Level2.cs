using UnityEngine;
using System.Collections;

public class Level2 : MonoBehaviour {
	public GameObject player; //reference to player on stage to modify settings based on level
	public GameObject endOfLevel; //reference to when player crosses finish line
	public gosLevel2 gameover;
	private PlayerScript PHeath;

	// Use this for initialization
	void Start () {
		endOfLevel = GameObject.FindGameObjectWithTag ("endOfLevel");
		player = GameObject.FindGameObjectWithTag ("Player");
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
			Application.LoadLevel("Level01");
		}
	}
}
