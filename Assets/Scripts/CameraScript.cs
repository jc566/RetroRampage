using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	public GameObject player; //reference to player
	private Vector3 offset; //temp var to save vector 3 position
	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
		this.transform.position = player.transform.position + offset;
	}
}
