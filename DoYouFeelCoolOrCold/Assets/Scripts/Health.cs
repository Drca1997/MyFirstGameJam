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
    public GameObject Player;
    public Animator animator;

    private void Start()
    {
        healthBar = GameObject.Find("HealthBar");
        health = 1 - healthBar.transform.Find("Bar").localScale.x;
    }

    private void FixedUpdate()
    {
        //Vector3 pos = Player.transform.position;
        //Vector3 new_pos = new Vector3(pos.x, pos.y - 0.75f, pos.z);
        //Vector3Int coordinate = tileMap.WorldToCell(new_pos);

        health = 1 - healthBar.transform.Find("Bar").localScale.x;

        if (health <= 0f)
        {
            Death();
        }
    }

    public void Death()
    {
        
        float transition_scene_waiting_time = 0f;
        Player.GetComponent<PlayerMovement>().velocidade = 0f;
        //Lidar com a morte da personagem
        animator.SetBool("is_dead", true);
        
        AnimatorClipInfo[] clips = animator.GetCurrentAnimatorClipInfo(0);
        
        foreach(AnimatorClipInfo clip in clips)
        {
            
            transition_scene_waiting_time += clip.clip.length;         
        }

        Debug.Log("WAITING TIME: " + transition_scene_waiting_time);
        StartCoroutine(DelayedLoad(transition_scene_waiting_time));

    }

    IEnumerator DelayedLoad(float waiting_time)
    {
        
        //Wait until clip finish playing
        yield return new WaitForSeconds(waiting_time);
        //Load scene here
        SceneManager.LoadScene("DeathMenu");

        
    }

}
