using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float cooldown;
    public float damage;
    public float explosionRadius = 3f;
    public GameObject ExplosionPrefab;

    void Update()
    {
        cooldown -= Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (cooldown <= 0)
        {
            Explode();
        }
    }

    private void Explode()
    {
        Vector3 spawnPos = transform.position;

        // Spawn de l'explosion visuelle
        GameObject explosion = Instantiate(ExplosionPrefab, spawnPos, Quaternion.identity);

        // Récupère tous les objets dans un rayon
        Collider[] hits = Physics.OverlapSphere(spawnPos, explosionRadius);

        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("RunEnemy"))
            {
                EnemyStat enemy = hit.GetComponent<EnemyStat>();
                if (enemy != null)
                {
                    enemy.Health -= damage;
                }
            }
        }

        Destroy(explosion, 0.2f);
        Destroy(gameObject);
    }
}

