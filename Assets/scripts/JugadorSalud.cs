using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class JugadorSalud : MonoBehaviour
{
    public int vidaMaxima = 3;
    private int vidaActual;
    private bool esInvencible = false;
    private SpriteRenderer spriteRenderer;

    // Referencia al texto de la UI
    public TMP_Text textoVidas;

    void Start()
    {
        vidaActual = vidaMaxima;
        spriteRenderer = GetComponent<SpriteRenderer>();
        ActualizarTextoVidas(); // Actualiza el texto al inicio
    }

    public void ActivarInvencibilidad(float duracion)
    {
        if (!esInvencible)
        {
            StartCoroutine(InvencibilidadCoroutine(duracion));
        }
    }

    private IEnumerator InvencibilidadCoroutine(float duracion)
    {
        esInvencible = true;
        float tiempoRestante = duracion;

        while (tiempoRestante > 0)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0.5f);
            yield return new WaitForSeconds(0.15f);
            spriteRenderer.color = Color.blue;
            yield return new WaitForSeconds(0.15f);
            tiempoRestante -= 0.3f;
        }

        esInvencible = false;
    }

    public void RecibirDano(int dano)
    {
        if (!esInvencible)
        {
            vidaActual -= dano;
            ActualizarTextoVidas(); // Actualiza el texto al recibir daño

            if (vidaActual <= 0)
            {
                Debug.Log("¡Jugador derrotado!");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    // Método para actualizar el texto de las vidas
    private void ActualizarTextoVidas()
    {
        if (textoVidas != null)
        {
            textoVidas.text = "Vidas: " + vidaActual.ToString();
        }
    }

    public bool EsInvencible()
    {
        return esInvencible;
    }
}
