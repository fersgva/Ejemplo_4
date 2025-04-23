using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Variables asignables desde el Inspector
    public int vidas = 3;
    public TextMeshProUGUI textoVidas;
    public int puntos = 0;
    public TextMeshProUGUI textoPuntos;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PerderVida()
    {
        vidas--;

        // Validación para evitar NullReferenceException
        if (textoVidas != null)
        {
            textoVidas.text = "Vidas: " + vidas;
        }
        else
        {
            Debug.LogError("¡TextoVidas no está asignado en el Inspector!");
        }

        if (vidas <= -3)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
            );
        }
    }

    public void AumentarPuntos(int cantidad)
    {
        puntos += cantidad;
        textoPuntos.text = "Puntos: " + puntos;
    }
}