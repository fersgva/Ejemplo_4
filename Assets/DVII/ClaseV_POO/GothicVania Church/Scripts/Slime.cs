using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : EjemploNameSpace.Enemigo
{

    protected override void Atacar()
    {
        Debug.Log("Me pongo a patrullar!");
    }

    protected override void Perseguir()
    {
        base.Perseguir();


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
