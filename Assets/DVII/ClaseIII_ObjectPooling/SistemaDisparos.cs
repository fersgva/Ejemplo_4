using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SistemaDisparos : MonoBehaviour
{
    [SerializeField] private Disparo disparoPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private int numeroDisparos;

    private ObjectPool<Disparo> pool;


    private float ratioDisparo;
    private float timer;
    private void Awake()
    {
    }
    private void Start()
    {
        
        pool = new ObjectPool<Disparo>(CrearDisparo, null, ReleaseDisparo, DestroyDisparo);
    }

    private Disparo CrearDisparo()
    {
        Disparo disparoCopia = Instantiate(disparoPrefab, transform.position, Quaternion.identity);
        disparoCopia.MyPool = pool;
        return disparoCopia;
    }
    private void ReleaseDisparo(Disparo disparo)
    {
        disparo.gameObject.SetActive(false);
    }
    private void DestroyDisparo(Disparo disparo)
    {
        Destroy(disparo.gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space) && timer > ratioDisparo)
        {
            StartCoroutine(Espiral());
            timer = 0;
            
        }
    }
    private IEnumerator Espiral()
    {
        float gradosPorDisparo = 360 / numeroDisparos;

        
        for (float i = 0; i < 360; i += gradosPorDisparo)
        {
            Disparo disparoCopia = pool.Get();
            disparoCopia.gameObject.SetActive(true);
            disparoCopia.transform.position = transform.position;
            disparoCopia.transform.eulerAngles = new Vector3(0f, 0f, i);
            yield return new WaitForSeconds(0.2f);

        }
    }
}
