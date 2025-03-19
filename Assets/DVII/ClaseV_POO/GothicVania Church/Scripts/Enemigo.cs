using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EjemploNameSpace
{
    //POO: Herencia, Abstracci�n, Encapsulamiento, Polimorfismo.
    public abstract class Enemigo : MonoBehaviour
    {
        [SerializeField] private float vida;

        protected float Vida { get => vida; set => vida = value; }

        protected abstract void Atacar(); //No est� clara la forma de atacar.

        protected virtual void Perseguir() //Hay una parte que es com�n a todos los enemigos
        {
            //1. Calcular direcci�n al objetivo.
            //2. Disponernos a movernos en esa direcci�n

        }

        protected void TakeDamage(float damage)
        {

        }

    }

}
