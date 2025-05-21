using System;
using UnityEngine;

namespace DVII.ClaseV_POO.Scripts
{
    //Herencia, Polimorfismo, Abstracción.
    public class Bat : Enemy
    {
        private void Start()
        {
            Attack();
        }

        protected override void Attack()
        {
            base.Attack();
            Debug.Log("Caigo en picado en esa dirección");
        }
    }
}
