using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocidade = 5f;
    public float run_modifier = 2f;
    public Rigidbody2D rb;
    Vector2 movimento;

    public void Update()
    {
        movimento.x = Input.GetAxisRaw("Horizontal");
        movimento.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("A correr...");
            movimento.x *= run_modifier;
            movimento.y *= run_modifier;

        }
    }


    public void FixedUpdate()
    {
        rb.MovePosition(rb.position + movimento * velocidade * Time.fixedDeltaTime);
    }

}
