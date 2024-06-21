using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AINavigator : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform target;
    Animator animator;
    public Vector3 walkAreaCenter;
    public float walkAreaRadius = 10f;
    private Vector3 randomDestination;
    public float detectionRadius = 20f; // Radio de detección del jugador
    public Salud saludJugador; // Referencia al script de salud del jugador
    private bool isAttacking;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        agent.stoppingDistance = 1.5f; // Establecer la distancia de parada del NavMeshAgent
        saludJugador = target.GetComponent<Salud>();
        SetRandomDestination();
    }

    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        // Verificar si el jugador está activo y dentro del radio de detección
        if (target.gameObject.activeSelf)
        {
            if (distanceToTarget <= detectionRadius)
            {
                agent.SetDestination(target.position);
            }
            else
            {
                // Si el jugador está activo pero fuera del radio de detección, quedarse quieto
                agent.SetDestination(transform.position);
            }
        }
        else
        {
            // Si el jugador está desactivado, deambular
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                SetRandomDestination();
            }
            agent.SetDestination(randomDestination);
        }

        UpdateAnimations(distanceToTarget);
    }

    void SetRandomDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * walkAreaRadius;
        randomDirection += walkAreaCenter;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, walkAreaRadius, 1);
        randomDestination = hit.position;
    }

    void UpdateAnimations(float distanceToTarget)
    {
        float speed = agent.velocity.magnitude;
        speed = Mathf.Clamp01(speed);
        animator.SetFloat("Speed", speed, 0.1f, Time.deltaTime);

        // Verificar si el enemigo está lo suficientemente cerca del jugador para realizar la animación de ataque
        if (agent.remainingDistance <= agent.stoppingDistance && distanceToTarget <= agent.stoppingDistance && target.gameObject.activeSelf)
        {
            if (!isAttacking)
            {
                isAttacking = true;
                StartCoroutine(AttackPlayer());
            }
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            if (isAttacking)
            {
                isAttacking = false;
                StopCoroutine(AttackPlayer());
            }
            animator.SetBool("IsAttacking", false);
        }
    }

    IEnumerator AttackPlayer()
    {
        while (isAttacking)
        {
            saludJugador.ReducirSalud(7);
            yield return new WaitForSeconds(1.1f);
        }
    }
}
