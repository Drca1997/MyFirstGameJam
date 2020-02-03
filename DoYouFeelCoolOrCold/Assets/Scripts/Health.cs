using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class Health : MonoBehaviour
{
    [Tooltip("Vida da Personagem")]
    public float health;
    private GameObject healthBar;
    public HealthBar healthBarToChange;
    public Tilemap tileMap;
    public Tile safeTile;
    public GameObject Player;
    private float healingSpeedSafeZone = 0.005f;


    private void Start()
    {
        healthBar = GameObject.Find("HealthBar");
        health = 1 - healthBar.transform.Find("Bar").localScale.x;
    }

    private void Update()
    {
        //verificar se esta na safe zone
        if (tileMap.GetTile(Vector3Int.FloorToInt(Player.transform.position)) != null)
        {
            if (string.Equals(tileMap.GetTile(Vector3Int.FloorToInt(Player.transform.position)).name, safeTile.name))
            {
                Debug.Log("at safe zone");
                healthBarToChange.ChangeHealthBarValue(healthBarToChange.getHealth() + healingSpeedSafeZone);
            }
        }

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
