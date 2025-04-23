using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Meta : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D otro) // ✅ Corrección: OnTriggerEnter2D (sin 'l')
    {
        if (otro.CompareTag("Player"))
        {
            // Detiene el temporizador (si existe)
            if (FindObjectOfType<Temporizador>() != null) // ✅ Corrección: FindObjectOfType<Temporizador>
            {
                FindObjectOfType<Temporizador>().DetenerTemporizador();
            }

            int totalEscenas = SceneManager.sceneCountInBuildSettings;
            int siguienteEscena = SceneManager.GetActiveScene().buildIndex + 1;

            if (siguienteEscena < totalEscenas)
            {
                SceneManager.LoadScene(siguienteEscena); // Carga siguiente nivel
            }
            else
            {
                Debug.Log("¡Juego completado!");
                SceneManager.LoadScene("MenuPrincipal"); // ✅ Regresa al menú por nombre
            }
        }
    }
}

