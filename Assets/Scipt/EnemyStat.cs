using UnityEngine;
using UnityEngine.AI;

public class EnemyStat : MonoBehaviour
{
    public float Health;
    public NavMeshAgent Agent;
    public Transform Player;
    public float DetectionRange;
    public float ShootingDistance;

    public float ContactDamage;


    public GameObject BulletEnemyPrefab;
    public Transform shootPoint;

    public float fireRate = 1f;
    private float fireCooldown; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //if (CompareTag("RunEnemy") ){  //debug
        //    print(Health);
        //}
        float distance = Vector3.Distance(transform.position, Player.position);

        if (distance <= DetectionRange)
        {

            if (distance > ShootingDistance )
            {
                Agent.SetDestination(Player.position);
            }
            else
            {
                Agent.ResetPath();
                transform.LookAt(Player);

                if (CompareTag("ShooterEnemy"))
                {
                    Shoot();
                }
            }
        }

        if (Health <= 0)
        {
           Death();
        }
    }


    void Shoot()
    {
        if (fireCooldown > 0)
            fireCooldown -= Time.deltaTime;

        if (fireCooldown <= 0)
        {
            Vector3 direction = (Player.position - shootPoint.position).normalized;
            direction.y = 0f;

            Quaternion rot = Quaternion.LookRotation(direction);

            Instantiate(BulletEnemyPrefab, shootPoint.position, rot);

            fireCooldown = fireRate;
        }
    }


    void Death()
    {
        Destroy(this.gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (CompareTag("RunEnemy")  && other.CompareTag("Player"))
        {
            PlayerStats playerHealth = other.GetComponent<PlayerStats>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(ContactDamage);
                print("il y a eu contact");
            }
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, DetectionRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ShootingDistance);
    }
}
