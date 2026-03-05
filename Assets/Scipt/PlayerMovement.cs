using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public InputActionReference moveAction;
    public InputActionReference fireAction;
    public GameObject bulletPrefab;
    public GameObject bullet;
    public float BulletSpawnSistanceToPplayer; 

    public float cooldown;
    public float remainingCooldown;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {   
        //print("Virtual stick : " + moveAction.action.ReadValue<Vector2>());
        if (remainingCooldown > 0) remainingCooldown -= Time.deltaTime;
        Vector3 tempPos = new Vector3(moveAction.action.ReadValue<Vector2>().x, 0, moveAction.action.ReadValue<Vector2>().y);
        this.transform.position += tempPos * speed * Time.deltaTime;

        if(fireAction.action.triggered && remainingCooldown <= 0f)
        {
            Vector3 spawnPos = transform.position + transform.forward * BulletSpawnSistanceToPplayer;
            Quaternion spawnRot = transform.rotation ;

            bullet = Instantiate(bulletPrefab, spawnPos, spawnRot);

            remainingCooldown = cooldown;

        }
    }
}


