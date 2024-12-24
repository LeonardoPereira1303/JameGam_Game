using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillBar;
    public float health;
    
    public void LoseHealth(int value)
    {
        if (health <= 0)
            return;
        health -= value;

        fillBar.fillAmount = health / 100;

        if(health <= 0)
        {
            FindObjectOfType<MenuManager>().Defeat();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LoseHealth(25);
        }
    }
}
