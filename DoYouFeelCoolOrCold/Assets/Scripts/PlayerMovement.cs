using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private StaminaBar staminaBar;


    [SerializeField] private float velocidade;
    [SerializeField] private float run_modifier;
    [SerializeField] private float stamina_run_modifier;
    [SerializeField]private float stamina_regeneration_ratio;
    public Rigidbody2D rb;
    Vector2 movimento;
    private bool is_running;
    [SerializeField]private float stamina;


   
    public void Update()
    {
        stamina = staminaBar.transform.Find("Bar").localScale.x;
        is_running = false;
        movimento.x = Input.GetAxisRaw("Horizontal");
        movimento.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {

            if (stamina > 0.0f)
            {
                Debug.Log("A correr...");
                movimento.x *= run_modifier;
                movimento.y *= run_modifier;
                is_running = true;
            }
            
        }
        
    }   


    public void FixedUpdate()
    {
        StaminaManager();
        rb.MovePosition(rb.position + movimento * velocidade * Time.fixedDeltaTime);
       
    }

    public void StaminaManager()
    {
        if (is_running)
        {
            staminaBar.SetSize(stamina - stamina_run_modifier);
        }
        else
        {
            if (stamina < 1f)
            {
                staminaBar.SetSize(stamina + stamina_run_modifier / stamina_regeneration_ratio);

            }

        }
    }
}
