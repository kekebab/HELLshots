using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

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

        if (fireAction.action.triggered && remainingCooldown <= 0f)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(mousePos);

            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                Vector3 spawnPos = transform.position + transform.forward * BulletSpawnSistanceToPplayer;

                Vector3 direction = hit.point - spawnPos;

                direction.y = 0f;

                Quaternion rotation = Quaternion.LookRotation(direction);
                print(rotation);
                Instantiate(bulletPrefab, spawnPos, rotation);
            }

            remainingCooldown = cooldown;
        }
    }
}


