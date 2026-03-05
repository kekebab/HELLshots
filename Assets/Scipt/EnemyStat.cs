using UnityEngine;
using UnityEngine.AI;

public class EnemyStat : MonoBehaviour
{
    public float Health;
    public NavMeshAgent Agent;
    public Transform Player;
    public float DetectionRange;
    public float ShootingDistance;
   

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

          //  Agent.SetDestination(Player.position);

        if (Health < 0)
        {
           Death();
        }
    }

    void Death()
    {
        Destroy(this.gameObject);
        
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, DetectionRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ShootingDistance);
    }
}
