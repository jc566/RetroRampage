using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {
	public bool ReachedEnd;
	// Use this for initialization
	void Start () {
		ReachedEnd = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			ReachedEnd = true;
		}

	}
}
