using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameLord gameLord;
    public Collider acollider;

    private void Start()
    {
        acollider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedObject = collision.collider.gameObject;
        Rigidbody collidedRigidbody = collision.rigidbody;
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        if (collidedObject.name.StartsWith("Pillow"))
        {
            gameLord.pillows++;
            Destroy(collision.collider.gameObject);
        }
        else if (collidedRigidbody != null && collidedRigidbody.name.StartsWith("Sheep"))
        {
            gameLord.ReduceAwakenss(10);
            rigidbody.AddForce(transform.forward * 1000);
        }
    }

}
