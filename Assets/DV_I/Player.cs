using UnityEngine;

namespace Simulacro
{
    public class Player : MonoBehaviour, iDamagable
    {
        [SerializeField] private float lifes;
        [SerializeField] private Shell shellPrefab;
        [SerializeField] private float movementVelocity;
        [SerializeField] private float rotationVelocity;
        [SerializeField] private float turretRotationVelocity;
        [SerializeField] private Transform turret;
        [SerializeField] private Transform spawnPoint;

        private Rigidbody2D rb;

        private float h, v;

        public float Lifes { get => lifes; }

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");

            transform.Rotate(new Vector3(0, 0, -h) * rotationVelocity * Time.deltaTime);

            Shoot();
            TurretRotation();
        }
        private void Shoot()
        {
            if(Input.GetMouseButtonDown(0))
            {
                Instantiate(shellPrefab, spawnPoint.position, turret.rotation);
            }
        }

        private void TurretRotation()
        {
            if (Input.GetKey(KeyCode.Q))
            {
                turret.Rotate(new Vector3(0, 0, 1) * turretRotationVelocity * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.E))
            {
                turret.Rotate(new Vector3(0, 0, -1) * turretRotationVelocity * Time.deltaTime);
            }
        }

        private void FixedUpdate()
        {
            rb.linearVelocity = movementVelocity * v * transform.up;
        }

        public void TakeDamage(float damage)
        {
            lifes -= damage;
            if (lifes <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

