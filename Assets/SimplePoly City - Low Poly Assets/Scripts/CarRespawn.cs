using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRespawn : MonoBehaviour
{
    public float maxDistance = 10f; // Distancia máxima a recorrer
    public float speed = 5f; // Velocidad del carro
    private Vector3 respawnPosition; // Posición de respawn
    private Vector3 initialPosition;
    public Transform respawnPoint;
    // Posición inicial del carro
    void Start()
    {
        initialPosition = transform.position;
        respawnPosition = respawnPoint.position;
    }

    void Update()
    {
        float distance = Vector3.Distance(initialPosition, transform.position);
        if (distance >= maxDistance)
        {
            // Mover el carro de vuelta al respawn
            transform.position = respawnPosition;
        }
        else
        {
            // Mover el carro hacia adelante
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
