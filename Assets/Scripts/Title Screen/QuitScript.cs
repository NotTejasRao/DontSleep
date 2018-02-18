using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitScript : MonoBehaviour {
	bool hovering = false;
	public int delaytime = 1;
	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && hovering) {
			Application.Quit();
		}
	}
	void OnMouseEnter(){
		transform.localScale += new Vector3 (0.05F, 0, 0.05F);
		AudioSource audio = GetComponent<AudioSource> ();
		audio.Play ();
	}
	void OnMouseOver(){
		
		hovering = true;
	}
	void OnMouseExit(){
		transform.localScale -= new Vector3 (0.05F, 0, 0.05F);
		hovering = false;
	}
}
