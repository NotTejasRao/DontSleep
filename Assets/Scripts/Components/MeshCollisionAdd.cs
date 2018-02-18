using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCollisionAdd : MonoBehaviour
{
   
    void Start()
    { 
        foreach (Transform currentTransform in transform)
        {
            currentTransform.gameObject.AddComponent<MeshCollider>().convex = true;
        }
    }
   
}

