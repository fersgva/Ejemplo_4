using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    [Header("Configuración")]
    public float velocidad = 7f; // ✅ Corregir valor numérico
    private Vector3 posicionInicial;

    [Header("Referencias")]
    private Rigidbody2D rb; // ✅ Corregir: Rigidbody2D (no "20")
    private JugadorSalud jugadorSalud; // Añadir referencia al componente de salud

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jugadorSalud = GetComponent<JugadorSalud>(); // ✅ Obtener componente
        posicionInicial = transform.position;
    }

    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal") * velocidad * Time.deltaTime;
        float movimientoVertical = Input.GetAxis("Vertical") * velocidad * Time.deltaTime;

        transform.Translate(new Vector3(movimientoHorizontal, movimientoVertical, 0)); // ✅ Corregir variable
    }

    void OnCollisionEnter2D(Collision2D collision) // ✅ Corregir: Collision2D (no "20")
    {
        if (collision.gameObject.CompareTag("Pared"))
        {
            ResetearPosicion();
        }

        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            if (jugadorSalud != null && !jugadorSalud.EsInvencible()) // ✅ Verificar invencibilidad
            {
                jugadorSalud.RecibirDano(1); // ✅ Aplicar daño controlado
            }
        }
    }

    public void ResetearPosicion()
    {
        transform.position = posicionInicial;
    }
}
