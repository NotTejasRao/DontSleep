using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

// This example shows how you could draw the splash screen at the start of a scene. This is a good way to integrate the splash screen with your own or add extras such as Audio.
public class DestroySplashScreen : MonoBehaviour
{
	public float delaytime = 8.77f;

	IEnumerator Start(){
		yield return new WaitForSeconds (delaytime);
		GameObject menu = GameObject.Find("Menu");
		menu.transform.Translate (0, -108, 0);
	}
}