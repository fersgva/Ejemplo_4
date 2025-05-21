using UnityEngine;

namespace DVII.ClaseV_POO.Scripts
{
    public class Item : MonoBehaviour, IInteractuable
    {
        public void Interactuar()
        {
            Debug.Log("Me obtienes");
            Destroy(gameObject);
        }
    }
}
