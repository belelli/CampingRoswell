using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpikeBase : MonoBehaviour
{
    
    public float damage = 10f;

    public abstract void Activate();

    public virtual void OnCollisionEnter(Collision collision)
    {
        PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();
        if (health != null)
        {
            
            health.TakeDamage(10);
        }

    }
}