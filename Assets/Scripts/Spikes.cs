using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikyTrap : SpikeBase
{
    // Implementa el m�todo Activate
    public override void Activate()
    {
               Debug.Log("caiste ! ");
    }

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision); 
    }
}
