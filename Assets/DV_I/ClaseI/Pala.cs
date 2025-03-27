using System;
using UnityEngine;

public class Pala : MonoBehaviour
{

    [SerializeField]
    private float speed;
    
    // Update is called once per frame
    private void Update()
    {
        //Movimiento cinemático: Sin físicas.
        transform.Translate(new Vector3(1, 0, 0) * (speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Muro"))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }
}
