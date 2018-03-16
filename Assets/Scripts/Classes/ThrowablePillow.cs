using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowablePillow : MonoBehaviour {

    public GameLord gameLord;
    public AudioSource audioSource;
    public AudioClip pillowThrow;
    public AudioClip pillowExplode;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameLord = GameObject.Find("GameLord").GetComponent<GameLord>();        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.transform.name.StartsWith("Player"))
        {
            gameLord.PlayPillowExplode();

            Collider[] colliders = Physics.OverlapSphere(transform.position, 2);
            foreach (Collider col in colliders)
            {
                if (col.transform.parent != null && col.transform.parent.name.StartsWith("Sheep"))
                {
                    Destroy(col.transform.parent.gameObject);
                    gameLord.killedSheeps++;
                }
            }
            Destroy(gameObject);
        }   
    }

    public void PlayPillowThrow()
    {
        audioSource.clip = pillowThrow;
        audioSource.volume = 1f;
        audioSource.Play();
    }

    public void PlayPillowExplode()
    {        
        audioSource.clip = pillowExplode;
        audioSource.volume = 1f;
        audioSource.Play();
    }

}
