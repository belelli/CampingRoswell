using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformCollision : MonoBehaviour
{


    [SerializeField] Transform platform;
    public Transform playerParent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            //other.gameObject.transform.parent = platform;
            playerParent.gameObject.transform.parent = platform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            //other.gameObject.transform.parent = null;
            playerParent.gameObject.transform.parent = null;
        }
    }

}
