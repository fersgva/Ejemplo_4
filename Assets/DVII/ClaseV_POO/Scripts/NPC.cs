using UnityEngine;

namespace DVII.ClaseV_POO.Scripts
{
    public class NPC : MonoBehaviour, IInteractuable
    {
        public void Interactuar()
        {
            Debug.Log("Me pongo a charlar!");
        }
    }
}
