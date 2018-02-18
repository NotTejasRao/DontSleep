using System;
using UnityEngine;

public class Sheep : MonoBehaviour {

    public GameObject player;
    [SerializeField] private int health;
    private float speed = 3.0f;
    private DateTime lastHurtTimestamp;
    private Vector3 destination;
    private Rigidbody rigidbody;
    private DateTime lastMovementTimestamp;

    private void Awake()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    private void Start()
    {
        lastMovementTimestamp = DateTime.Now;
        rigidbody = gameObject.GetComponent<Rigidbody>();
        health = 10;
        lastHurtTimestamp = DateTime.Now;
        InvokeRepeating("MoveSheep", 0f, 0.1f);
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.forward, Vector3.up);
    }

    private void MoveSheep()
    {

        Vector3 sheepPosition = transform.position;
        if (Vector3.Distance(player.transform.position, sheepPosition) < 10)
        {
            destination = player.transform.position;
        }
        if (destination == null || Vector3.Distance(destination, gameObject.transform.position) < 1)
        {
            Debug.Log("reached");
            // Pick a new destination
            destination = new Vector3(sheepPosition.x + UnityEngine.Random.Range(-10, 10), sheepPosition.y, sheepPosition.z + UnityEngine.Random.Range(-10, 10));
            CancelInvoke("MoveSheep");
            InvokeRepeating("MoveSheep", 0.5f, 0.1f);
        }
        rigidbody.velocity = (destination - sheepPosition).normalized * speed;
        
    }

    public void Hurt(int hurtAmount)
    { 
        double milli = getTimeSince(lastHurtTimestamp);
        Debug.Log("Tried hurt" + milli);
        if (milli > 1*1000)
        {
            lastHurtTimestamp = DateTime.Now;
            Debug.Log("Hurt");
            health -= hurtAmount;
            if (health <= 0) Kill();
        }   
    }

    public void Kill()
    {
        Destroy(this.gameObject);
    }

    private double getTimeSince(DateTime lastTimestamp)
    {
        return DateTime.Now.Subtract(lastTimestamp).TotalMilliseconds;
    }

}
