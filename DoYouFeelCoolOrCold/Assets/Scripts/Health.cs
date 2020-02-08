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

    private Som s;
    public GameObject deathMenuUI;

    private void Start()
    {
        healthBar = GameObject.Find("HealthBar");
        health = 1 - healthBar.transform.Find("Bar").localScale.x;
        s = FindObjectOfType<AudioManager>().getSom("Morte");
    }

    private void FixedUpdate()
    {
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

        s.source.Play();
        StartCoroutine(DelayedLoad(transition_scene_waiting_time));

    }

    IEnumerator DelayedLoad(float waiting_time)
    {
        //Wait until clip finish playing
        yield return new WaitForSeconds(waiting_time);
        //Set death menu active
        Time.timeScale = 0f;
        PauseMenu.GameIsPaused = true;
        deathMenuUI.SetActive(true);
    }

}
