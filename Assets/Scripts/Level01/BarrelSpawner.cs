using UnityEngine;
using System.Collections;

public class BarrelSpawner : MonoBehaviour {

	public GameObject barrel;

	private Transform myTransform; //refernce to my this objects transform
	private Transform spawnTransform; //reference to where the spawn point is going to be
	private Vector2 launchPosition = new Vector2 (); //launch position

	public float fireRate;
	public float nextFire;

	// Use this for initialization
	void Start () {
	
		myTransform = transform;

		spawnTransform = myTransform.FindChild ("BarrelSpawn");

	}
	
	// Update is called once per frame
	void Update () {
	
		ThrowBarrel ();
	}
	public virtual void ThrowBarrel()
	{
		nextFire++;
		if (nextFire > fireRate) 
		{
			launchPosition = spawnTransform.TransformPoint (0, 0, 0.2f);

			Instantiate (barrel, launchPosition, Quaternion.identity);

			nextFire = 0;
		}


	}
}
