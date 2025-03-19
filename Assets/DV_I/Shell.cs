using UnityEngine;

public class Shell : MonoBehaviour
{
    [SerializeField] private float impulseForce;
    [SerializeField] private float damage;
    private void Awake()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * impulseForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.TryGetComponent(out iDamagable iDamagable))
        {
            Destroy(gameObject);
            iDamagable.TakeDamage(damage);
        }
    }
}
