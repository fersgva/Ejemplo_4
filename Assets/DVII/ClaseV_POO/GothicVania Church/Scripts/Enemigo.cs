using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EjemploNameSpace
{
    //POO: Herencia, Abstracción, Encapsulamiento, Polimorfismo.
    public abstract class Enemigo : MonoBehaviour
    {
        [SerializeField] private float vida;

        protected float Vida { get => vida; set => vida = value; }

        protected abstract void Atacar(); //No está clara la forma de atacar.

        protected virtual void Perseguir() //Hay una parte que es común a todos los enemigos
        {
            //1. Calcular dirección al objetivo.
            //2. Disponernos a movernos en esa dirección

        }

        protected void TakeDamage(float damage)
        {

        }

    }

}
