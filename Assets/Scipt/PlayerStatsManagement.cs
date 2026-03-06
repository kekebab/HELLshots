using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerStatsManagement : MonoBehaviour
{
    public Slider healthSliderWorld;
    public Slider healthSliderUI;
    public float maxHealth = 100f;
    public float health;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            takeDamage(10);
        }

        if (healthSliderUI != null)
            healthSliderUI.value = health;

        if (healthSliderWorld != null)
            healthSliderWorld.value = health;
    }
    
    public void takeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Max(0, health);
    }
}