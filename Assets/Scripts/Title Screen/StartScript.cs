using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour {
	bool hovering = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && hovering) {
			Application.LoadLevel(1);
		}
	}

	void OnMouseOver(){
		hovering = true;
	}
	void OnMouseExit(){
		hovering = false;
	}
}
