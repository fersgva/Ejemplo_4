using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque : MonoBehaviour
{
    [SerializeField] private GameObject[] powerUps;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
        float ptje = Random.value;

        if(ptje < 0.2f)
        {
            Instantiate(powerUps[0], transform.position, Quaternion.identity);

        }
        else if(ptje < 0.3f)
        {
            Instantiate(powerUps[1], transform.position, Quaternion.identity);
        }
        else if(ptje < 0.35f)
        {

        }
    }

}
