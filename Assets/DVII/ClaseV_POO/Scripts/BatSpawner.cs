using DVII.ClaseV_POO.Scripts;
using UnityEngine;

public class BatSpawner : MonoBehaviour
{
    
    public float Ejemplo { get; set; }
    
    
    [SerializeField] private Bat batPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Bat batCopy = Instantiate(batPrefab, transform.position, Quaternion.identity);
        batCopy.Vidas = 50; //Escritura.

        //Enemy ejemplo = null;

        // if (ejemplo as Bat != null)
        // {
        //     
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
