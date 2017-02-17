using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {
	

	public Rigidbody2D thisProjRigidbody;//reference to itself

	public float projSpeed; //how fast proj goes

	public float projDamage; //how much damage to deal

	private GameObject harambe;

	//public EnemyScript[] Enemies; //array of enemies
	// Use this for initialization
	void Start () 
	{
		thisProjRigidbody = GetComponent<Rigidbody2D> ();

		//find the enemies available
		harambe = GameObject.FindGameObjectWithTag ("BossHarambe");
		//Enemies = Enemies.GetComponent<EnemyScript>().health;
	}
	
	// Update is called once per frame
	void Update () 
	{
		thisProjRigidbody.AddForce (transform.up * projSpeed);

	}

	//Collision Detection
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "BossHarambe") 
		{
			harambe.GetComponent<Harambe>().health -= 10;
		}
	}

	/*//CoRoutine
	IEnumerator DestroyMyself()
	{
		yield return new WaitForSeconds(expireTime);//after expiteTime do the next line of instruction
		Destroy (myTransform.gameObject); //destroy the gameobject now
	}*/
}
