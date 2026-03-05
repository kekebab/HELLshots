using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAim : MonoBehaviour
{
    public LayerMask groundMask;

    void Update()
    {
        // Récupère la position de la souris via le nouveau Input System
        Vector2 mousePos = Mouse.current.position.ReadValue();

        // Crée un rayon depuis la caméra vers la souris
        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        // Raycast vers le sol
        if (Physics.Raycast(ray, out RaycastHit hit, 100f, groundMask))
        {
            // Point visé sur le sol
            Vector3 lookPos = hit.point;

            // On garde la hauteur du joueur pour éviter qu'il s'incline
            lookPos.y = transform.position.y;

            // Le joueur regarde ce point
            transform.LookAt(lookPos);
        }
    }
}
