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
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
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
            }
        }


        if (Health < 0)
        {
           Death();
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
