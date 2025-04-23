using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D otro)
    {
        // Asegúrate de que el tag sea "Player" (exactamente igual)
        if (otro.CompareTag("Player"))
        {
            // Verifica que el GameManager exista y tenga el método correcto
            GameManager.Instance.AumentarPuntos(1);
            Destroy(gameObject);
        }
    }
}
