using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // El jugador (o el objeto a seguir)
    public float smoothSpeed = 0.125f; // Velocidad de seguimiento
    public Vector3 offset; // Distancia de la cámara al jugador
    private Vector3 desiredPosition;

    void LateUpdate()
    {
        if (target != null)
        {
            desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.rotation = Quaternion.LookRotation(target.position - transform.position); // Mantener la rotación original de la cámara
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(desiredPosition, 0.1f);
    }
}
