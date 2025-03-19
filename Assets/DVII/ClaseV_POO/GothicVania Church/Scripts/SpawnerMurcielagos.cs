using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMurcielagos : MonoBehaviour
{

    //POO:
    //Herencia, Encapsulamiento, Abstracción, Polimorfismo.


    [SerializeField] private Bat murcielagoPrefab;


    [SerializeField] private float tiempoEntreSpawns; //primitiva (float, int, char, string, bool

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > tiempoEntreSpawns)
        {
            //Bat murcielagoCopia = Instantiate(murcielagoPrefab, new Vector3(Random.Range(-4f, 4f), Random.Range(-4f, 4f), 0), Quaternion.identity);
            //murcielagoCopia.SetVida(150);
            //murcielagoCopia.Vida = 150;

            //if(murcielagoCopia.Vida <= 0)
            //{
            //    Debug.Log("Morimos x(");
            //}
            //Bat.contador++;
            timer = 0f;
        }
    }
}
