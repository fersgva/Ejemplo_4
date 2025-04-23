using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Método para cargar el Nivel 1
    public void CargarNivel1() // ❌ Error original: "CargarNivel.IO"
    {
        SceneManager.LoadScene("Nivel1");
    }

    // Método para cargar el Nivel 2
    public void CargarNivel2()
    {
        SceneManager.LoadScene("Nivel2");
    }

    // Método para salir del juego
    public void Salir()
    {
        Application.Quit();
    }
}
