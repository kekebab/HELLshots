using UnityEditor.Rendering;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 10f;

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStats player = collision.gameObject.GetComponent<PlayerStats>();

            if (player != null)
                player.TakeDamage(damage);

        }

            Destroy(gameObject);
      
    }
}