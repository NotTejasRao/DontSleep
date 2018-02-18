using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitScript : MonoBehaviour {
	bool hovering = false;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && hovering) {
			AudioSource audio = GetComponent<AudioSource> ();
			audio.Play ();
			Application.Quit();
		}
	}

	void OnMouseOver(){
		hovering = true;
	}
	void OnMouseExit(){
		hovering = false;
	}
}
