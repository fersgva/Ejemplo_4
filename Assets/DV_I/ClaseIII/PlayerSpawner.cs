using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Bullet balaPrefab;

    private int bulletsPerShot = 80;
    
    private ObjectPool<Bullet> bulletPool;

    private void Awake()
    {
        bulletPool = new ObjectPool<Bullet>(CreateBullet, OnGetBullet, OnReleaseBullet);
    }

    //Este método se llamará cuando se necesite una bala nueva.
    private Bullet CreateBullet()
    {
        Bullet balaCopy = Instantiate(balaPrefab);
        balaCopy.MyPool = bulletPool; //A la bullet que ha nacido le comunico quien es su piscina para después liberarse.
        return balaCopy;
    }
    
    //Este método se llamará cuando se necesite recilcar una bala ya existente.
    private void OnGetBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
    }
    
    //Se llamará de forma automática cuando una bala tenga que ser devuelta a la piscina.
    private void OnReleaseBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false); // Desactivas el objeto.
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(SpawnBolitas());
        }
    }

    private IEnumerator SpawnBolitas()
    {
            float angulo = 360 / bulletsPerShot;

            for (float i = 0; i <= 360; i+= angulo)
            {
                Bullet copy = bulletPool.Get();
                copy.transform.position = transform.position;
                copy.transform.eulerAngles = new Vector3(0, 0, i);
                yield return new WaitForSeconds(0.05f);
            }
        
    }
}
