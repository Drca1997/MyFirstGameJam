using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimento")]
    [Tooltip("Referência ao RigidBody da Personagem")]
    public Rigidbody2D rb;
    [Tooltip("Referência ao Animator da Personagem")]
    public Animator animator;
    [Tooltip("Velocidade normal da Personagem")]
    public float velocidade = 5f;
    [Tooltip("O quanto a velocidade da personagem aumenta a correr")]
    [SerializeField] private float runModifier = 3f;

    [Header("Stamina")]
    [Tooltip("Referência ao objecto Barra da Stamina")]
    [SerializeField] private StaminaBar staminaBar;

    [Tooltip("Stamina da Personagem")]
    [SerializeField] private float stamina = 1f;
    [Tooltip("O quanto se perde stamina ao correr")]
    [SerializeField] private float staminaRunModifier = 0.01f;
    [Tooltip("O quão rápido se recupera stamina em relação ao quaão rápido se a perde")]
    [SerializeField] private float staminaRegenerationRatio = 1f;

    
    Vector3 movimento;
    public bool is_running;
    private bool tarrafal = true;
    private float stamina_regeneration;

    private void Awake()
    {
        if (PauseMenu.GameIsPaused == false)
            stamina_regeneration = staminaRunModifier / staminaRegenerationRatio;
    }

    public void FixedUpdate()
    {
        if (PauseMenu.GameIsPaused == false)
        {
            stamina = staminaBar.transform.Find("Bar").localScale.x;
            movimento.x = Input.GetAxisRaw("Horizontal");
            movimento.y = Input.GetAxisRaw("Vertical");
            movimento = Vector3.ClampMagnitude(movimento, 1);
            animator.SetInteger("state", 0);

            if (Input.GetKey(KeyCode.LeftShift) && stamina > 0f && !tarrafal)
            // Pode correr se tiver stamina e não estiver tarrafalizado.
            {
                is_running = movimento.magnitude != 0;
                movimento *= runModifier;
            }
            else if (stamina == 0f)
            // Tarrafalizacao por esvaziar stamina.
            {
                tarrafal = true;
                animator.SetBool("tarrafal", true);
                is_running = false;
            }
            else
            {
                is_running = false;
            }

            // Chama o gestor da stamina.
            StaminaManager();

            if (movimento.magnitude != 0)
            {
                // Avisa o Animator que está Run ou Walk.
                animator.SetInteger("state", is_running ? 2 : 1);
                // Avisa o Animator para que lado está a olhar o boneco.
                animator.SetFloat("move_x", movimento.x);
                animator.SetFloat("move_y", movimento.y);
                // Desloca o boneco.
                rb.MovePosition(transform.position + movimento * velocidade * Time.fixedDeltaTime);
            }
            
        }
    }

    public void StaminaManager()
    {
        if (PauseMenu.GameIsPaused == false && is_running)
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
            animator.SetBool("tarrafal", false);
        }
        
    }
    
}
