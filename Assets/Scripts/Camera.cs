using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // La referencia al transform del jugador
    public float smoothSpeed = 0.125f;  // La velocidad con la que la c�mara sigue al jugador
    public Vector3 offset;  // La diferencia entre la posici�n de la c�mara y la del jugador

    void LateUpdate()
    {
        // Calcula la posici�n deseada de la c�mara
        Vector3 desiredPosition = player.position + offset;
        // Suaviza el movimiento de la c�mara hacia la posici�n deseada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // Actualiza la posici�n de la c�mara
        transform.position = smoothedPosition;
    }
}
