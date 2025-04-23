using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Temporizador : MonoBehaviour
{
    [Header("Configuración")]
    public float tiempoInicial = 60f; // Tiempo en segundos
    public TextMeshProUGUI textoTiempo; // Asignar desde el Inspector

    private float tiempoActual;
    private bool temporizadorActivo = true;

    void Start()
    {
        tiempoActual = tiempoInicial;
        ActualizarTempoUI();
    }

    void Update()
    {
        if (temporizadorActivo && tiempoActual > 0)
        {
            tiempoActual -= Time.deltaTime;
            ActualizarTempoUI();
        }

        if (tiempoActual <= 0)
        {
            tiempoActual = 0;
            temporizadorActivo = false;
            GameOver();
        }
    }

    void ActualizarTempoUI()
    {
        if (textoTiempo != null) // Evita NullReferenceException
        {
            int minutos = Mathf.FloorToInt(tiempoActual / 60);
            int segundos = Mathf.FloorToInt(tiempoActual % 60);
            textoTiempo.text = $"{minutos:00}:{segundos:00}";
        }
        else
        {
            Debug.LogError("¡Asigna el componente 'textoTiempo' en el Inspector!");
        }
    }

    void GameOver()
    {
        Debug.Log("¡Tiempo agotado!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recarga la escena
    }

    public void DetenerTemporizador()
    {
        temporizadorActivo = false;
    }
}

