using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollider : MonoBehaviour
{
    public Transform goToPosition;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            print("entro al Death Collider");
            collision.transform.position = goToPosition.transform.position;
        }
        
    }
}
