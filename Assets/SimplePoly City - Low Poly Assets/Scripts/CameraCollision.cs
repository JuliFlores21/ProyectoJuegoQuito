using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public Transform target; // Referencia al jugador u objeto que la c�mara sigue
    public float minDistance = 2f; // Distancia m�nima permitida entre la c�mara y el jugador
    public float maxDistance = 10f; // Distancia m�xima permitida entre la c�mara y el jugador
    public LayerMask collisionMask; // Capas que deben considerarse para la colisi�n

    private Vector3 cameraOffset; // Offset inicial entre la c�mara y el jugador

    void Start()
    {
        cameraOffset = transform.position - target.position;
    }

    void LateUpdate()
    {
        // Calcular la posici�n deseada de la c�mara
        Vector3 desiredPosition = target.position + cameraOffset;

        // Realizar un raycast desde el jugador hacia la c�mara
        RaycastHit hit;
        if (Physics.Raycast(target.position, transform.position - target.position, out hit, maxDistance, collisionMask))
        {
            // Si el raycast golpea un objeto, ajustar la posici�n de la c�mara
            desiredPosition = hit.point + hit.normal * minDistance;
        }

        // Mantener la distancia m�nima y m�xima entre la c�mara y el jugador
        float distance = Vector3.Distance(target.position, desiredPosition);
        Vector3 direction = (desiredPosition - target.position).normalized;
        desiredPosition = target.position + direction * Mathf.Clamp(distance, minDistance, maxDistance);

        // Asignar la posici�n final a la c�mara
        transform.position = desiredPosition;
        transform.LookAt(target);
    }
}
