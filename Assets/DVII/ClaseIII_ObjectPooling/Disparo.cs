using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Disparo : MonoBehaviour
{
    [SerializeField] private float velocidad;

    private ObjectPool<Disparo> myPool;

    public ObjectPool<Disparo> MyPool { get => myPool; set => myPool = value; }

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(this.gameObject, 4);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * velocidad * Time.deltaTime);

        timer += Time.deltaTime;

        if(timer >= 4)
        {
            timer = 0;
            myPool.Release(this);
        }
        
    }
}
