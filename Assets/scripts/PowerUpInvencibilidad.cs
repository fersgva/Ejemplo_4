using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInvencibilidad : MonoBehaviour
{
    [Header("Configuración")]
    [SerializeField] private float duracionInvencibilidad = 5f; // Nombre corregido

    private void OnTriggerEnter2D(Collider2D other) // Corrección: OnTriggerEnter2D (sin "l")
    {
        if (other.CompareTag("Player"))
        {
            JugadorSalud jugador = other.GetComponent<JugadorSalud>();
            if (jugador != null)
            {
                // Asegúrate de pasar el parámetro correcto
                jugador.ActivarInvencibilidad(duracionInvencibilidad);
                Destroy(gameObject);
            }
        }
    }
}
