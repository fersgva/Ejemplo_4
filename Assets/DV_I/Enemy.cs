using UnityEngine;

public class Enemy : MonoBehaviour, iDamagable
{
    [SerializeField] private float lifes;
    [SerializeField] private Shell shellPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float timeBetweenSpawns;
    private Transform playerBase;
    private float timer;

    public void TakeDamage(float damage)
    {
        lifes -= damage;
        if(lifes <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        playerBase = GameObject.FindGameObjectWithTag("Base").transform;
        Vector3 directionToBase = (playerBase.position - transform.position).normalized;
        transform.up = directionToBase;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, playerBase.position) > 3.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerBase.position, movementSpeed * Time.deltaTime);
        }
        else
        {
            timer += Time.deltaTime;
            if(timer >= timeBetweenSpawns)
            {
                Instantiate(shellPrefab, spawnPoint.position, spawnPoint.rotation);
                timer = 0;
            }
        }
    }
}
