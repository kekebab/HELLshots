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
    public float cooldownGrenade;
    public float remainingCooldownGrenade;
    public InputActionReference specialAction;
    public GameObject grenadePrefab;
    public GameObject grenade;
    public float force;
    public PlayerAim aim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aim = this.GetComponent<PlayerAim>();
        
    }

    // Update is called once per frame
    void Update()
    {   
        //print("Virtual stick : " + moveAction.action.ReadValue<Vector2>());
        if (remainingCooldown > 0) remainingCooldown -= Time.deltaTime;
        if (remainingCooldownGrenade > 0) remainingCooldownGrenade -= Time.deltaTime;
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
        


        
        }  
        if (specialAction.action.triggered && remainingCooldownGrenade <= 0f)
            {
                Vector3 spawnPos = transform.position + transform.forward * 1.2f;
                float distance = (aim.grenadeTargetPoint - transform.position).magnitude;
                distance = Mathf.Clamp(distance, 3f, 12.5f);
                Quaternion spawnRot = transform.rotation;

                grenade = Instantiate(grenadePrefab, spawnPos, spawnRot);
                Rigidbody rigid = grenade.GetComponent<Rigidbody>();

                rigid.AddForce(transform.forward * distance * force, ForceMode.Impulse);
                remainingCooldownGrenade = cooldownGrenade;
            } 
    }
}


