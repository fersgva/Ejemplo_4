using UnityEngine;

namespace DVII.ClaseIV_ControlesMoviles.Scripts
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
#if UNITY_STANDALONE
            joystick.gameObject.SetActive(false);
#endif
        }

        // Update is called once per frame
        void Update()
        {
            temporizador += 1 * Time.deltaTime;

            Movimiento();
            DelimitarMovimiento();

            
            if(Input.GetKey(KeyCode.Space) && temporizador > ratioDisparo)
            {
                Disparar();
            }

        }

        public void Disparar()
        {
            Instantiate(disparoPrefab, spawnPoint1.transform.position, Quaternion.identity);
            Instantiate(disparoPrefab, spawnPoint2.transform.position, Quaternion.identity);
            temporizador = 0;
        }
        void Movimiento()
        {
            float hJoystick = joystick.Horizontal;
            float vJoystick = joystick.Vertical;
            
#if UNITY_STANDALONE
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            transform.Translate(new Vector2(h, v).normalized * velocidad * Time.deltaTime);
#endif
            
#if UNITY_ANDROID
            transform.Translate(new Vector2(joystick.Horizontal, joystick.Vertical) * velocidad * Time.deltaTime);
#endif
        }
        void DelimitarMovimiento()
        {
            float xClamped = Mathf.Clamp(transform.position.x, -8.4f, 8.4f);
            float yClamped = Mathf.Clamp(transform.position.y, -4.5f, 4.5f);
            transform.position = new Vector3(xClamped, yClamped, 0);
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
