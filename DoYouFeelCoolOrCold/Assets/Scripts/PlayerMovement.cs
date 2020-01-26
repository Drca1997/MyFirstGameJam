using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private StaminaBar staminaBar;

    [SerializeField] private float velocidade = 3f;
    [SerializeField] private float run_modifier = 2f;
    [SerializeField] private float stamina = 1f;
    [SerializeField] private float stamina_run_modifier = 0.01f;
    [SerializeField] private float stamina_regeneration_ratio = 1f;

    public Rigidbody2D rb;
    Vector2 movimento;
    private bool is_running;
    private bool tarrafal = true;

    public void Update()
    {
        stamina = staminaBar.transform.Find("Bar").localScale.x;
        movimento.x = Input.GetAxisRaw("Horizontal");
        movimento.y = Input.GetAxisRaw("Vertical");
        is_running = false;

        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0f && !tarrafal)
        // Pode correr se tiver stamina e não estiver tarrafalizado.
        {
            is_running = (movimento.x != 0) || (movimento.y != 0);
            movimento.x *= run_modifier;
            movimento.y *= run_modifier;
        }
        else if (stamina == 0f)
        // Tarrafalizacao por esvaziar stamina.
        {
            tarrafal = true;
        }
    }


    public void FixedUpdate()
    {
        // Chama o gestor da stamina e depois mexe o boneco.
        StaminaManager();
        rb.MovePosition(rb.position + movimento * velocidade * Time.fixedDeltaTime);
    }

    public void StaminaManager()
    {
        if (is_running)
        // Se estiver a correr, vai degenerar.
        {
            staminaBar.SetSize(stamina - stamina_run_modifier);
        }
        else if (stamina < 1f)
        // Se não houver delay e a stamina não estiver cheia, vai regenerar.
        {
            staminaBar.SetSize(stamina + stamina_run_modifier / stamina_regeneration_ratio);
        }
        else
        // Destarrafalizacao por ter enchido a stamina
        {
            tarrafal = false;
        }
    }
}
