using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoDano : MonoBehaviour
{
    [SerializeField] private int dano = 1;

    // Método corregido: OnTriggerEnter2D y Collider2D
    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Player"))
        {
            JugadorSalud jugador = otro.GetComponent<JugadorSalud>();
            if (jugador != null)
            {
                jugador.RecibirDano(dano); // Nombre del método corregido
            }
        }
    }
}
