using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public float PlayerHealth;
	public bool isDead;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Death ();
	}

	public virtual void Death()
	{
		if (PlayerHealth < 1) 
		{
			isDead = true;
		}
	}
}
