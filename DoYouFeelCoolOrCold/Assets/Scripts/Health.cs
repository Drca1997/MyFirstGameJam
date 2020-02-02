using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Tooltip("Vida da Personagem")]
    public float health;
    private GameObject healthBar;


    private void Start()
    {
        healthBar = GameObject.Find("HealthBar");
        health = 1 - healthBar.transform.Find("Bar").localScale.x;
    }

    private void Update()
    {
        health = 1 - healthBar.transform.Find("Bar").localScale.x;
        if (health <= 0f)
        {
            Death();
        }
    }

    public void Death()
    {
        //Lidar com a morte da personagem
        SceneManager.LoadScene("DeathMenu");
    }


}
