using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikyTrap : SpikeBase
{
    // Implementa el método Activate
    public override void Activate()
    {
               Debug.Log("caiste! ");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerAtackWasp>().TakeDamage(10);


        }
    }
}
