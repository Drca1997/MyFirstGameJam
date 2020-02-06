using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : Bar
{

    private float health;
    private Transform red_bar;
    private GameObject player;
    private bool in_safeZone;

    [Tooltip("O quão depressa ganha vida à sombra")]
    public float healthGainRatio = 0.1f;

    [Tooltip("O quão depressa perde vida")]
    public float healthLossRatio = 0.01f;


    private new void Awake()
    {
        base.Start();
        in_safeZone = false;
        red_bar = transform.Find("Red_Bar");
        player = GameObject.Find("Player");
        health = player.GetComponent<Health>().health;
        ChangeHealthBarValue(health);
    }

    public void FixedUpdate()
    {

        health = 1 - bar.localScale.x;
        healthLoss();
    }

    public void ChangeHealthBarValue(float health)
    {
        SetSize(1 - health);
        red_bar.localScale = new Vector2(Mathf.Clamp(1 - health, 0f, 1f), 1f);


        SpriteRenderer barsprite = bar.GetComponentInChildren<SpriteRenderer>();
        Color temp = barsprite.color;
        temp.a = health;

        barsprite.color = temp;
        Debug.Log(barsprite.color.a);
    }

    //só pra testar
    public void test_health_change()
    {
        if (PauseMenu.GameIsPaused == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ChangeHealthBarValue(health - 0.1f);
            }
        }
    }

    public float getHealth()
    {
        return health;
    }

    public void healthLoss()
    {
        if (in_safeZone == false)
        {
            //Se nao estiver à sombra, perder vida
            ChangeHealthBarValue(health - healthLossRatio * Time.fixedDeltaTime);
        }
        else
        {
            //Se estiver à sombra, ganahr vida
            if (health > 0)
            {
                ChangeHealthBarValue(health + healthGainRatio * Time.fixedDeltaTime);
            }
        }
    }

    public void set_safeZone(bool inside)
    {
        in_safeZone = inside;
    }
}