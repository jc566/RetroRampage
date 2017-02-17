using UnityEngine;
using System.Collections;

public class EnemyProjectile : ProjectileScript {

	// Use this for initialization
	void Start () {
		thisProjRigidbody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		thisProjRigidbody.AddForce (transform.up * projSpeed);
	

	}


	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			Destroy(this.gameObject);
		}
	}
}
