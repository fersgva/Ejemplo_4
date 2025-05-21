using UnityEngine;
using UnityEngine.EventSystems;

namespace DVII.ClaseV_POO.Scripts
{
    public class Slime : Enemy, IInteractuable
    {
        protected override void Attack()
        {
            Debug.Log("Me arrastro...");
        }

        public void Interactuar()
        {
            
        }
    }
}
