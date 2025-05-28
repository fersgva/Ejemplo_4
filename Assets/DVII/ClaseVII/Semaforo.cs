using System.Collections;
using UnityEngine;

public class Semaforo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Sem());
        Debug.Log("Adiós!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Sem()
    {
        while (true)
        {
            Debug.Log("Rojo");
            yield return new WaitForSeconds(1f);
            Debug.Log("Amarillo");
            yield return new WaitForSeconds(1.5f);
            Debug.Log("Verde");
        }
    }
}
