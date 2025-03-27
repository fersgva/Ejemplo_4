using System;
using Unity.VisualScripting;
using UnityEngine;

public class CuerpoFisico : MonoBehaviour
{
    [SerializeField] private float movementForce;
    [SerializeField] private float jumpForce;

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    private void Jump()
    {
        //100% UPDATE.
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, 1) * jumpForce, ForceMode2D.Impulse);
        }
    }

    //Ciclo de físicas CONTINUAS o Constantes.
    private void FixedUpdate()
    {
        //.Force: CONSTANTE.
        rb.AddForce(new Vector2(1, 0) * movementForce, ForceMode2D.Force);
       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Muro"))
        {
            //other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0) * 10, ForceMode2D.Impulse);
        }
    }
}
