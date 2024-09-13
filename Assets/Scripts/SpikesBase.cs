using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpikeBase : MonoBehaviour
{
    // Variable para almacenar el daño que causará el spike
    public float damage = 10f;

    // Método abstracto que las clases derivadas deben implementar
    public abstract void Activate();

    // Método que se llama cuando un collider entra en contacto con el spike
    public virtual void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto con el que colisiona el spike tiene un componente de salud
        PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();
        if (health != null)
        {
            // Aplica daño al objeto que tiene el componente de salud
            health.TakeDamage(10);
        }

    }
}