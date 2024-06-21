using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Crono : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textoCrono;
    [SerializeField] private float tiempo;
    private int tiempoMinutos, tiempoSegundos, tiempoMilisegundos;
    private bool cronometroActivo = true; // Variable para controlar el estado del cronómetro

    void Cronometro()
    {
        if (cronometroActivo)
        {
            tiempo += Time.deltaTime;
            tiempoMinutos = Mathf.FloorToInt(tiempo / 60);
            tiempoSegundos = Mathf.FloorToInt(tiempo % 60);
            tiempoMilisegundos = Mathf.FloorToInt((tiempo % 1) * 100);
            textoCrono.text = string.Format("{0:00}:{1:00}:{2:00}", tiempoMinutos,
                tiempoSegundos, tiempoMilisegundos);
        }
    }

    public void DetenerCronometro()
    {
        cronometroActivo = false;
    }

    void Update()
    {
        Cronometro();
    }
}
