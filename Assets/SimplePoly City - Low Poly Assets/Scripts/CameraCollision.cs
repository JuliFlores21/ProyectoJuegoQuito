using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public Transform target; // Referencia al jugador u objeto que la cámara sigue
    public float minDistance = 2f; // Distancia mínima permitida entre la cámara y el jugador
    public float maxDistance = 10f; // Distancia máxima permitida entre la cámara y el jugador
    public LayerMask collisionMask; // Capas que deben considerarse para la colisión

    private Vector3 cameraOffset; // Offset inicial entre la cámara y el jugador

    void Start()
    {
        cameraOffset = transform.position - target.position;
    }

    void LateUpdate()
    {
        // Calcular la posición deseada de la cámara
        Vector3 desiredPosition = target.position + cameraOffset;

        // Realizar un raycast desde el jugador hacia la cámara
        RaycastHit hit;
        if (Physics.Raycast(target.position, transform.position - target.position, out hit, maxDistance, collisionMask))
        {
            // Si el raycast golpea un objeto, ajustar la posición de la cámara
            desiredPosition = hit.point + hit.normal * minDistance;
        }

        // Mantener la distancia mínima y máxima entre la cámara y el jugador
        float distance = Vector3.Distance(target.position, desiredPosition);
        Vector3 direction = (desiredPosition - target.position).normalized;
        desiredPosition = target.position + direction * Mathf.Clamp(distance, minDistance, maxDistance);

        // Asignar la posición final a la cámara
        transform.position = desiredPosition;
        transform.LookAt(target);
    }
}
