using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejemplo : MonoBehaviour
{
    [SerializeField] 
    private float force;

    [SerializeField]
    private float jumpForce;

    private Rigidbody2D rb;

    private float life;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        Application.targetFrameRate = 10000000;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
        
    }
    private void FixedUpdate()
    {
        rb.AddForce(Vector3.right * force, ForceMode2D.Force);

        
    }
}
