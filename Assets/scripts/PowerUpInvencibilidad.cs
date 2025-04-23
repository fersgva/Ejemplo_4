using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInvencibilidad : MonoBehaviour
{
    [Header("Configuraci�n")]
    [SerializeField] private float duracionInvencibilidad = 5f; // Nombre corregido

    private void OnTriggerEnter2D(Collider2D other) // Correcci�n: OnTriggerEnter2D (sin "l")
    {
        if (other.CompareTag("Player"))
        {
            JugadorSalud jugador = other.GetComponent<JugadorSalud>();
            if (jugador != null)
            {
                // Aseg�rate de pasar el par�metro correcto
                jugador.ActivarInvencibilidad(duracionInvencibilidad);
                Destroy(gameObject);
            }
        }
    }
}
