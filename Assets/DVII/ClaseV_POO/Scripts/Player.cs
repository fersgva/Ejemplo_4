using System;
using UnityEngine;

namespace DVII.ClaseV_POO.Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Transform interactionPoint;
        [SerializeField] private float interactionRadius;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Collider2D coll = Physics2D.OverlapCircle(interactionPoint.position, interactionRadius);
                if (coll != null)
                {
                    Debug.Log("Funciona 1");
                    //Si dicho collider encontrado IMPLEMENTA la interfaz interactuable...
                    if (coll.TryGetComponent(out IInteractuable interactuable))
                    {
                        Debug.Log("Funciona 2");
                        interactuable.Interactuar();
                    }
                }
            }
        }
    }
}
