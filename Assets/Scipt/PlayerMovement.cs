using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public InputActionReference moveAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //print("Virtual stick : " + moveAction.action.ReadValue<Vector2>());

        Vector3 tempPos = new Vector3(moveAction.action.ReadValue<Vector2>().x, 0, moveAction.action.ReadValue<Vector2>().y);

        this.transform.position += tempPos * speed * Time.deltaTime;
    }
}
