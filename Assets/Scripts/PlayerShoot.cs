using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {
	public GameObject projectile; //Prefab of the Projectile

	public Transform myTransform;

	public Transform spawnTransform;

	//Launch Position
	public Vector2 launchPosition = new Vector2();

	//Fire Rate
	public float fireRate;
	public float nextFire;

	// Use this for initialization
	void Start () {
	
		myTransform = transform;

		spawnTransform = myTransform.FindChild ("ProjSpawnPoint");
	}
	
	// Update is called once per frame
	void Update () {
		Shoot ();
	}

	public virtual void Shoot()
	{
		if (Input.GetButton ("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;

			launchPosition = spawnTransform.TransformPoint(0,0,0.2f); //Z coordinate determines slightly in front of Camerahead
			
			Instantiate(projectile, launchPosition, Quaternion.Euler (spawnTransform.eulerAngles.x, myTransform.eulerAngles.y, myTransform.eulerAngles.z + 270));

		}
	}
}
