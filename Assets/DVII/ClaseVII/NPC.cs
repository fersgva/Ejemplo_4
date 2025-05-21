using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private float velocidadMovimiento;

    [SerializeField]
    private float tiempoEntreEsperasMinimo;

    [SerializeField]
    private float tiempoEntreEsperasMaximo;

    [SerializeField]
    private float distanciaMaxima;

    [SerializeField]
    private float radioDeteccion;

    [SerializeField]
    private LayerMask queEsObstaculo;

    private Vector3 posicionObjetivo;
    private Vector3 posicionInicial;
    private Animator anim;

    private void Awake()
    {
        posicionInicial = transform.position;
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IrHaciaDestinoYEsperar());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator IrHaciaDestinoYEsperar()
    {
        while(true) //Por siempre.
        {
            CalcularNuevoDestino();
            anim.SetBool("walking", true);
            
            while (transform.position != posicionObjetivo) //Va al ritmo de los frames pero corta bajo la condici�n establecida.
            {
                //Movimiento cinem�tico (no tiene f�sicas)
                transform.position = Vector3.MoveTowards(transform.position, posicionObjetivo, velocidadMovimiento * Time.deltaTime);
                yield return null;
            }
            anim.SetBool("walking", false);

            yield return new WaitForSeconds(Random.Range(tiempoEntreEsperasMinimo, tiempoEntreEsperasMaximo));
        }
    }

    private void CalcularNuevoDestino()
    {
        Vector3[] direcciones = new Vector3[]
        {
            Vector3.left,
            Vector3.right,
            Vector3.up,
            Vector3.down
        };
        float[] hValues = { -1, 1, 0, 0 };
        float[] vValues = { 0, 0, 1, -1 };
        
        bool tileValido = false;

        while(!tileValido)
        {
            int index = Random.Range(0, direcciones.Length);
            posicionObjetivo = transform.position + direcciones[index];
        
            anim.SetFloat("h", hValues[index]);
            anim.SetFloat("v", vValues[index]);

            tileValido = TileLibreYDentroDeDistancia();
        }
    }

    private bool TileLibreYDentroDeDistancia()
    {
        if(Vector3.Distance(posicionInicial, posicionObjetivo) > distanciaMaxima)
        {
            return false;
        }
        else //El tile est� dentro de la distancia m�xima...
        {
            //Pero ahora voy a comprobar si est� ocupado o no
            return !Physics2D.OverlapCircle(posicionObjetivo, radioDeteccion, queEsObstaculo);
        }
    }
}
