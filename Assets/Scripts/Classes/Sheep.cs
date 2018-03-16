using System;
using UnityEngine;

public class Sheep : MonoBehaviour {

    public GameObject player;
    [SerializeField] private int health;
    private float speed = 3.0f;
    private DateTime lastHurtTimestamp;
    private Vector3 destination;
    private Rigidbody rigidbody;
    private AudioSource audioSource;
    public AudioClip ba1;
    public AudioClip ba2;
    public AudioClip ba3;
    public AudioClip ba4;
    public AudioClip ba5;

    private void Awake()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    private void Start()
    {      
        rigidbody = gameObject.GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        audioSource.enabled = true;
        audioSource.volume = .1f;
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

            if (UnityEngine.Random.Range(0,500) == 2)
            {
                Debug.Log("MUSIC");
                AudioClip selected = null;
                switch(UnityEngine.Random.Range(1,5))
                {

                    case 1:
                        selected = ba1;
                        break;

                    case 2:
                        selected = ba2;
                        break;
                    case 3:
                        selected = ba3;
                        break;
                    case 4:
                        selected = ba4;
                        break;
                    case 5:
                        selected = ba5;
                        break;
                }
                audioSource.clip = selected;
                audioSource.Play();
            }

        }
        if (destination == null || Vector3.Distance(destination, gameObject.transform.position) < 1)
        {
            Debug.Log("reached");
            // Pick a new destination
            destination = new Vector3(sheepPosition.x + UnityEngine.Random.Range(-10, 10), sheepPosition.y, sheepPosition.z + UnityEngine.Random.Range(-10, 10));
            CancelInvoke("MoveSheep");
            InvokeRepeating("MoveSheep", 0.5f, 0.1f);
        }
        destination.y = sheepPosition.y;
        rigidbody.velocity = (destination - sheepPosition).normalized * speed;        
    }

}
