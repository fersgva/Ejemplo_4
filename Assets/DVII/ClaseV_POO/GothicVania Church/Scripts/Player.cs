using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EjemploNameSpace
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Transform puntoDeteccion;
        [SerializeField] private float radioDeteccion;
        [SerializeField] private LayerMask queEsInteractuable;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            
                Collider2D collDetectado = Physics2D.OverlapCircle(puntoDeteccion.position, radioDeteccion, queEsInteractuable);
                if(collDetectado != null )
                {
                   //Enciende icono de interacción
                   if(Input.GetKeyDown(KeyCode.Escape))
                    {
                        if(collDetectado.TryGetComponent(out IInteractuable interactuable))
                        {
                            interactuable.Interactuar();
                        }

                    }
                }

        }
        private void FixedUpdate()
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
            
        }
    }

}
