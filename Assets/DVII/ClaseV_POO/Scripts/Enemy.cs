using System;
using System.Collections;
using UnityEngine;

namespace DVII.ClaseV_POO.Scripts
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected float vidas;
        [SerializeField] protected int level;
        [SerializeField] protected float damage;
        
        public float Vidas { get => vidas; set => vidas = value; }

        protected void Patrullar()
        {
            //Algoritmo comun a los 3 tipos de enemigos.
        }

        protected virtual void Attack()
        {
            //1. Detectar quien es el jugador
            //2. Establecer un vector hacia el jugador....
            //3. ¿¿?¿¿?¿?¿
        }

    }
}
