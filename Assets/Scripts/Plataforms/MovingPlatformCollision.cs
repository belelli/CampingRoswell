using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformCollision : MonoBehaviour
{


    [SerializeField] Transform platform;
    //public Transform playerParent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            //other.gameObject.transform.parent = platform;
            other.gameObject.transform.parent = platform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            //other.gameObject.transform.parent = null;
            other.gameObject.transform.parent = null;
        }
    }

}
