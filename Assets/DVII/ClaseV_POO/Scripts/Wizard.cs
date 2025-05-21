using System;
using UnityEngine;

namespace DVII.ClaseV_POO.Scripts
{
    public class Wizard : Enemy, IInteractuable
    {
        private void Awake()
        {
            Patrullar();
        }

        protected override void Attack()
        {
            base.Attack();
            Debug.Log("Lanzo bolas de fuego en esa dirección!");
        }

        public void Interactuar()
        {
            
        }
    }
}
