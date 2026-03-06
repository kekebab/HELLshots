using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public float speed;
    public float damage ;

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RunEnemy") || collision.gameObject.CompareTag("ShooterEnemy"))
        {
            EnemyStat enemy = collision.gameObject.GetComponent<EnemyStat>();

            enemy.Health -= damage; 
            Destroy(gameObject);
        }
      Destroy(gameObject);
    }
}