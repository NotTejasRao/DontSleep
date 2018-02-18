using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowablePillow : MonoBehaviour {

    public GameLord gameLord;

    public void Start()
    {
        gameLord = GameObject.Find("GameLord").GetComponent<GameLord>();        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.transform.name.StartsWith("Player"))
        {
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

}
