using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    private const int DAMAGE = 2;

    void OnCollisionEnter(Collision collision)
    {
        Sheep sheep = collision.gameObject.GetComponent<Sheep>();
        if (sheep != null)
        {
            sheep.Hurt(DAMAGE);
        }
    }

}
