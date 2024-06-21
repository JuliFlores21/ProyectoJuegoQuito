using UnityEngine;

public class HideoutInteraction : MonoBehaviour
{
    public GameObject player;
    public Transform hideoutTransform;
    private bool isHiding;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    public GameObject playerCamera;

    void Start()
    {
        initialPosition = player.transform.position;
        initialRotation = player.transform.rotation;
    }

    void Update()
    {
        if (!isHiding && Input.GetKeyDown(KeyCode.E))
        {
            // Verificar si el jugador está dentro del collider del escondite
            if (player.GetComponent<Collider>().bounds.Intersects(GetComponent<Collider>().bounds))
            {
                // Esconder al jugador
                player.transform.position = hideoutTransform.position;
                isHiding = true;
                player.SetActive(false);               
            }
        }
        else if (isHiding && Input.GetKeyDown(KeyCode.E))
        {
            // Aparecer al jugador
            player.SetActive(true);
            playerCamera.SetActive(true);
            isHiding = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Si el jugador entra en el collider, activar la posibilidad de esconderse
            isHiding = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Si el jugador sale del collider, desactivar la posibilidad de esconderse
            isHiding = false;
        }
    }
}
