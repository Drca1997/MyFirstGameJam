using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimento")]
    [Tooltip("Referência ao RigidBody da Personagem")]
    public Rigidbody2D rb;
    [Tooltip("Velocidade normal da Personagem")]
    [SerializeField] private float velocidade = 3f;
    [Tooltip("O quanto a velocidade da personagem aumenta a correr")]
    [SerializeField] private float runModifier = 2f;

    [Header("Stamina")]
    [Tooltip("Referência ao objecto Barra da Stamina")]
    [SerializeField] private StaminaBar staminaBar;


    [Tooltip("Stamina da Personagem")]
    [SerializeField] private float stamina = 1f;
    [Tooltip("O quanto se perde stamina ao correr")]
    [SerializeField] private float staminaRunModifier = 0.01f;
    [Tooltip("O quão rápido se recupera stamina em relação ao quaão rápido se a perde")]
    [SerializeField] private float staminaRegenerationRatio = 1f;

    
    Vector2 movimento;
    private bool is_running;
    private bool tarrafal = true;
    private float stamina_regeneration;

    private void Awake()
    {
        stamina_regeneration = staminaRunModifier / staminaRegenerationRatio;
    }
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
            movimento.x *= runModifier;
            movimento.y *= runModifier;
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
            staminaBar.SetSize(stamina - staminaRunModifier);
            
        }
        else if (stamina < 1f)
        // Se não houver delay e a stamina não estiver cheia, vai regenerar.
        {
            staminaBar.SetSize(stamina + stamina_regeneration);
        }
        else
        // Destarrafalizacao por ter enchido a stamina
        {
            tarrafal = false;
        }
    }
}
