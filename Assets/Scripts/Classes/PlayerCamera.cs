using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    public GameLord gameLord;
    public GameObject pillow;

    public void Update()
    {
        if (gameLord.pillows > 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GameObject bullet = Instantiate(pillow, transform.position + new Vector3(0, .5f, 0), transform.rotation) as GameObject;
                bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 10;
                gameLord.pillows--;
            }
        }
    }

}
