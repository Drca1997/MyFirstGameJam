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
    private string safeName;
    public GameObject Player;
    private float healingSpeedSafeZone = 0.005f;

    private void Start()
    {
        safeName = "sand tile2";
        healthBar = GameObject.Find("HealthBar");
        health = 1 - healthBar.transform.Find("Bar").localScale.x;
    }

    private void Update()
    {
        Vector3 pos = Player.transform.position;
        Vector3 new_pos = new Vector3(pos.x, pos.y - 0.75f, pos.z);
        Vector3Int coordinate = tileMap.WorldToCell(new_pos);

        //verificar se esta na safe zone
        if (string.Equals(tileMap.GetSprite(coordinate).name, safeName))
        {
            Debug.Log("at safe zone");
            healthBarToChange.ChangeHealthBarValue(healthBarToChange.getHealth() + healingSpeedSafeZone);
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
