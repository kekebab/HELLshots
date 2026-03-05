using UnityEngine;
using UnityEngine.InputSystem;

public class BulletControl : MonoBehaviour
{
    public float speed;
    void Update()
    {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            this.transform.position = transform.position;
            this.transform.rotation = transform.rotation;
            Vector3 direction = (ray.GetPoint(10f) - transform.position).normalized;

            this.transform.position += transform.forward * speed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {


        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
