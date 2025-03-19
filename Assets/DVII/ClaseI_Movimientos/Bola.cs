using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bola : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool puedoLanzar = true;
    private int lives = 3;
    private int score = 0;

    [SerializeField] private TextMeshProUGUI textoScore;
    [SerializeField] private TextMeshProUGUI textovidas;
    [SerializeField] private GameObject pala;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && puedoLanzar == true)
        {
            transform.SetParent(null); //1. Me desemparento.
            rb.bodyType = RigidbodyType2D.Dynamic; //2. Bola pasa a din�mico (con f�sicas)
            //3. Se aplica un impulso.
            rb.AddForce(new Vector2(1, 1).normalized * 10, ForceMode2D.Impulse);
            puedoLanzar = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D elOtro)
    {
        if(elOtro.gameObject.CompareTag("ZonaDeMuerte"))
        {
            ResetearBola();
        }
    }
    private void OnCollisionEnter2D(Collision2D elOtro)
    {
        if(elOtro.gameObject.CompareTag("Bloque"))
        {
            Destroy(elOtro.gameObject);
            score++;
            textoScore.text = "Score: " + score;
        }
        
    }
    private void ResetearBola()
    {
        rb.linearVelocity = Vector2.zero; //0. Suprimimos la velocidad que traigamos.
        rb.isKinematic = true; //1. Paso de nuevo a cinem�tico (no f�sicas)
        transform.SetParent(pala.transform); //2. Volvemos a emparentar la bola.
        transform.localPosition = new Vector3(0, 1, 0); //3. Recolocamos la bola.
        puedoLanzar = true;
        lives--;
        textovidas.text = "Lives: " + lives;
    }
}
