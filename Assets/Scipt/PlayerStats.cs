using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float Health = 100f;

    public void TakeDamage(float damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            Debug.Log("Player Dead");
            gameObject.SetActive(false);
        }
    }
}