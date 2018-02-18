using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepAnimation : MonoBehaviour {
	public Animation anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation>();
		foreach (AnimationState state in anim) {
			state.speed = 0.5F;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
