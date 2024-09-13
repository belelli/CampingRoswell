using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpikeBase : MonoBehaviour
{
    // Variable para almacenar el da�o que causar� el spike
    public float damage = 10f;

    // M�todo abstracto que las clases derivadas deben implementar
    public abstract void Activate();

    // M�todo que se llama cuando un collider entra en contacto con el spike
    public virtual void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto con el que colisiona el spike tiene un componente de salud
        PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();
        if (health != null)
        {
            // Aplica da�o al objeto que tiene el componente de salud
            health.TakeDamage(10);
        }

    }
}