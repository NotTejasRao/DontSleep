using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour {
	bool hovering = false;
	public int delaytime = 1;
    
	// Use this for initialization
	void Start () {       
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1;
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

    private void OnMouseDown()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}
