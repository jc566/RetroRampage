using UnityEngine;
using System.Collections;

public class gosLevel2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI (){
		if (GUI.Button (new Rect ((Screen.width/2)-100, (Screen.height/2)-25, 200, 50), "Try Again")) {
			Application.LoadLevel("Level02");
		}
		
	}
}
