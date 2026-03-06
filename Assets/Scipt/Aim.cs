using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAim : MonoBehaviour
{
    public LayerMask groundMask;
    public Vector3 grenadeTargetPoint;

    void Update()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f, groundMask))
        {
            grenadeTargetPoint = hit.point;

            Vector3 lookPos = hit.point;
            lookPos.y = transform.position.y;
            // Le joueur regarde ce point
            transform.LookAt(lookPos);
        }
    
    }
}

