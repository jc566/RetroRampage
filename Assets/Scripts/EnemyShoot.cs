using UnityEngine;
using System.Collections;

public class EnemyShoot : PlayerShoot {
	public GameObject player; //reference to player

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player"); //find player at start of the level

		myTransform = transform;
		
		spawnTransform = myTransform.FindChild ("ProjSpawnPoint");
	}
	
	// Update is called once per frame
	void Update () {
		Shoot ();
	}

	public virtual void Shoot()
	{
		if (Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			
			launchPosition = spawnTransform.TransformPoint(0,0,0.2f); //Z coordinate determines slightly in front of Camerahead
			
			Instantiate(projectile, launchPosition, Quaternion.Euler (spawnTransform.eulerAngles.x, myTransform.eulerAngles.y, myTransform.eulerAngles.z + 270));
			
		}
	}
}
