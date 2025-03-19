using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : EjemploNameSpace.Enemigo
{
    protected override void Atacar()
    {
        Debug.Log("Lanzo bolas de fuego!");
    }
    protected override void Perseguir()
    {
        base.Perseguir();
        //Mira a ver si una vez me pongo en movimiento estoy a cierta distancia
        //del objetivo....
        //En ese caso, me pongo a lanzar bolas de fuego cada X tiempo.s
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
