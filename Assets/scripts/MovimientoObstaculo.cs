using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoObstaculo : MonoBehaviour
{
    public enum DireccionMovimiento { Horizontal, Vertical } // ✅ Corrección: "Horizontal"
    public DireccionMovimiento direccion = DireccionMovimiento.Horizontal;
    public float velocidad = 2f;
    public float rango = 3f; // ✅ Corrección: "rango"
    private Vector3 puntoInicial; // ✅ Corrección: "puntoInicial"

    void Start()
    {
        puntoInicial = transform.position;
    }

    void Update()
    {
        switch (direccion)
        {
            case DireccionMovimiento.Horizontal:
                // Movimiento izquierda/derecha
                float nuevaX = Mathf.PingPong(Time.time * velocidad, rango * 2) - rango; // ✅ Cálculo corregido
                transform.position = new Vector3(
                    puntoInicial.x + nuevaX,
                    puntoInicial.y,
                    puntoInicial.z
                );
                break;

            case DireccionMovimiento.Vertical:
                // Movimiento arriba/abajo
                float nuevaY = Mathf.PingPong(Time.time * velocidad, rango * 2) - rango; // ✅ Variable "nuevaY"
                transform.position = new Vector3(
                    puntoInicial.x,
                    puntoInicial.y + nuevaY,
                    puntoInicial.z
                );
                break;
        }
    }
}
