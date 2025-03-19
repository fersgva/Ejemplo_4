using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClaseIV
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float velocidad;
        [SerializeField] private float ratioDisparo;
        [SerializeField] private GameObject disparoPrefab;
        [SerializeField] private GameObject spawnPoint1;
        [SerializeField] private GameObject spawnPoint2;
        [SerializeField] private Joystick joystick;
        private float temporizador = 0.5f;
        private float vidas = 100;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            temporizador += 1 * Time.deltaTime;

            Movimiento();
            DelimitarMovimiento();


#if UNITY_STANDALONE
            if(Input.GetKey(KeyCode.Space) && temporizador > ratioDisparo)
            {
                Disparar();
            }
#endif

        }
        void Movimiento()
        {
#if UNITY_STANDALONE
            float inputH = Input.GetAxisRaw("Horizontal");
            float inputV = Input.GetAxisRaw("Vertical");
            transform.Translate(new Vector2(inputH, inputV).normalized * velocidad * Time.deltaTime);
#endif
#if UNITY_ANDROID
            float inputH = joystick.Horizontal;
            float inputV = joystick.Vertical;
            transform.Translate(new Vector2(inputH, inputV) * velocidad * Time.deltaTime);
#endif
        }
        void DelimitarMovimiento()
        {
            float xClamped = Mathf.Clamp(transform.position.x, -8.4f, 8.4f);
            float yClamped = Mathf.Clamp(transform.position.y, -4.5f, 4.5f);
            transform.position = new Vector3(xClamped, yClamped, 0);
        }
        public void Disparar()
        {
            Instantiate(disparoPrefab, spawnPoint1.transform.position, Quaternion.identity);
            Instantiate(disparoPrefab, spawnPoint2.transform.position, Quaternion.identity);
            temporizador = 0;
        }

        private void OnTriggerEnter2D(Collider2D elOtro)
        {
            if(elOtro.gameObject.CompareTag("DisparoEnemigo") || elOtro.gameObject.CompareTag("Enemigo"))
            {
                vidas -= 20;
                Destroy(elOtro.gameObject);
                if(vidas <= 0)
                {
                    Destroy(this.gameObject);
                }
            }
        }


    }

}
