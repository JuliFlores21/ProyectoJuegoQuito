using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Salud : MonoBehaviour
{
    public float salud = 100, saludMax = 100;
    [Header("Interfaz")]
    public Image barraSalud;
    public Text textoSalud;
    public GameObject gameOverMenu; // Referencia al canvas del men� de game over
    public Crono crono; // Referencia al script del cron�metro

    void Update()
    {
        actualizarInterfaz();
        CheckGameOver();
    }

    void actualizarInterfaz()
    {
        barraSalud.fillAmount = salud / saludMax;
        textoSalud.text = salud.ToString("f0");
    }

    public void ReducirSalud(float cantidad)
    {
        salud -= cantidad;
        salud = Mathf.Clamp(salud, 0, saludMax); // Aseg�rate de que la salud no sea menor que 0
    }

    void CheckGameOver()
    {
        if (salud <= 0)
        {
            gameOverMenu.SetActive(true); // Activar el men� de game over
            crono.DetenerCronometro(); // Detener el cron�metro
        }
    }
}
