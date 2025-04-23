using System;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    public ObjectPool<Bullet> MyPool { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3.right : Derecha global.
        //.forward
        //transform.right, transform.up, transform.forward
        transform.Translate(transform.right * 5 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Muro"))
        {
            MyPool.Release(this);
            
        }
    }
}
