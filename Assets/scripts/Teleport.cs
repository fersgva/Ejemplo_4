using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [Tooltip("Arrastra aquí el objeto de destino del teleport")]
    public Transform destinoTeleport; // Asigna el otro teleport en el Inspector

    [SerializeField] private float tiempoEspera = 0.5f; // Evita teletransporte infinito
    private bool puedeTeleport = true;

    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (puedeTeleport && otro.CompareTag("Player"))
        {
            // Teletransporta al jugador
            otro.transform.position = destinoTeleport.position;

            // Desactiva temporalmente el teleport destino
            destinoTeleport.GetComponent<Teleport>().DesactivarTemporalmente();
            StartCoroutine(ReactivarTeleport());
        }
    }

    private IEnumerator ReactivarTeleport()
    {
        puedeTeleport = false;
        yield return new WaitForSeconds(tiempoEspera);
        puedeTeleport = true;
    }

    public void DesactivarTemporalmente()
    {
        StartCoroutine(ReactivarTeleport());
    }
}
