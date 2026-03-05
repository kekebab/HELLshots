using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float maxPosX, minPosX;
    public float height;
    public float minPosY, maxPosY;
    public float Cooldown;
    public float remainingCooldown;

    public GameObject EnemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        remainingCooldown = Cooldown;
    }

    void Update()
    {
        remainingCooldown -= Time.deltaTime;
        if (remainingCooldown < 0)
        {
            print("CoolDown end ");
            SpawnerEnemy();
            remainingCooldown = Cooldown;
        }
    }


    void SpawnerEnemy()
    {

        Vector3 spawnPos =
            new Vector3(
                Random.Range(minPosX, maxPosX),
                height,
                Random.Range(minPosY, maxPosY));


        print("Spawn at " + spawnPos);
        Instantiate(EnemyPrefab, spawnPos, Quaternion.identity);

    }

    // Update is called once per frame

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(this.transform.position, new Vector3(maxPosX, height, 0));
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(this.transform.position, new Vector3(minPosX, height, 0));
        Gizmos.color = Color.red;
        Gizmos.DrawLine(this.transform.position, new Vector3(height, height, 0));
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(this.transform.position, new Vector3(0, height, minPosY));
        Gizmos.color = Color.green;
        Gizmos.DrawLine(this.transform.position, new Vector3(0, height, maxPosY));
    }
}
