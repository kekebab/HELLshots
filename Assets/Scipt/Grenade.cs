using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float cooldown;
    public GameObject ExplosionPrefab;
    public GameObject Explosion;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldown-= Time.deltaTime;

    if(cooldown <= 0)
        {
            Vector3 spawnPos = transform.position;
            
            Destroy(this.gameObject);
            Explosion = Instantiate(ExplosionPrefab, spawnPos, Quaternion.identity);
            Destroy(Explosion.gameObject, 0.2f);
        }
    }
}
