using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // La referencia al transform del jugador
    public float smoothSpeed = 0.125f;  // La velocidad con la que la cámara sigue al jugador
    public Vector3 offset;  // La diferencia entre la posición de la cámara y la del jugador

    void LateUpdate()
    {
        // Calcula la posición deseada de la cámara
        Vector3 desiredPosition = player.position + offset;
        // Suaviza el movimiento de la cámara hacia la posición deseada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // Actualiza la posición de la cámara
        transform.position = smoothedPosition;
    }
}
