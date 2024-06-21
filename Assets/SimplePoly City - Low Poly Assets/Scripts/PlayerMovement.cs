using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 4;
    public float runSpeed = 11; // Nueva velocidad para correr
    public float rotationSpeed = 250;
    public Animator animator;
    private float x, y;
    float currentSpeed;
    public float fuerzaSalto = 8f;
    public bool Grounded;


    void Start()
    {
        Grounded = false;
    }

    void FixedUpdate()
    {
        if (Grounded)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                animator.SetBool("Saltar", true);
                GetComponent<Rigidbody>().AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
            }
            animator.SetBool("Grounded", true);
        }
        else
        {
            caigo();
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = runSpeed;
            if (y > 0)
            {
                animator.SetBool("Correr", true);
            }
            else
            {
                animator.SetBool("Correr", false);
            }
        }
        else
        {
            animator.SetBool("Correr", false);
            currentSpeed = walkSpeed;
        }
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        // Rotar el jugador
        transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);

        // Mover al jugador
        transform.Translate(0, 0, y * Time.deltaTime * currentSpeed);

        // Actualizar la animación
        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);
    }
    public void caigo()
    {
        animator.SetBool("Grounded", false);
        animator.SetBool("Saltar", false);
    }
}
